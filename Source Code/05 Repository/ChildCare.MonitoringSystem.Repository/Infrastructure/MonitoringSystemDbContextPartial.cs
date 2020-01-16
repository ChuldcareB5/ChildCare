using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Repository
{
    public partial class MonitoringSystemDbContext
    {
        private readonly IRepositoryFactory repositoryFactory;
        private bool shouldBeginTransaction;
        private bool isInTransaction;
        private bool isInValidState = true;
        private Stack<string> transactionStack = new Stack<string>();

        public int ActiveTransactionCount
        {
            get
            {
                return transactionStack.Count;
            }
        }

        public bool SuppressDivisionFilters { get; private set; }

        public bool SuppressSoftDeleteFilters { get; private set; }

        public MonitoringSystemDbContext(IRepositoryFactory repositoryFactory, DbContextOptions<MonitoringSystemDbContext> options, ApplicationContext applicationContext)
            : this(options, applicationContext)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public bool IsInValidState()
        {
            return this.isInValidState;
        }

        public void EnforceBeginTransaction()
        {
            shouldBeginTransaction = true;
        }

        public ITransactionScope BeginTransaction(bool suppressIDivisionFilter = false, bool suppressISoftDeleteFilter = false)
        {
            // We consider the suppress filter only for outer scope
            if (this.ActiveTransactionCount == 0)
            {
                this.SuppressDivisionFilters = suppressIDivisionFilter;
                this.SuppressSoftDeleteFilters = suppressISoftDeleteFilter;
            }

            isInTransaction = true;
            var transactionScope = new TransactionScope(this);
            transactionStack.Push(transactionScope.TransactionId);

            return transactionScope;
        }

        public void EndTransaction(string transactionId)
        {
            var topTransactionId = transactionStack.Pop();
            if (topTransactionId != transactionId)
            {
                throw new Exception("The transaction scopes are malfunctioned. Ensure that the nested transactions are last in first out order.");
            }

            // Reset the suppress filter when going out from the outer scope
            if (this.ActiveTransactionCount == 0)
            {
                this.SuppressDivisionFilters = false;
                this.SuppressSoftDeleteFilters = false;
            }
        }

        public T GetRepository<T>() where T : IRepository
        {
            return this.repositoryFactory.CreateInstance<T>(this);
        }

        public int Save()
        {
            if (this.ValidateSave())
            {
                return this.SaveChanges();
            }

            return -1;
        }

        public async Task<int> SaveAsync()
        {
            if (this.ValidateSave())
            {
                return await this.SaveChangesAsync();
            }

            return -1;
        }

        public override int SaveChanges()
        {
            this.Audit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Audit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.Audit();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Audit();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void Audit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
            var addedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added).ToList();

            foreach (var entry in modifiedEntries)
            {
                if (entry is IAuditable auditable)
                {
                    auditable.UpdatedBy = this.ApplicationContext.UserId;
                    auditable.UpdatedOn = DateTime.UtcNow;
                }
            }

            foreach (var entry in addedEntries)
            {
                if (entry.Entity is IAuditable auditable)
                {
                    auditable.CreatedBy = auditable.UpdatedBy = this.ApplicationContext.UserId;

                    if (auditable.CreatedOn == default(DateTime))
                    {
                        // If the date is default, then set curent date
                        auditable.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        // Set already existing created date as modified date.
                        auditable.UpdatedOn = auditable.CreatedOn;
                    }
                }
            }
        }

        private bool ValidateSave()
        {
            if (shouldBeginTransaction && !isInTransaction)
            {
                this.isInValidState = false;
                throw new Exception("An unit of work transaction must be initiated and the save should be called on generated transaction scope object.");
            }

            if (shouldBeginTransaction && isInTransaction)
            {
                return false;
            }

            return true;
        }
    }
}

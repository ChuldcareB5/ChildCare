using ChildCare.MonitoringSystem.Core.Constraints;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Repository
{
    public class TransactionScope : ITransactionScope
    {
        private readonly IUnitOfWork unitOfWork;
        private bool allowDisposal;

        public string TransactionId { get; } = Guid.NewGuid().ToString();

        public TransactionScope(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Completed the transaction by saving the changes.
        /// </summary>
        /// <returns>Returns -1 if save changes havn't executed.</returns>
        public async Task<int> Complete()
        {
            allowDisposal = true;
            if (this.unitOfWork.ActiveTransactionCount == 1)
            {
                return await (this.unitOfWork as DbContext).SaveChangesAsync();
            }

            return -1;
        }

        public void Abort()
        {
            allowDisposal = true;
        }

        public void Dispose()
        {
            if (!allowDisposal && unitOfWork.IsInValidState())
            {
                //Logger.Log.Error("The Complete or Abort must be called before leaving the transaction scope.");
            }

            this.unitOfWork.EndTransaction(this.TransactionId);
        }
    }
}

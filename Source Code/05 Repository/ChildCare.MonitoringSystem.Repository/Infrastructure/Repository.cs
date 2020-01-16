
using ChildCare.MonitoringSystem.Common;
using ChildCare.MonitoringSystem.Common.Extensions;
using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Core.Models;
using ChildCare.MonitoringSystem.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMonitoringSystemDbContext dbContext;
        protected readonly DbSet<T> dbset;

        /// <summary>
        /// Initializes the <see cref="Repository{T}"/>
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/></param>
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            this.dbContext = unitOfWork as IMonitoringSystemDbContext;
            if (this.dbContext == null)
            {
                throw new Exception("Invalid unit of work.");
            }

            this.dbset = this.dbContext.Set<T>();
        }

        /// <summary>
        /// The Add an entity
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public virtual void Add(T entity,bool suppressCreatedOnMapping = false)
        {
            if (entity is IAuditable auditable)
            {
                auditable.CreatedBy = auditable.UpdatedBy = this.unitOfWork.ApplicationContext.UserId;
                auditable.UpdatedOn = DateTime.UtcNow;
            }

            if (!suppressCreatedOnMapping && entity is IAuditable createdOn)
            {
                createdOn.CreatedOn = DateTime.UtcNow;
            }

            this.dbset.Add(entity);
        }

        /// <summary>
        /// The Update an entity
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public virtual void Update(T entity)
        {
            if (entity is IAuditable auditable)
            {
                auditable.UpdatedBy = this.unitOfWork.ApplicationContext.UserId;
                auditable.UpdatedOn = DateTime.UtcNow;
            }

            var entry = dbContext.Entry(entity);
            this.dbset.Attach(entity);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// The Delete an entity
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public virtual void Delete(T entity)
        {
            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        /// <summary>
        /// To get the entities by provided condition.
        /// </summary>
        /// <param name="predicate">The conditions to filter with.</param>
        /// <returns>The list of entities</returns>GetAllAsync
        public List<T> GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return this.GetByAsync(predicate, includes).Result;
        }

        /// <summary>
        /// To get the entities by provided condition.
        /// </summary>
        /// <param name="predicate">The conditions to filter with.</param>
        /// <returns>The list of entities</returns>
        public PagedResultModel<T> GetBy(Expression<Func<T, bool>> predicate, FilterModel filterModel, params Expression<Func<T, object>>[] includes)
        {
            return this.GetFilteredRecords(filterModel, predicate, includes).Result;
        }

        /// <summary>
        /// To get the entities by provided condition asynchronously.
        /// </summary>
        /// <param name="predicate">The conditions to filter with.</param>
        /// <param name="includes">The 0 or more navigation properties to include for EF eager loading.</param>
        /// <returns>The list of entities</returns>
        public async Task<List<T>> GetByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                return await this.Include(this.dbset.Where(this.ApplyFilters(predicate)), includes).ToListAsync().ConfigureAwait(false);
            }

            return await this.dbset.Where(this.ApplyFilters(predicate)).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="filterModel"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public async Task<PagedResultModel<T>> GetByAsync(Expression<Func<T, bool>> predicate, FilterModel filterModel, params Expression<Func<T, object>>[] includes)
        {
            return await this.GetFilteredRecords(filterModel, predicate, includes);
        }

        /// <summary>
        /// To get all entities.
        /// </summary>
        /// <param name="includes">The 0 or more navigation properties to include for EF eager loading.</param>
        /// <returns>The list of entities</returns>
        public virtual List<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return this.GetAllAsync(includes).Result;
        }

        public virtual PagedResultModel<T> GetAll(FilterModel filterModel, params Expression<Func<T, object>>[] includes)
        {
            return this.GetAllAsync(filterModel, includes).Result;
        }

        /// <summary>
        /// To get all entities asynchronously.
        /// </summary>
        /// <param name="includes">The 0 or more navigation properties to include for EF eager loading.</param>
        /// <returns>The list of entities</returns>
        public virtual async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                return await this.Include(this.dbset.Where(this.ApplyFilters()), includes).ToListAsync().ConfigureAwait(false);
            }

            return await this.dbset.Where(this.ApplyFilters()).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterModel"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual async Task<PagedResultModel<T>> GetAllAsync(FilterModel filterModel, params Expression<Func<T, object>>[] includes)
        {

            return await this.GetFilteredRecords(filterModel, x => true, includes);
        }

        /// <summary>
        /// To determine the existance of an entity by the provided condition.
        /// </summary>
        /// <param name="predicate">The condition to filter with.</param>
        /// <returns>Either true or false as per the match.</returns>
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return this.AnyAsync(predicate).Result;
        }

        /// <summary>
        /// To determine the existance of an entity by the provided condition asynchronously.
        /// </summary>
        /// <param name="predicate">The condition to filter with.</param>
        /// <returns>Either true or false as per the match.</returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.dbset.AnyAsync(this.ApplyFilters(predicate)).ConfigureAwait(false);
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// A function wrapper to execute the stored procedure.
        /// </summary>
        /// <typeparam name="SPRT">The stored procedure return type.</typeparam>
        /// <param name="action">A function which does the stored procedure call.</param>
        /// <returns>The stored procedure result.</returns>
        protected SPRT UsingStoredProedure<SPRT>(Func<IMonitoringSystemDbContext, SPRT> action)
        {
            // TODO: Implement Db transaction.
            using (TransactionCoordinator.With(this.dbContext.ApplicationContext, null))
            {
                return action(this.dbContext);
            }
        }

        /// <summary>
        /// A function wrapper to execute the stored procedure asynchronously.
        /// </summary>
        /// <typeparam name="SPRT">The stored procedure return type.</typeparam>
        /// <param name="action">A function which does the stored procedure call.</param>
        /// <returns>The stored procedure result.</returns>
        protected async Task<SPRT> UsingStoredProedure<SPRT>(Func<IMonitoringSystemDbContext, Task<SPRT>> action)
        {
            // TODO: Implement Db transaction.
            using (TransactionCoordinator.With(this.dbContext.ApplicationContext, null))
            {
                return await action(this.dbContext);
            }
        }

        /// <summary>
        /// To apply the filtes to provided expression.
        /// </summary>
        /// <param name="expression">The expression to which the filter needs to be applied.</param>
        /// <returns>Filtered expression.</returns>
        protected Expression<Func<T, bool>> ApplyFilters(Expression<Func<T, bool>> expression = null)
        {
            // By default consider all.
            Expression<Func<T, bool>> filter = x => true;

            if (!this.unitOfWork.SuppressSoftDeleteFilters)
            {
                // Apply the soft deletion filter if applicable
                if (typeof(ISoftDelete).IsAssignableFrom(typeof(T)))
                {
                    filter = x => !((ISoftDelete)x).IsDeleted;
                }
            }

            return expression == null ? filter : expression.And(filter);
        }

        private IQueryable<T> Include(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            foreach (var include in includes)
            {
                query = this.IncludeProperty(query, include);
            }

            return query;
        }

        private IQueryable<T> IncludeProperty<TProperty>(IQueryable<T> query, Expression<Func<T, TProperty>> include)
        {
            return query.Include(include);
        }

        private async Task<PagedResultModel<T>> GetFilteredRecords(FilterModel filterModel, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            PagedResultModel<T> pagedResult = new PagedResultModel<T>();

            var skip = (filterModel.PageNumber) * filterModel.PageSize;

            Expression<Func<T, bool>> searchFilterExpression = null;
            var generalFilterExpression = this.ApplyFilters(predicate);
            var sortExpression = GetSortExpression(filterModel.SortMember);

            if (filterModel.Filters?.Count > 0)
            {
                searchFilterExpression = FilterExpression(filterModel.Filters);
                pagedResult.TotalRecords = this.dbset.Where(generalFilterExpression).Where(searchFilterExpression).Count();
            }
            else
            {
                pagedResult.TotalRecords = (this.dbset.Where(generalFilterExpression)).Count();
            }

            pagedResult.TotalPages = ((pagedResult.TotalRecords + filterModel.PageSize - 1) / filterModel.PageSize);

            IQueryable<T> source;

            if (filterModel.Filters?.Count > 0)
            {
                source = this.dbset.Where(generalFilterExpression).Where(searchFilterExpression);
            }
            else
            {
                source = this.dbset.Where(generalFilterExpression);
            }

            if (includes != null)
            {
                source = this.Include(source, includes);
            }

            if (filterModel.SortDescending)
            {
                pagedResult.Records = await source
                   .OrderByDescending(sortExpression)
                   .Skip(skip).Take(filterModel.PageSize).ToListAsync().ConfigureAwait(false);
            }
            else
            {
                pagedResult.Records = await source
                    .OrderBy(sortExpression)
                    .Skip(skip).Take(filterModel.PageSize).ToListAsync().ConfigureAwait(false);
            }

            return pagedResult;
        }

        private Expression<Func<T, object>> GetSortExpression(string sortBy)
        {
            var entityType = typeof(T);
            if (sortBy.Contains('.'))
            {
                var param = Expression.Parameter(entityType, "instance");
                string[] childProperties = sortBy.Split('.');

                Expression parent = param;

                foreach (var childProperty in childProperties)
                {
                    parent = Expression.Property(parent, childProperty);
                }

                var sortExpression = Expression.Lambda<Func<T, object>>(parent, param);
                return sortExpression;
            }
            else if (entityType.GetProperties().Any(x => x.Name.ToLower() == sortBy.ToLower() && x.CanRead))
            {
                PropertyInfo propertyInfo = entityType.GetProperty(sortBy);
                ParameterExpression parameterExpression = Expression.Parameter(entityType, "instance");
                MemberExpression memberExpression = Expression.Property(parameterExpression, sortBy);
                Expression conversion = Expression.Convert(memberExpression, typeof(object));
                var result = Expression.Lambda<Func<T, object>>(conversion, parameterExpression);
                return result;
            }

            return null;
        }

        private Expression<Func<T, bool>> FilterExpression(List<FilterOption> filters)
        {
            Expression<Func<T, bool>> filterExpression = x => true;

            foreach (var filter in filters)
            {
                var entityType = typeof(T);
                if (filter.Property.Contains('.'))
                {
                    var parameterExpression = Expression.Parameter(entityType, "instance");
                    string[] childProperties = filter.Property.Split('.');

                    Expression memberExpression = parameterExpression;

                    foreach (var childProperty in childProperties)
                    {
                        memberExpression = Expression.Property(memberExpression, childProperty);
                    }

                    filterExpression = filterExpression.And(this.GetFilterExpression(filter.Value, parameterExpression, memberExpression, filter.Operator));
                }
                else if (entityType.GetProperties().Any(x => x.Name.ToLower() == filter.Property.ToLower() && x.CanRead))
                {
                    ParameterExpression parameterExpression = Expression.Parameter(entityType, "instance");
                    MemberExpression memberExpression = Expression.Property(parameterExpression, filter.Property);

                    filterExpression = filterExpression.And(this.GetFilterExpression(filter.Value, parameterExpression, memberExpression, filter.Operator));
                }
            }

            return filterExpression;
        }

        private Expression<Func<T, bool>> GetFilterExpression(string filterValue, ParameterExpression parameterExpression, Expression memberExpression, string filterOperator)
        {
            ConstantExpression constantExpression = Expression.Constant(Convert.ChangeType(filterValue, memberExpression.Type));
            Expression expression;

            if (filterOperator != null)
            {
                if (memberExpression.Type == typeof(DateTime))
                {
                    expression = this.GetDateFilterExpression(memberExpression, filterOperator, constantExpression);
                }
                else
                {
                    switch (filterOperator)
                    {
                        case Constants.Operators.Equal:
                            expression = Expression.Equal(memberExpression, constantExpression);
                            break;
                        case Constants.Operators.LessThan:
                            expression = Expression.LessThan(memberExpression, constantExpression);
                            break;
                        case Constants.Operators.GreaterThan:
                            expression = Expression.GreaterThan(memberExpression, constantExpression);
                            break;
                        case Constants.Operators.LessThanOrEquals:
                            expression = Expression.LessThanOrEqual(memberExpression, constantExpression);
                            break;
                        case Constants.Operators.GreaterThanOrEquals:
                            expression = Expression.GreaterThanOrEqual(memberExpression, constantExpression);
                            break;
                        default:
                            throw new ApplicationException("Invalid operator!");
                    }
                }
            }
            else
            {
                MethodInfo containsMethodInfo = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                expression = Expression.Call(memberExpression, containsMethodInfo, constantExpression);
            }

            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
        }

        private Expression GetDateFilterExpression(Expression memberExpression, string filterOperator, ConstantExpression constantExpression)
        {
            Expression expression;

            switch (filterOperator)
            {
                case Constants.Operators.Equal:
                    expression = Expression.Equal(Expression.MakeMemberAccess(memberExpression, typeof(DateTime).GetMember("Date").Single()), constantExpression);
                    break;
                case Constants.Operators.LessThan:
                    expression = Expression.LessThan(Expression.MakeMemberAccess(memberExpression, typeof(DateTime).GetMember("Date").Single()), constantExpression);
                    break;
                case Constants.Operators.GreaterThan:
                    expression = Expression.GreaterThan(Expression.MakeMemberAccess(memberExpression, typeof(DateTime).GetMember("Date").Single()), constantExpression);
                    break;
                case Constants.Operators.LessThanOrEquals:
                    expression = Expression.LessThanOrEqual(Expression.MakeMemberAccess(memberExpression, typeof(DateTime).GetMember("Date").Single()), constantExpression);
                    break;
                case Constants.Operators.GreaterThanOrEquals:
                    expression = Expression.GreaterThanOrEqual(Expression.MakeMemberAccess(memberExpression, typeof(DateTime).GetMember("Date").Single()), constantExpression);
                    break;
                default:
                    throw new ApplicationException("Invalid operator!");
            }

            return expression;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="dispose">The Dispose</param>
        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                // Nothing to dispose here.
            }
        }
    }

}

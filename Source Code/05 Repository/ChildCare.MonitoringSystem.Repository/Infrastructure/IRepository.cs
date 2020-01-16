using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Core.Models;
using ChildCare.MonitoringSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Repository
{
    public interface IRepository<T> : IRepository, IDisposable where T : BaseEntity
    {
        /// <summary>
        /// To get all entities.
        /// </summary>
        /// <param name="includes">The 0 or more navigation properties to include for EF eager loading.</param>
        /// <returns>The list of entities</returns>
        List<T> GetAll(params Expression<Func<T, object>>[] includes);

        PagedResultModel<T> GetAll(FilterModel filterModel, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// To get all entities asynchronously.
        /// </summary>
        /// <param name="includes">The 0 or more navigation properties to include for EF eager loading.</param>
        /// <returns>The list of entities</returns>
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        Task<PagedResultModel<T>> GetAllAsync(FilterModel filterModel, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// To get the entities by provided condition.
        /// </summary>
        /// <param name="predicate">The conditions to filter with.</param>
        /// <returns>The list of entities</returns>
        List<T> GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        PagedResultModel<T> GetBy(Expression<Func<T, bool>> predicate, FilterModel filterModel, params Expression<Func<T, object>>[] includes);

        Task<List<T>> GetByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// To get the entities by provided condition asynchronously.
        /// </summary>
        /// <param name="predicate">The conditions to filter with.</param>
        /// <param name="includes">The 0 or more navigation properties to include for EF eager loading.</param>
        /// <returns>The list of entities</returns>
        Task<PagedResultModel<T>> GetByAsync(Expression<Func<T, bool>> predicate, FilterModel filterModel = null, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// To determine the existance of an entity by the provided condition.
        /// </summary>
        /// <param name="predicate">The condition to filter with.</param>
        /// <returns>Either true or false as per the match.</returns>
        bool Any(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// To determine the existance of an entity by the provided condition asynchronously.
        /// </summary>
        /// <param name="predicate">The condition to filter with.</param>
        /// <returns>Either true or false as per the match.</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// The Add an entity
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="suppressOrgIdMapping">
        void Add(T entity,bool suppressCreatedOnMapping = false);

        /// <summary>
        /// The Update an entity
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// The Delete an entity
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);
    }
}

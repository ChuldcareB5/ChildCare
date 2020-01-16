using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChildCare.MonitoringSystem.Common.Extensions
{
    /// <summary>
    /// The IQueryable Extensions
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// The For Each
        /// </summary>
        /// <typeparam name="T">The T</typeparam>
        /// <param name="source">The Source</param>
        /// <param name="action">The Action</param>
        public static void ForEach<T>(this IQueryable<T> source, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentException("The action cannot be null");
            }

            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// The To Model
        /// </summary>
        /// <typeparam name="Entity">The Entity</typeparam>
        /// <typeparam name="Model">The Model</typeparam>
        /// <param name="source">The Source</param>
        /// <returns>The Models</returns>
        public static List<Model> ToModel<Entity, Model>(this IQueryable<Entity> source)
        {
            return source.Select(entity => Mapper.Map<Model>(entity)).ToList();
        }
    }
}

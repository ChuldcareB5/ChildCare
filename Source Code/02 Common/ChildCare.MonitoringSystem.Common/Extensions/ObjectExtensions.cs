using AutoMapper;
using ChildCare.MonitoringSystem.Core.Models;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static T MapTo<T>(this object obj)
        {
            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// Map PagedResult from Entity to Model
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <typeparam name="Model"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static PagedResultModel<Model> ToModel<Entity, Model>(PagedResultModel<Entity> source)
        {
            var result = Mapper.Map<List<Model>>(source.Records);
            PagedResultModel<Model> pagedResult = new PagedResultModel<Model>();
            pagedResult.Records = result;
            pagedResult.TotalRecords = source.TotalRecords;
            return pagedResult;
        }
    }
}

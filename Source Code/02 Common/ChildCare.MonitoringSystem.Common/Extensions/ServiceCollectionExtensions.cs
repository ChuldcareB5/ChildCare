using ChildCare.MonitoringSystem.Core.Constraints;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChildCare.MonitoringSystem.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepository<RepoInterface, RepoConcrete>(this IServiceCollection services)
            where RepoConcrete : RepoInterface
        {
            services.AddSingleton(provider =>
            {
                return new Func<IUnitOfWork, RepoInterface>(uow =>
                {
                    var parameters = GetConstructorParams(typeof(RepoConcrete), uow, provider);
                    return (RepoConcrete)Activator.CreateInstance(typeof(RepoConcrete), parameters);
                });
            });
        }

        public static void AddBusiness<BusinessInterface, BusinessConcrete>(this IServiceCollection services)
            where BusinessConcrete : class, BusinessInterface
            where BusinessInterface : class
        {
            services.AddTransient<BusinessInterface, BusinessConcrete>();
            services.AddSingleton(provider =>
            {
                return new Func<IUnitOfWork, BusinessInterface>(uow =>
                {
                    var parameters = GetConstructorParams(typeof(BusinessConcrete), uow, provider);
                    return (BusinessConcrete)Activator.CreateInstance(typeof(BusinessConcrete), parameters);
                });
            });
        }

        private static object[] GetConstructorParams(Type type, IUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            var constructor = type.GetConstructors()[0];
            var constructorParams = constructor.GetParameters();
            var parameters = new object[constructorParams.Length];

            var i = 0;
            foreach (var paramInfo in constructorParams)
            {
                if (paramInfo.ParameterType == typeof(IUnitOfWork))
                {
                    parameters[i] = unitOfWork;
                }
                else
                {
                    parameters[i] = serviceProvider.GetService(paramInfo.ParameterType);
                }

                i++;
            }

            return parameters;
        }
    }
}

using ChildCare.MonitoringSystem.Core.Constraints;
using System;

namespace ChildCare.MonitoringSystem.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TRepository CreateInstance<TRepository>(IUnitOfWork unitOfWork) where TRepository : IRepository
        {
            var service = this.serviceProvider.GetService(typeof(Func<IUnitOfWork, TRepository>)) as Func<IUnitOfWork, TRepository>;
            return service(unitOfWork);
        }
    }
}

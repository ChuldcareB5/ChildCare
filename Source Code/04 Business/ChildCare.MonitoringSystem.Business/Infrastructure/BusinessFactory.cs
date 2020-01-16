using ChildCare.MonitoringSystem.Core.Constraints;
using System;

namespace ChildCare.MonitoringSystem.Business.Infrastructure
{
    public class BusinessFactory : IBusinessFactory
    {
        private readonly IServiceProvider serviceProvider;

        public BusinessFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TBusiness CreateInstance<TBusiness>(IUnitOfWork unitOfWork) where TBusiness : class
        {
            unitOfWork.EnforceBeginTransaction();
            var service = this.serviceProvider.GetService(typeof(Func<IUnitOfWork, TBusiness>)) as Func<IUnitOfWork, TBusiness>;
            return service(unitOfWork) as TBusiness;
        }
    }
}

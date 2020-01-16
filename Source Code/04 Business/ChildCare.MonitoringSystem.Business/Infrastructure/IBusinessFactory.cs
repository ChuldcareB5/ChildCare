using ChildCare.MonitoringSystem.Core.Constraints;

namespace ChildCare.MonitoringSystem.Business.Infrastructure
{
    public interface IBusinessFactory
    {
        TBusiness CreateInstance<TBusiness>(IUnitOfWork unitOfWork) where TBusiness : class;
    }
}

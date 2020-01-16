using ChildCare.MonitoringSystem.Core.Constraints;

namespace ChildCare.MonitoringSystem.Repository
{
    public interface IRepositoryFactory
    {
        TRepository CreateInstance<TRepository>(IUnitOfWork unitOfWork) where TRepository : IRepository;
    }
}

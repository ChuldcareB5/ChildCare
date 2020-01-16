using ChildCare.MonitoringSystem.Core.Models;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Core.Constraints
{
    public interface IUnitOfWork
    {
        ApplicationContext ApplicationContext { get; }

        int ActiveTransactionCount { get; }

        bool SuppressDivisionFilters { get; }

        bool SuppressSoftDeleteFilters { get; }

        bool IsInValidState();

        void EnforceBeginTransaction();

        ITransactionScope BeginTransaction(bool suppressIDivisionFilter = false, bool suppressISoftDeleteFilter = false);

        void EndTransaction(string transactionId);

        T GetRepository<T>() where T : IRepository;

        int Save();

        Task<int> SaveAsync();
    }

}

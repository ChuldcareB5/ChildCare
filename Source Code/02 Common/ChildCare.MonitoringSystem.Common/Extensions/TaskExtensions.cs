using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Common.Extensions
{
    public static class TaskExtensions
    {
        public static async void Forget(this Task task)
        {
            await task.ConfigureAwait(false);
        }
    }
}

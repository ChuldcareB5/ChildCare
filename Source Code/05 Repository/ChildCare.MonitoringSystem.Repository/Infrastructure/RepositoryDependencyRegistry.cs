using ChildCare.MonitoringSystem.Common;
using ChildCare.MonitoringSystem.Common.Extensions;
using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Core.Models;
using ChildCare.MonitoringSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChildCare.MonitoringSystem.Repository
{
    public static class RepositoryDependencyRegistry
    {
        public static void RegisterDependency(IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IRepositoryFactory, RepositoryFactory>();

            services.AddTransient<IUnitOfWork, IMonitoringSystemDbContext>(provider =>
                new MonitoringSystemDbContext(
                    provider.GetService<IRepositoryFactory>(),
                    new DbContextOptionsBuilder<MonitoringSystemDbContext>().UseSqlServer(appSettings.ConnectionString).Options,
                    provider.GetService<ApplicationContext>()));

			services.AddRepository<IRepository<User>, Repository<User>>();
			services.AddRepository<IRepository<Role>, Repository<Role>>();
            services.AddRepository<IRepository<Student>, Repository<Student>>();
        }
    }
}

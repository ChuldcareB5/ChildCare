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
			services.AddRepository<IRepository<Contact>, Repository<Contact>>();
			services.AddRepository<IRepository<UserRole>, Repository<UserRole>>();
			services.AddRepository<IRepository<Student>, Repository<Student>>();
			services.AddRepository<IRepository<Bus>, Repository<Bus>>();
			services.AddRepository<IRepository<BusSchedule>, Repository<BusSchedule>>();
            services.AddRepository<IRepository<Room>, Repository<Room>>();
            services.AddRepository<IRepository<RoomSchedule>, Repository<RoomSchedule>>();
            services.AddRepository<IRepository<StudentBusSchedule>, Repository<StudentBusSchedule>>();
			services.AddRepository<IRepository<MessageBoard>, Repository<MessageBoard>>();
            services.AddRepository<IRepository<StudentLocation>, Repository<StudentLocation>>();
            services.AddRepository<IRepository<BusLocation>, Repository<BusLocation>>();
            services.AddRepository<IRepository<StudentBusSchedule>, Repository<StudentBusSchedule>>();
            services.AddRepository<IRepository<RoomVideo>, Repository<RoomVideo>>();
        }
    }
}

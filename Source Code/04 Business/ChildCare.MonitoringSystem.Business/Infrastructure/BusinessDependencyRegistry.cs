using ChildCare.MonitoringSystem.Common;
using ChildCare.MonitoringSystem.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ChildCare.MonitoringSystem.Business.Infrastructure
{
    public static class BusinessDependencyRegistry
    {
        public static void RegisterDependency(IServiceCollection services, AppSettings appSettings)
        {
            RepositoryDependencyRegistry.RegisterDependency(services, appSettings);
			services.AddTransient<UserBusiness>();
			services.AddTransient<ContactBusiness>();
			services.AddTransient<StudentBusiness>();
			services.AddTransient<BusBusiness>();
			services.AddTransient<BusScheduleBusiness>();
			services.AddTransient<RoomBusiness>();
			services.AddTransient<RoomScheduleBuisness>();
			services.AddTransient<MsgBusiness>();
			services.AddTransient<RoomScheduleBusiness>();
			
		}
    }
}

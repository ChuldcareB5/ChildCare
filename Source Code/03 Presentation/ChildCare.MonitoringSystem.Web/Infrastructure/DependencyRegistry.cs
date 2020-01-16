using ChildCare.MonitoringSystem.Business.Infrastructure;
using ChildCare.MonitoringSystem.Common;
using ChildCare.MonitoringSystem.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ChildCare.MonitoringSystem.Web.Infrastructure
{
    public static class DependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appsettings)
        {
            services.AddSingleton(appsettings);
            services.AddScoped<ApplicationContext>();
            BusinessDependencyRegistry.RegisterDependency(services, appsettings);
        }
    }
}

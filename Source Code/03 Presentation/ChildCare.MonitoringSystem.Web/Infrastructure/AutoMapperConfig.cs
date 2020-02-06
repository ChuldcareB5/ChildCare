using AutoMapper;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using System.Linq;

namespace ChildCare.MonitoringSystem.Web.Infrastructure
{
    public static class AutoMapperConfig
    {
        public static void Bootstrap()
        {
            Mapper.Initialize(cfg =>
            {
                // Entity to Model
                cfg.CreateMap<User, UserModel>()
                    .ForMember(x => x.Role, opt => opt.MapFrom(x => new RoleModel() { RoleId = x.UserRole.First().RoleId }));
                cfg.CreateMap<Role, RoleModel>();
				cfg.CreateMap<BusSchedule, BusScheduleModel>()
				 .ForMember(dest => dest.BusName, opt => opt.MapFrom(src => src.Bus.BusName));


				// Model to Entity
				cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<RoleModel, Role>();
				cfg.CreateMap<BusScheduleModel, BusSchedule>();
			});
        }

    }
}

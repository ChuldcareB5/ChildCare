using AutoMapper;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using System.Linq;
using ChildCare.MonitoringSystem.Common.Extensions;

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
                    .ForMember(x => x.Role, opt => opt.MapFrom(x => new RoleModel() { RoleId = x.UserRole.FirstOrDefault() != null ? x.UserRole.First().RoleId : -1 }));
                cfg.CreateMap<Role, RoleModel>();

                cfg.CreateMap<Student, StudentModel>()
                    .ForMember(x => x.Parent, opt => opt.MapFrom(x => x.User.MapTo<UserModel>()));

                cfg.CreateMap<BusSchedule, BusScheduleModel>()
				 .ForMember(dest => dest.BusName, opt => opt.MapFrom(src => src.Bus.BusName));


				// Model to Entity
				cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<RoleModel, Role>();
                cfg.CreateMap<StudentModel, Student>();
                cfg.CreateMap<BusScheduleModel, BusSchedule>();
			});
        }

    }
}

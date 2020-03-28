using ChildCare.MonitoringSystem.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Security.Claims;

namespace ChildCare.MonitoringSystem.Web.Signaling
{
    public abstract class BaseHub : Hub
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BaseHub(ApplicationContext applicationContext, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                applicationContext.UserId = Convert.ToInt32(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }
        }

        public long? UserId
        {
            get
            {
                if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    long userId = 0;

                    Int64.TryParse(httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value, out userId);

                    return userId;
                }

                return null;
            }
        }

        public string Roles
        {
            get
            {
                if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    return httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Role).Value;
                }

                return null;
            }
        }
    }
}

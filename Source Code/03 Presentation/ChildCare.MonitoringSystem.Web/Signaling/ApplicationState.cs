using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Signaling
{
    public sealed class ApplicationState
    {
        public Dictionary<long, AppHubUserState> UserConnectionMap { get; } = new Dictionary<long, AppHubUserState>();
    }
}

using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Signaling.Hubs
{
    public sealed class ChannelState
    {
        public Dictionary<string, ConnectionInfo> Connections { get; } = new Dictionary<string, ConnectionInfo>();

        public void Clear()
        {
            this.Connections.Clear();
        }
    }
}

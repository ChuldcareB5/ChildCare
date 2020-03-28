using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Signaling
{
    public sealed class ChannelState
    {
        /// <summary>
        /// Gets the group connection map. Containing a map of Group Name => [Connection Id => Peer State] map.
        /// </summary>
        public Dictionary<string, Dictionary<string, PeerState>> GroupConnectionMap { get; } = new Dictionary<string, Dictionary<string, PeerState>>();

        public Dictionary<string, ConnectionInfo> ConnectionInfoMap { get; } = new Dictionary<string, ConnectionInfo>();

        public string TeacherConnectionId { get; set; }

        public string CoordinatorConnectionId { get; set; }

        public string Tablet1ConnectionId { get; set; }

        public string Tablet2ConnectionId { get; set; }

        public string ServerConnectionId { get; set; }

        public void Clear()
        {
            this.GroupConnectionMap.Clear();
            this.ConnectionInfoMap.Clear();
            this.TeacherConnectionId = null;
            this.CoordinatorConnectionId = null;
            this.Tablet1ConnectionId = null;
            this.Tablet2ConnectionId = null;
        }
    }
}

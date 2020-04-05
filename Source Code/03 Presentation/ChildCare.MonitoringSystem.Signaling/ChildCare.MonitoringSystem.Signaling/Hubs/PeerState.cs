namespace ChildCare.MonitoringSystem.Signaling.Hubs
{
    public class PeerState
    {
        public string PeerId { get; set; }
        public string Name { get; set; }
        public bool IsAudioEnabled { get; set; }
        public bool IsVideoEnabled { get; set; }
        public bool IsScreenShared { get; set; }
        public bool IsRecording { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Role { get; set; }
        public string InvitedTabletName { get; set; }
    }
}

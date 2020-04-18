using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Signaling.Hubs
{
    public class ChannelHub : Hub
    {
        private readonly ChannelState channelState;

        public ChannelHub(ChannelState channelState)
        {
            this.channelState = channelState;
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            var camDetail = channelState.Connections
                .Select(x => new { CamName = x.Key, x.Value.ConnectionId })
                .FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

            if (channelState.Connections.ContainsKey(camDetail.CamName))
            {
                channelState.Connections.Remove(camDetail.CamName);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public void Join(string camName)
        {
            if (channelState.Connections.ContainsKey(camName))
            {
                throw new Exception("Already joined!");
            }

            if (!channelState.Connections.ContainsKey(camName))
            {
                channelState.Connections.Add(camName, new ConnectionInfo()
                {
                    ConnectionId = Context.ConnectionId
                });
            }
        }

        public async Task ConnectTo(string camName)
        {
            string toConnectionId = null;
            if (channelState.Connections.ContainsKey(camName))
            {
                toConnectionId = channelState.Connections[camName].ConnectionId;
            }

            await Clients.Client(Context.ConnectionId).SendAsync("connect", camName, toConnectionId);
        }

        public async Task AskToSendOffer(string to)
        {
            await Clients.Client(to).SendAsync("sendOffer", Context.ConnectionId);
        }

        public async Task SendOffer(string to, string offerSdp)
        {
            await Clients.Client(to).SendAsync("offer", Context.ConnectionId, offerSdp);
        }

        public async Task SendAnswer(string to, string answerSdp)
        {
            await Clients.Client(to).SendAsync("answer", Context.ConnectionId, answerSdp);
        }

        public async Task SendIceCandidate(string to, string candidate)
        {
            await Clients.Client(to).SendAsync("iceCandidate", Context.ConnectionId, candidate);
        }

        public async Task Disconnect(string to)
        {
            await Clients.Client(to).SendAsync("leave", Context.ConnectionId);
        }
    }
}



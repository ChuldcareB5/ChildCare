using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
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
            var groupName = channelState.ConnectionInfoMap[Context.ConnectionId].GroupName;
            await this.Disconnect(groupName);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task Join(string groupName, PeerState peerState)
        {
            if (channelState.GroupConnectionMap.ContainsKey(groupName) && channelState.GroupConnectionMap[groupName].ContainsKey(Context.ConnectionId))
            {
                throw new Exception("Already joined!");
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            peerState.PeerId = Context.ConnectionId;

            if (!channelState.GroupConnectionMap.ContainsKey(groupName))
            {
                channelState.GroupConnectionMap.Add(groupName, new Dictionary<string, PeerState>()
                {
                    [Context.ConnectionId] = peerState
                });
            }
            else
            {
                channelState.GroupConnectionMap[groupName].Add(Context.ConnectionId, peerState);
            }

            await Clients.Client(Context.ConnectionId).SendAsync("join",
                JsonConvert.SerializeObject(
                    channelState.GroupConnectionMap[groupName]
                    .Where(x => x.Key != Context.ConnectionId).Select(x => x.Value),
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }));
        }

        public async Task InformAvailability(string teacherId, PeerState peerState)
        {
            peerState.PeerId = Context.ConnectionId;
            await Clients.Client(teacherId).SendAsync("tabletjoin", peerState);
        }
        
        public async Task AskToSendOffer(string teacherId, PeerState peerState)
        {
            peerState.PeerId = Context.ConnectionId;
            await Clients.Client(teacherId).SendAsync("sendOfferToTablet", peerState);
        }

        public async Task ServerInformAvailability(string teacherId, PeerState peerState)
        {
            peerState.PeerId = Context.ConnectionId;
            await Clients.Client(teacherId).SendAsync("serverJoin", peerState);
        }

        public async Task ServerAskToSendOffer(string teacherId, PeerState peerState)
        {
            peerState.PeerId = Context.ConnectionId;
            await Clients.Client(teacherId).SendAsync("sendOfferToServer", peerState);
        }

        public async Task InformStopScreenShare(string coordinatorId)
        {
            await Clients.Client(coordinatorId).SendAsync("onStopScreenShare", Context.ConnectionId);
        }

        public async Task BroadcastMessage(string groupName, string message)
        {
            if (channelState.GroupConnectionMap.ContainsKey(groupName) && channelState.GroupConnectionMap[groupName].ContainsKey(Context.ConnectionId))
            {
                await Clients.Group(groupName).SendAsync("receiveMessage", message, Context.ConnectionId);
            }
            else
            {
                throw new Exception("Invalid group name!");
            }
        }

        public async Task StopTablet(string peerId)
        {
            await Clients.Client(peerId).SendAsync("stopTablet", Context.ConnectionId);
        }

        public async Task GetActiveTablet(string peerId)
        {
            await Clients.Client(peerId).SendAsync("getActiveTablet", Context.ConnectionId);
        }

        public async Task SendActiveTablet(string peerId, string activeTablet)
        {
            await Clients.Client(peerId).SendAsync("activeTablet", Context.ConnectionId, activeTablet);
        }
        
        public async Task SendMessage(string to, string message)
        {
            await Clients.Client(to).SendAsync("receivePersonalMessage", message, Context.ConnectionId);
        }

        public async Task SendOffer(string to, string offerSdp, PeerState peerState)
        {
            peerState.PeerId = Context.ConnectionId;
            await Clients.Client(to).SendAsync("offer", Context.ConnectionId, offerSdp, peerState);
        }

        public async Task SendAnswer(string to, string answerSdp)
        {
            await Clients.Client(to).SendAsync("answer", Context.ConnectionId, answerSdp);
        }

        public async Task BroadcastIceCandidate(string groupName, string candidate)
        {
            if (channelState.GroupConnectionMap.ContainsKey(groupName) && channelState.GroupConnectionMap[groupName].ContainsKey(Context.ConnectionId))
            {
                await Clients.Group(groupName).SendAsync("iceCandidate", Context.ConnectionId, candidate);
            }
            else
            {
                throw new Exception("Invalid group name!");
            }
        }

        public async Task BroadcastPeerState(string groupName, PeerState peerState)
        {
            peerState.PeerId = Context.ConnectionId;
            if (channelState.GroupConnectionMap.ContainsKey(groupName) && channelState.GroupConnectionMap[groupName].ContainsKey(Context.ConnectionId))
            {
                channelState.GroupConnectionMap[groupName][Context.ConnectionId] = peerState;
                await Clients.Group(groupName).SendAsync("peerStateChange", peerState);
            }
            else
            {
                throw new Exception("Invalid group name!");
            }
        }

        public async Task Disconnect(string groupName)
        {
            if (channelState.GroupConnectionMap.ContainsKey(groupName) && channelState.GroupConnectionMap[groupName].ContainsKey(Context.ConnectionId))
            {
                channelState.GroupConnectionMap[groupName].Remove(Context.ConnectionId);
                await Clients.Group(groupName).SendAsync("leave", Context.ConnectionId);
            }
            else
            {
                throw new Exception("Invalid group name!");
            }

            if (channelState.GroupConnectionMap[groupName].Count == 0)
            {
                // Remove group and Stop meeting, when all participants left the room.
                channelState.GroupConnectionMap.Remove(groupName);
                channelState.ConnectionInfoMap.Remove(Context.ConnectionId);
            }
        }
    }
}



var isHubReady = false;
var hubInvokeQueue = [];

var pcConfig = {
    iceServers: [{
        url: 'stun:stun.l.google.com:19302'
    }]
};

var peerConfig = {
    onICECandidate: candidate => channelHub.invoke("sendIceCandidate", ChildCare.peerConnectionId, candidate),
    onRemoteTrack: (peerId, actualTransceiver, stream) => {
        console.log("Override this method to add functionality.");
    },
    onRemoteStream: (peerId, stream) => {
        console.log("Override this method to add functionality.");
    },
    onOfferCreation: (peerId, offerSdp) => {
        console.log("Sending offer to: " + peerId);
        channelHub.invoke("sendOffer", peerId, offerSdp);
    }
};

var pm = new PeerManager(pcConfig);
pm.onPeerReady = (state) => console.log("Peer is ready to render!");

let channelHub = new signalR.HubConnectionBuilder().withUrl(ChildCare.urls.signalHostUrl + '/channel').build();
channelHub.invoke = (function (hubInvoke) {
    return function () {
        if (!isHubReady) {
            hubInvokeQueue.push(hubInvoke.bind(channelHub, ...arguments));
        } else {
            hubInvoke.apply(channelHub, arguments);
        }
    };
}(channelHub.invoke));

channelHub.on("iceCandidate", function (from, candidate) {
    pm.queueICECandidate(from, candidate);
});

channelHub.on("sendOffer", function (toConnectionId) {
    ChildCare.peerConnectionId = toConnectionId;
    var peerStates = pm.getPeerStates();

    if (!Object.keys(peerStates).length) {
        pm.init([{ "peerId": toConnectionId }]);
        pm.createPeers(peerConfig);
    } else {
        pm.addPeer(toConnectionId, peerConfig, {});
    }

    pm.addLocalStreamToPeer(ChildCare.localVideo, toConnectionId, true, 'video', ChildCare.mediaName);
});

channelHub.on("answer", function (from, answerSdp) {
    pm.processAnswer(from, answerSdp).then(() => {
        setTimeout(() => {
            pm.processICECandidates(from);
        }, 1000);
    });
});

channelHub.on("leave", function (from) {
    pm.removePeer(from);
    ChildCare.peerConnectionId = null;
});

function join(camName) {
    navigator.mediaDevices.getUserMedia({ audio: true, video: true }).
        then(stream => {
            var $video = $("#cam");
            $video[0].srcObject = new MediaStream();
            stream.getVideoTracks().forEach(track => $video[0].srcObject.addTrack(track, stream));
            channelHub.invoke("join", camName);
            ChildCare.localVideo = stream;
        });
}

function startChannel() {
    channelHub.start().then(() => {
        isHubReady = true;

        // Process the queue.
        while (hubInvokeQueue.length) {
            var hubInvoke = hubInvokeQueue.shift();
            hubInvoke();
        }
    });
}
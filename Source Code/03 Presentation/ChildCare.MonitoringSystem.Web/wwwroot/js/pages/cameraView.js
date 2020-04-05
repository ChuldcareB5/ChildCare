peerConfig.onRemoteTrack = onRemoteTrack;

channelHub.on("connect", function (camName, toConnectionId) {
    if (toConnectionId) {
        ChildCare.peerConnectionId = toConnectionId; 
        pm.init([{ "peerId": toConnectionId }]);
        pm.createPeers(peerConfig);
        pm.createOffer(toConnectionId);
    }
    else {
        alert("The camera is not connected in the room " + camName + ". Please connect and try again.");
    }
});

channelHub.on("answer", function (from, answerSdp) {
    pm.processAnswer(from, answerSdp).then(() => {
        setTimeout(() => {
            pm.processICECandidates(from);
        }, 1000);
    });
});

$(document).ready(function () {
    startChannel();
    registerDomEventHandlers();
});

function registerDomEventHandlers() {
    $("#classA").click(() => {
        channelHub.invoke("connectTo", 'classA');
    });
}

function onRemoteTrack(peerId, transceiver, stream) {
    debugger;
    stream = stream || {};

    let kind = transceiver.receiver.track.kind;

    transceiver.direction = 'sendrecv';
    if (kind == 'audio') {
        transceiver.sender.replaceTrack(app.streams.localVideo1.getAudioTracks()[0]);
    }

    if (kind == 'video') {
        transceiver.sender.replaceTrack(app.streams.localVideo1.getVideoTracks()[0]);
    }

    var $cam = $("#cam");
    if (!$cam[0].srcObject) {
        $cam[0].srcObject = new MediaStream();
    }

    $cam[0].srcObject.addTrack(transceiver.receiver.track, stream);
}
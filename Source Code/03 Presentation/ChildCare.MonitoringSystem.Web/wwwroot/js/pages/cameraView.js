peerConfig.onRemoteTrack = onRemoteTrack;

channelHub.on("connect", function (camName, toConnectionId) {
    if (ChildCare.peerConnectionId) {
        channelHub.invoke("disconnect", ChildCare.peerConnectionId);
        pm.removePeer(ChildCare.peerConnectionId);
        ChildCare.peerConnectionId = null;
    }

    if (toConnectionId) {
        ChildCare.peerConnectionId = toConnectionId; 
        pm.init([{ "peerId": toConnectionId }]);
        pm.createPeers(peerConfig);
        channelHub.invoke("askToSendOffer", toConnectionId);
    }
    else {
        alert("The camera is not connected in the room " + camName + ". Please connect and try again.");
    }
});

channelHub.on("offer", function (from, offerSdp) {
    pm.processOfferSdpAndGenerateAnswer(from, offerSdp).then(answerSdp => {
        console.log("Sending answer to: " + from);
        channelHub.invoke("sendAnswer", from, answerSdp);
        pm.processICECandidates(from);
    });
});

$(document).ready(function () {
    startChannel();
    registerDomEventHandlers();
});

function registerDomEventHandlers() {
    $('select[name="type"]').change(function () {
        if ($(this).val() == 'Class A') {
            channelHub.invoke("connectTo", 'classA');
        }
        if ($(this).val() == 'Class B') {
            channelHub.invoke("connectTo", 'classB');
        }
        if ($(this).val() == 'Class C') {
            channelHub.invoke("connectTo", 'classC');
        }
    });

    //$("#classA").click(() => {
    //    channelHub.invoke("connectTo", 'classA');
    //});

    //$("#classB").click(() => {
    //    channelHub.invoke("connectTo", 'classB');
    //});
}

function onRemoteTrack(peerId, transceiver, stream) {
    var $cam = $("#cam");
    $cam[0].srcObject = new MediaStream();
    $cam[0].srcObject.addTrack(transceiver.receiver.track, stream);
}
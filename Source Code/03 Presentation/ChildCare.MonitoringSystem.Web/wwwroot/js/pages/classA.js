channelHub.on("offer", function (from, offerSdp) {
    ChildCare.peerConnectionId = from; 
    pm.addPeer(from, peerConfig, null);
    pm.addLocalStreamToPeer(ChildCare.localVideo, from, true, 'video', 'classAVideo');
    setTimeout(() => {
        pm.processOfferSdpAndGenerateAnswer(from, offerSdp).then(answerSdp => {
            console.log("Sending answer to: " + from);
            channelHub.invoke("sendAnswer", from, answerSdp);
            pm.processICECandidates(from);
        });
    }, 200);
});

$(document).ready(function () {
    startChannel();
    join(ChildCare.camName);
    registerDomEventHandlers();
});

function registerDomEventHandlers() {

}

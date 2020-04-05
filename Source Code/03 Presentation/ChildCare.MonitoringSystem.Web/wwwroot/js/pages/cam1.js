var isHubReady = false;
var hubInvokeQueue = [];
let channelHub = new signalR.HubConnectionBuilder().withUrl(ChildCare.urls.host + '/channel').build();
channelHub.invoke = (function (hubInvoke) {
    return function () {
        if (!isHubReady) {
            hubInvokeQueue.push(hubInvoke.bind(channelHub, ...arguments));
        } else {
            hubInvoke.apply(channelHub, arguments);
        }
    };
}(channelHub.invoke));

$(document).ready(function () {
    startChannel();
    join();
    registerDomEventHandlers();
});

function registerDomEventHandlers() {

}

function join() {

    navigator.mediaDevices.getUserMedia({ audio: true, video: true }).
        then(stream => {
            var $video = $("#cam");
            $video[0].srcObject = new MediaStream();
            stream.getVideoTracks().forEach(track => $video[0].srcObject.addTrack(track, stream));
            channelHub.invoke("join", '', {});
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
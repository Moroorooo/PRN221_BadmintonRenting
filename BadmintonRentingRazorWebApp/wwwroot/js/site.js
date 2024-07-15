"use strict";
$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();

    connection.start().then(function () {
        console.log("SignalR Connected");
    }).catch(function (err) {
        console.error("SignalR Connection Error: ", err.toString());
    });
    connection.on("LoadCustomer", function () {
        console.log("Received delete signal");
        location.reload();// Tải lại trang hiện tại
    });
});
"use strict";  // Sử dụng chế độ nghiêm ngặt của JavaScript để tránh một số lỗi thường gặp
$(() => {
    // Khởi tạo kết nối với SignalR hub tại địa chỉ '/signalrServer'
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();

    connection.start().then(function () {
        console.log("SignalR Connected");
    }).catch(function (err) {
        console.error("SignalR Connection Error: ", err.toString());
    });
    // Định nghĩa sự kiện khi nhận được tín hiệu 'LoadCustomer' từ server
    connection.on("LoadCustomer", function () {
        console.log("Received delete signal");
        location.reload();// Tải lại trang hiện tại
    });
});
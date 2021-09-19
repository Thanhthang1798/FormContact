# FormContact
Làm 01 form Liên hệ:  
- Sử dụng ajax  
- Sử dụng cookie lưu thông tin, để lần sau ko cần nhập lại (tên, số điện thoại)  
- Chỉ cho phép IP gửi tới đa 5 lần  
- Sử dụng validate ở client &amp; server ( kiểm tra số điện thoại có phải là MobilePhone)

Mô tả chức năng && cách chạy:
+ giao diện: mở file bằng visual code sử dụng extensions Live Server để chạy giao diện
+ server sủ dụng Visual Studio để khởi chạy.
+ Lúc chạy server thì server có link là : https://localhost:44357/
+ Nếu url của server khác  https://localhost:44357/ thì trong file script.js thi update lại url: var url = "{url mới}/api";
+ Trang có 2 tab lúc chạy lên mặc đinh ở tab gửi liên hệ, trang còn lại thì xem được danh sách liên hệ đã gửi(tất cả)

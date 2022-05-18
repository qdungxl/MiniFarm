Phần mềm quản lý Mini Farm - Designed by Dung CDT
# 1. Giới thiệu
Đây là một dự án trong chuỗi tự học lập trình của mình. Trong dự án này mình sử dụng kiến thức liên quan đến vi điều khiển để lấy tín hiệu cảm biến độ ẩm đât, độ ẩm không khí và nhiệt độ không khí.

Lập trình cho con chíp atm328 để lấy dự liệu cảm biến, điều khiển bật/tắt các động cơ qua relay và giao tiếp với winform thông qua chuẩn UART để đưa dữ liệu lên winform cũng như nhận chỉ thị từ winform truyền xuống.

Lập trình giao diện trên máy tính bằng C Sharp winform để tương tác với người quản lý, winfrom sẽ lấy dữ liệu câm biến từ arduino, sau đó ghi xuống SQL để sử dụng cho việc phân tính, báo cáo sau đó
# 2. Mô tả cách vận hành của dự án.
MiniFarm được mô phỏng trên proteus như sau.
![image](https://user-images.githubusercontent.com/94212972/168976843-366737d5-6598-4d03-baad-52b86f1719c2.png)
Input gồm 4 cụm cảm biến, mỗi cụm là 1 cảm biến DHT11 để lấy độ ẩm không khí và nhiệt độ không khí, một cảm biến độ ẩm đất (ở đây được thay bằng biến trở).

Output là relay điều khiển 4 động cơ để bơm nước phum nước và quạt hút để quản lý các chỉ tiêu trong farm.

Lưu ý: Trong thực tế để đảm bảo độ chính xác cảm biến nên tách 4 cụm cảm biến ra 4 vi điều khiển quản lý riêng biệt và giao tiếp với nhau qua chuẩn I2C. Và sẽ có 1 master để giao tiếp với winform.
Code Arduino được viêt trên VS Code: theo tác giả thì phần mềm này dễ sử dụng do có nhắc lệnh

Winform được thiết kế như sau:
![image](https://user-images.githubusercontent.com/94212972/168977713-40825637-7528-4843-9fb8-8da223564019.png)

Đây là là hình đăng nhập để quản lý người đăng nhập là nhân viên hay ad, dữ liệu đăng nhập sẽ được so sánh với dữ liệu đã lưu trong SQL.
Sau khi đăng nhập người dùng khởi động hệ thống, hệ thống mặc định ở chế độ manual.
![image](https://user-images.githubusercontent.com/94212972/168978478-88578656-d2fd-4ad4-b13f-0f4d4ef350de.png)

Ở chế độ Manu người dùng phải tự chọn cổng COM, tốc độ BaundRate và chon kết nối. Nếu kết nối thành công label trạng thái sẽ báo. Sau khi kết nối thành công chương trình sẽ đọc định kỳ dữ liệu cảm biến từ arduino, sau đó hiển thị lên listView và đưa ra khuyến nghị khi thông số môi trường bất lợi. Người dùng sẽ quyết định nên hay không bật các động cơ.

Ở chế độ Auto chương trình tự động kết nối với arduino, lấy giá trị cảm biến và tự động tìm gửi lệnh điều khiển động cơ.
SQL Ser gồm 2 bảng:
![image](https://user-images.githubusercontent.com/94212972/168984584-55cb0580-2c63-43e1-8242-80519d144fff.png)
Bảng Login để lưu thông tin đăng nhập.
Bảng Sensor lưu giá trị cảm biến.


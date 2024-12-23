CREATE DATABASE QuanLyBanSachh;
GO
USE QuanLyBanSachh;
GO

CREATE TABLE NGUOIDUNG(
	ten nvarchar (30) primary key not null,
	matKhau varchar (50) not null,
	quyen tinyint
)
GO
CREATE TABLE NHACUNGCAP(
	maNCC nvarchar (6) primary key not null,
	tenNCC nvarchar (50) not null
)
GO
CREATE TABLE NHANVIEN(
	maNV nvarchar (6) primary key not null,
	tenNV nvarchar (50) not null,
	gioiTinh nvarchar (5) default N'Nam',
	ngaySinh datetime,
	diaChi nvarchar(70),
	dienThoai int
)
GO
CREATE TABLE THELOAI(
	maTL nvarchar (6) primary key not null,
	tenTL nvarchar (50)
)
GO
CREATE TABLE NXB(
	maNXB nvarchar (6) primary key not null,
	tenNXB nvarchar (50)
)
GO
CREATE TABLE TACGIA(
	maTG nvarchar (6) primary key not null,
	tenTG nvarchar (50)
)
GO
CREATE TABLE SACH(
	maSach nvarchar (6) primary key not null,
	tenSach nvarchar (50) not null,
	maTG nvarchar (6) foreign key (maTG) references TACGIA(maTG),
	maTL nvarchar (6) foreign key (maTL) references THELOAI(maTL),
	maNXB nvarchar (6) foreign key (maNXB) references NXB(maNXB),
	giaNhap int,
	giaBan int,
	soLuong int, 
)
GO
CREATE TABLE HDNHAP(
	soHD nvarchar (6) primary key not null,
	maNV nvarchar (6) foreign key (maNV) references NHANVIEN(maNV) not null,
	ngayNhap datetime,
	maNCC nvarchar (6) foreign key (maNCC) references NHACUNGCAP(maNCC),
	giaNhap int
)
GO
CREATE TABLE CHITIETHDN(
	soHD nvarchar (6) not null,
	maSach nvarchar (6) not null,
	tenSach nvarchar (50),
	slNhap int,
	primary key(soHD, maSach),
	foreign key (soHD) references HDNHAP(soHD),
	foreign key (maSach) references SACH(maSach)
)
GO
CREATE TABLE KHACHHANG(
	maKH nvarchar (6) primary key not null,
	tenKH nvarchar (50) not null,
	diaChi nvarchar(70),
	dienThoai int
)
GO
CREATE TABLE HDBAN(
	soHDB nvarchar (6) primary key not null,
	maNV nvarchar (6) foreign key (maNV) references NHANVIEN(maNV) not null,
	maKH nvarchar(6) foreign key (maKH) references KHACHHANG(maKH) not null,
	ngayBan datetime,
)
GO
CREATE TABLE CTHDBAN(
	soHDB nvarchar (6),
	maSach nvarchar (6),
	tenSach nvarchar (50),
	donGia int,
	soLuong int,
	thanhTien int
	primary key (SoHDB, MaSach),
	foreign key (soHDB) references HDBAN(soHDB),
	foreign key (maSach) references SACH(maSach)
)
GO
CREATE TABLE DOANHTHU(
	maSach nvarchar (6) foreign key (maSach) references SACH(maSach),
	tenSach nvarchar (50),
	gianNhap int,
	giaBan int,
	soLuongBan int,
	ngayBan datetime,
	doanhThu int
)
GO

-- Dữ liệu bảng nguoidung
INSERT INTO NGUOIDUNG VALUES(N'Admin','e99a18c428cb38d5f260853678922e03',1);/* Mật khẩu abc123 */
INSERT INTO NGUOIDUNG VALUES(N'User','a906449d5769fa7361d7ecc6aa3f6d28',2);	/* Mật khẩu 123abc */
GO

-- Dữ liệu bảng nhacungcap
INSERT INTO NHACUNGCAP VALUES(N'NCC01', N'Công ty sách CDIMEX');
INSERT INTO NHACUNGCAP VALUES(N'NCC02', N'Nhà sách Tân Việt');
INSERT INTO NHACUNGCAP VALUES(N'NCC03', N'Phương Nam Book');
GO

-- Dữ liệu bảng nhanvien
INSERT INTO NHANVIEN VALUES(N'NV01', N'Nguyễn Văn C', N'Nam','1-2-2001', N'19 Ung Văn Khiêm', '0123458796');
INSERT INTO NHANVIEN VALUES(N'NV02', N'Trần Văn A', N'Nam', '4-5-2000', N'178 Hà Hoàng Hổ', '0245687425');
GO

-- Dữ liệu bảng theloai
INSERT INTO THELOAI VALUES(N'TL01', N'Tiểu thuyết');
INSERT INTO THELOAI VALUES(N'TL02', N'Truyện tranh');
INSERT INTO THELOAI VALUES(N'TL03', N'Kinh dị');
GO

-- Dữ liệu bảng NXB
INSERT INTO NXB VALUES(N'NXB01', N'Nhà xuất bản Trẻ');
INSERT INTO NXB VALUES(N'NXB02', N'Nhà xuất bản Kim Đồng');
INSERT INTO NXB VALUES(N'NXB03', N'Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh');
GO

-- Dữ liệu bảng tacgia
INSERT INTO TACGIA VALUES(N'TG01', N'Nguyễn Văn A');
INSERT INTO TACGIA VALUES(N'TG02', N'Cao Thị B');
INSERT INTO TACGIA VALUES(N'TG03', N'Trần Thái C');
GO

-- Dữ liệu bảng sach
INSERT INTO SACH VALUES(N'SA01', N'Ác mộng kinh hoàng', N'TG01', N'TL03', N'NXB01', '30000', '40000', '20');
INSERT INTO SACH VALUES(N'SA02', N'Shin - Cậu bé bút chì', N'TG02', N'TL02', N'NXB03', '35000', '45000', '15');
INSERT INTO SACH VALUES(N'SA03', N'Ông già và biển cả', N'TG03', N'TL01', N'NXB02', '50000', '60000', '5');
INSERT INTO SACH VALUES(N'SA04', N'Không gia đình', N'TG03', N'TL01', N'NXB01', '45000', '55000', '11');
INSERT INTO SACH VALUES(N'SA05', N'Âm thanh và cuồn nộ', N'TG02', N'TL01', N'NXB03', '47000', '57000', '9');
GO

-- Dữ liệu bảng hdnhap
INSERT INTO HDNHAP VALUES(N'HDN02', N'NV02', '2-6-2022', 'NCC01', '30000');
INSERT INTO HDNHAP VALUES(N'HDN03', N'NV01', '1-8-2022', 'NCC03', '25000');
INSERT INTO HDNHAP VALUES(N'HDN01', N'NV01', '5-7-2022', 'NCC02', '45000');
GO

-- Dữ liệu bảng cthdnhap
INSERT INTO CHITIETHDN VALUES(N'HDN01', N'SA01', N'Ác mộng kinh hoàng', '20' );
INSERT INTO CHITIETHDN VALUES(N'HDN02', N'SA02', N'Shin - Cậu bé bút chì', '15');
INSERT INTO CHITIETHDN VALUES(N'HDN03', N'SA03', N'Ông già và biển cả', '15');
GO

-- Dữ liệu bảng khachhang
INSERT INTO KHACHHANG VALUES(N'KH01', N'Đặng Quang K', N'21 Bùi Văn Danh, An Giang', '0123456987');
INSERT INTO KHACHHANG VALUES(N'KH02', N'Nguyễn Xuân B', N'64 Hà Hoàng Hổ, An Giang', '0231456798');
GO

-- Dữ liệu bảng hdban
INSERT INTO HDBAN VALUES(N'HDB01', N'NV02',  N'KH02', '2-6-2022');
INSERT INTO HDBAN VALUES(N'HDB02', N'NV01', N'KH01', '2-6-2022');
GO

-- Dữ liệu bảng cthdban
INSERT INTO CTHDBAN VALUES(N'HDB01', N'SA02',  N'Shin - Cậu bé bút chì', '45000', '1', '45000');
INSERT INTO CTHDBAN VALUES(N'HDB02', N'SA03', N'Ông già và biển cả', '60000', '2', '120000');
GO

-- Dữ liệu bảng doanhthu
INSERT INTO DOANHTHU VALUES(N'SA02', N'Shin - Cậu bé bút chì', '35000', '45000', '1', '11-04-2022', '10000');
INSERT INTO DOANHTHU VALUES(N'SA03', N'Ông già và biển cả', '50000', '60000', '2', '12-4-2022', '20000');
GO

drop table NGUOIDUNG;
drop table HDNHAP;
drop table CTHDBAN;
select * from KHACHHANG;
select * from SACH;
select * from HDNHAP;
select * from CHITIETHDN;
select * from CHITIETHDN

select *, sach.soluong from chitiethdn, sach where sach.masach = chitiethdn.masach
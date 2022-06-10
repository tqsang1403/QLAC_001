drop database QuanLiCaAn
create database QuanLiCaAn

use QuanLiCaAn
go
create table PhongBan(
	
	ID  int identity(1,1) not null primary key,
	TenPB Nvarchar(30) not null,
)

create table NhanVien(
	
	ID int identity(1,1) not null primary key,
	HoTen NVarChar(30)not null,
	GioiTinh bit default 1 not null,
	DiaChi NVarchar(20) not null,
	SDT NText not null,
	IDPhongBan int not null foreign key references PhongBan(ID),
	ChucVu nvarchar(10) not null,
	IDRole int not null foreign key references Roles(ID),
	username char(10) not null,
	upassword char(10) not null,
	trangthai bit default 1 not null
	

)
ALTER TABLE NhanVien
ADD PhanQuyen bit not null;
create table Roles(
	ID int identity(1,1) not null primary key,
	URole Nvarchar(25) not null,
)


--drop table CaAn
--create table TaiKhoan(
--	STT int identity(1,1) primary key,
--	ID char(10) not null foreign key references NhanVien(ID),
	
--	trangthai bit default 1

--)
create table CaAn(
	
	ID int identity(1,1) not null primary key,
	Thoigian datetime not null

)

create table SuatAn(
	ID int identity(1,1) not null primary key,
	-- người đăng kí suất ăn 
	IDUser int foreign key references NhanVien(ID),
	Thoigiandat datetime not null,
	Loaisuatan bit not null -- 0 là đăng kí cá nhân , 1 là đăng kí tập thế

)

create table ChiTietSuatAn(
	ID int identity(1,1) not null primary key,
	-- người dùng ở đây có 2 trường hợp : 1 chính là người đã đăng kí suất ăn  hoặc là người nhờ đăng kí hộ
	IDUser int not null foreign key references NhanVien(ID), 
	Soluong int not null,
	IDSuatAn int foreign key references SuatAn(ID),
	IDCaan int not null foreign key references CaAn(ID),
	Thoigiancapnhat datetime not null,
	Tennhanviencapnhat nvarchar(30) not null
)



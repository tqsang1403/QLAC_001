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
	IDUser int foreign key references NhanVien(ID),	
	Thoigiandat datetime not null

)
	create table ChiTietSuatAn(
		ID int identity(1,1) not null primary key,
		IDUser int not null foreign key references NhanVien(ID),
		Soluong int not null,
		IDSuatAn int foreign key references SuatAn(ID),
		IDCaan int not null foreign key references CaAn(ID),
		Thoigiandat datetime not null
	
	)



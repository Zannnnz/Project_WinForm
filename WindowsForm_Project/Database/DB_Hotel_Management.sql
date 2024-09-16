use master
GO
IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'Hotel_Management')
	DROP DATABASE Hotel_Management
GO
CREATE DATABASE Hotel_Management
GO
USE Hotel_Management
GO
CREATE TABLE Room (
	maphong INT PRIMARY KEY,
	roomnumber INT NOT NULL,
	roomtype NVARCHAR(200) NOT NULL CHECK (roomtype IN ('STD', 'SUP', 'DLX', 'SUT')),
	numbed INT NOT NULL,
	date_ci DATETIME NOT NULL,
	date_co DATETIME,
	price INT NOT NULL CHECK (price > 0),
)
GO
CREATE TABLE Other_detail (
	maphong INT,
	status_room NVARCHAR(200) NOT NULL CHECK(status_room IN ('Reserved', 'Occupied', 'Available', 'Check Out')),
	house_keeping NVARCHAR(200) NOT NULL CHECK(house_keeping IN ('Clean', 'Not Clean', 'In Progress', 'Repair')),
	view_room NVARCHAR(200) NOT NULL CHECK(view_room IN ('Simple', 'Good', 'Beautiful')),
	group_customer INT DEFAULT 0,
	PRIMARY KEY (maphong),
	FOREIGN KEY (maphong) REFERENCES Room(maphong) ON UPDATE CASCADE ON DELETE CASCADE,
)
GO
CREATE TABLE Customer (
	cccd_cus NVARCHAR(200) PRIMARY KEY,
	first_name NVARCHAR(200) NOT NULL,
	last_name NVARCHAR(200) NOT NULL,
	sdt NVARCHAR(200) NOT NULL,
	email NVARCHAR(200) NOT NULL,
	gioitinh NVARCHAR(200) CHECK (gioitinh IN ('Nam', 'Nu')),
	ngaysinh DATETIME CHECK (DATEDIFF(y, ngaysinh, GETDATE()) >= 18),
)
GO
CREATE TABLE Employee (
	cccd_em NVARCHAR(200) PRIMARY KEY,
	first_name NVARCHAR(200) NOT NULL,
	last_name NVARCHAR(200) NOT NULL,
	sdt NVARCHAR(200) NOT NULL,
	email NVARCHAR(200) NOT NULL,
	gioitinh NVARCHAR(200) CHECK (gioitinh IN ('Nam', 'Nu')),
	ngaysinh DATETIME CHECK (DATEDIFF(y, ngaysinh, GETDATE()) >= 18),
	luong NVARCHAR(200) CHECK (luong > 0),
)
GO
CREATE TABLE Report (
	cccd_cus NVARCHAR(200),
	maphong INT,
	ghichu NTEXT,
	PRIMARY KEY (cccd_cus, maphong),
	FOREIGN KEY (cccd_cus) REFERENCES Customer(cccd_cus) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (maphong) REFERENCES Room(maphong) ON UPDATE CASCADE ON DELETE CASCADE,
)
GO
CREATE TABLE Serve (
	cccd_cus NVARCHAR(200),
	maphong INT,
	other_booking NVARCHAR(200),
	anuong NVARCHAR(200),
	call_serve BIT,
	cccd_em NVARCHAR(200),
	PRIMARY KEY (cccd_cus, maphong),
	FOREIGN KEY (cccd_cus) REFERENCES Customer(cccd_cus) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (maphong) REFERENCES Room(maphong) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (cccd_em) REFERENCES Employee(cccd_em) ON UPDATE CASCADE ON DELETE CASCADE,
)
GO
CREATE OR ALTER PROC sp_addroom @maphong INT, @roomnumber INT, @roomtype NVARCHAR(200), @numbed INT, @date_ci DATETIME, @date_co DATETIME, @price INT, @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
	IF NOT EXISTS (	SELECT 1 FROM Room
					WHERE maphong = @maphong)
	BEGIN
		INSERT INTO Room(maphong, roomnumber, roomtype, numbed, date_ci, date_co, price) VALUES (@maphong, @roomnumber, @roomtype, @numbed, @date_ci, @date_co, @price)
		SET @ErrorMessage = 'Them phong thanh cong'
	END
	ELSE
	BEGIN
		SET @ErrorMessage = 'Them phong khong thanh cong'
	END
END
GO
CREATE OR ALTER PROC sp_deleteroom @maphong INT, @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
	IF EXISTS (	SELECT 1 FROM Room
				WHERE maphong = @maphong)
	BEGIN
		DELETE FROM Room WHERE maphong = @maphong
		SET @ErrorMessage = 'Da xoa phong thanh cong'
	END
	ELSE
	BEGIN
		SET @ErrorMessage = 'Xoa Phong khong thanh cong'
	END
END
GO
CREATE OR ALTER PROC sp_updateroom @maphong INT = NULL, @roomnumber INT = NULL, @roomtype NVARCHAR(200) = NULL, @numbed INT = NULL, @date_ci DATETIME = NULL, @date_co DATETIME = NULL, @price INT = NULL, @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN 
	BEGIN TRY
		UPDATE Room
		SET
			maphong = COALESCE(@maphong, maphong),
			roomnumber = COALESCE(@roomnumber, roomnumber),
			roomtype = COALESCE(@roomtype, roomtype),
			numbed = COALESCE(@numbed, numbed),
			date_ci = COALESCE(@date_ci, date_ci),
			date_co = COALESCE(@date_co, date_co),
			price = COALESCE(@price, price)
		WHERE maphong = @maphong;

		SET @ErrorMessage = 'Update successful'
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE();
	END CATCH
END
GO
CREATE OR ALTER PROC sp_addcustomer @cccd_cus NVARCHAR(200), @first_name NVARCHAR(200), @last_name NVARCHAR(200), @sdt NVARCHAR(200), @email NVARCHAR(200), @gioitinh NVARCHAR(200), @ngaysinh DATETIME, @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
	IF NOT EXISTS (	SELECT 1 FROM Customer
					WHERE cccd_cus = @cccd_cus)
	BEGIN
		INSERT INTO Customer(cccd_cus, first_name, last_name, sdt, email, gioitinh, ngaysinh) VALUES (@cccd_cus, @first_name, @last_name, @sdt, @email, @gioitinh, @ngaysinh)
		SET @ErrorMessage = 'Them customer thanh cong'
	END
	ELSE
	BEGIN
		SET @ErrorMessage = 'Them customer khong thanh cong'
	END
END
GO
CREATE OR ALTER PROC sp_updatecustomer @cccd_cus NVARCHAR(200) = NULL, @first_name NVARCHAR(200) = NULL, @last_name NVARCHAR(200) = NULL, @sdt NVARCHAR(200) = NULL, @email NVARCHAR(200) = NULL, @gioitinh NVARCHAR(200) = NULL, @ngaysinh DATETIME = NULL, @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
	BEGIN TRY
		UPDATE Customer
		SET
			cccd_cus = COALESCE(@cccd_cus, cccd_cus),
			first_name = COALESCE(@first_name, first_name),
			last_name = COALESCE(@last_name, last_name), 
			sdt = COALESCE(@sdt, sdt),
			email = COALESCE(@email, email), 
			gioitinh = COALESCE(@gioitinh, gioitinh),
			ngaysinh = COALESCE(@ngaysinh, ngaysinh)
		WHERE cccd_cus = @cccd_cus;

		SET @ErrorMessage = 'Update Successful'
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE();
	END CATCH
END
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
	price INT NOT NULL CHECK (price > 0),
	status_room NVARCHAR(200) NOT NULL CHECK(status_room IN ('Reserved', 'Occupied', 'Available', 'Check Out')),
	house_keeping NVARCHAR(200) NOT NULL CHECK(house_keeping IN ('Clean', 'Not Clean', 'In Progress', 'Repair')),
)
GO
CREATE OR ALTER PROC sp_addroom @maphong INT, @roomnumber INT, @roomtype NVARCHAR(200), @numbed INT, @price INT, @status_room NVARCHAR(200), @house_keeping NVARCHAR(200), @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
	IF NOT EXISTS (	SELECT 1 FROM Room
					WHERE maphong = @maphong)
	BEGIN
		INSERT INTO Room(maphong, roomnumber, roomtype, numbed, price, status_room, house_keeping) VALUES (@maphong, @roomnumber, @roomtype, @numbed, @price, @status_room, @house_keeping)
		SET @ErrorMessage = 'Them phong thanh cong'
	END
	ELSE
	BEGIN
		SET @ErrorMessage = 'Phong da ton tai'
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
CREATE OR ALTER PROC sp_updateroom @maphong INT = NULL, @roomnumber INT = NULL, @roomtype NVARCHAR(200) = NULL, @numbed INT = NULL, @price INT = NULL, @status_room NVARCHAR(200) = NULL, @house_keeping NVARCHAR(200) = NULL, @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN 
	BEGIN TRY
		UPDATE Room
		SET
			maphong = COALESCE(@maphong, maphong),
			roomnumber = COALESCE(@roomnumber, roomnumber),
			roomtype = COALESCE(@roomtype, roomtype),
			numbed = COALESCE(@numbed, numbed),
			price = COALESCE(@price, price),
			status_room = COALESCE(@status_room, status_room),
			house_keeping = COALESCE(@house_keeping, house_keeping)
		WHERE maphong = @maphong;

		SET @ErrorMessage = 'Update successful'
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE();
	END CATCH
END


SELECT *
FROM Room
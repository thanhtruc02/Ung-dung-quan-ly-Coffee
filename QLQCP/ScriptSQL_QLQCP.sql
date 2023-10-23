use QLCaPhe
GO

CREATE TABLE BAN
(
	MaB int identity primary key,
	TenB nvarchar(100) not null DEFAULT N'Ban chua co ten',
	Trangthai nvarchar(100) not null DEFAULT N'Trong' --Có người hoặc Trống
)
GO

CREATE TABLE TAIKHOAN
(
	TenUser nvarchar(100) primary key,
	TenTK nvarchar(100) not null DEFAULT N'Abcd',
	Matkhau nvarchar (1000) not null DEFAULT 0,
	LoaiTK int not null DEFAULT 0 --1: chủ  0: nhân viên
)
GO

CREATE TABLE LOAITHUCUONG
(
	MaLoaiTU int identity primary key,
	TenLoaiTU nvarchar(100) not null DEFAULT N'Chua dat ten'
)

CREATE TABLE THUCUONG
(
	MaTU int identity primary key,
	TenTU nvarchar(100) not null DEFAULT N'Chua dat ten',
	MaLoaiTU int not null,
	Gia float not null DEFAULT 0

	FOREIGN KEY (MaLoaiTU) REFERENCES dbo.LOAITHUCUONG(MaLoaiTU)
)

CREATE TABLE HOADON
(
	MaHD int identity primary key,
	CheckIn date not null DEFAULT GETDATE(),
	CheckOut date,
	MaB int not null,
	Trangthai int not null DEFAULT 0 --1: da thanh toan 0: chua thanh toan

	FOREIGN KEY (MaB) REFERENCES dbo.BAN (MaB)
)
GO

CREATE TABLE CHITIETHOADON
(
	MaCTHD int identity primary key,
	MaHD int not null,
	MaTU int not null,
	Soluong int not null DEFAULT 0

	FOREIGN KEY (MaHD) REFERENCES dbo.HOADON (MaHD),
	FOREIGN KEY (MaTU) REFERENCES dbo.THUCUONG (MaTU)
)
GO

use QLCaPhe
INSERT INTO dbo.TAIKHOAN
			(TenUser,
			TenTK,
			Matkhau,
			LoaiTK)
VALUES (N'chuppa',
		N'Truc',
		N'123A',
		1)

INSERT INTO dbo.TAIKHOAN
			(TenUser,
			TenTK,
			Matkhau,
			LoaiTK)
VALUES (N'allo',
		N'Thanh',
		N'123',
		0)

DECLARE @i INT = 0
WHILE @i <= 10
BEGIN
	INSERT dbo.BAN (TenB) VALUES (N'Ban  ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
UPDATE BAN SET Trangthai = N'Co nguoi' WHERE MaB = 9 OR MaB = 3;

SELECT * FROM BAN
GO

--them PHANLOAI
INSERT dbo.LOAITHUCUONG (TenLoaiTU) VALUES (N'Sinh To')
INSERT dbo.LOAITHUCUONG (TenLoaiTU) VALUES (N'Nuoc ep')
INSERT dbo.LOAITHUCUONG (TenLoaiTU) VALUES (N'Ca phe')
INSERT dbo.LOAITHUCUONG (TenLoaiTU) VALUES (N'Tra')
INSERT dbo.LOAITHUCUONG (TenLoaiTU) VALUES (N'Banh ngot')

--them THUCUONG
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Sinh To Dau', 1, 25000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Sinh To Sapoche', 1, 25000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Sinh To Mang Cau', 1, 25000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Sinh To Bo', 1, 25000)

INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Nuoc ep Tao', 2, 20000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Nuoc ep Thom', 2, 20000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Nuoc ep Dua hau', 2, 20000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Nuoc ep Ca rot', 2, 20000)

INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Ca phe den nong', 3, 18000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Ca phe den da', 3, 18000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Ca phe sua', 3, 20000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Bac siu', 3, 20000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Ca phe trung', 3, 25000)

INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Tra chanh', 4, 15000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Tra dao cam sa', 4, 25000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Tra luu', 4, 25000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Hong tra mat ong', 4, 20000)

INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Banh tiramisu', 5, 35000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Banh sung trau', 5, 25000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Pana Cotta ', 5, 20000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Banh tart trung', 5, 20000)
INSERT dbo.THUCUONG(TenTU, MaLoaiTU, Gia) VALUES (N'Banh tiramisu socola', 5, 35000)
SELECT * FROM THUCUONG

INSERT dbo.HOADON(CheckIn, CheckOut, MaB, Trangthai) VALUES (GETDATE(), NULL, 1, 0)
INSERT dbo.HOADON(CheckIn, CheckOut, MaB, Trangthai) VALUES (GETDATE(), NULL, 2, 0)
INSERT dbo.HOADON(CheckIn, CheckOut, MaB, Trangthai) VALUES (GETDATE(), NULL, 6, 1)
INSERT dbo.HOADON(CheckIn, CheckOut, MaB, Trangthai) VALUES (GETDATE(), NULL, 3, 1)
INSERT dbo.HOADON(CheckIn, CheckOut, MaB, Trangthai) VALUES (GETDATE(), NULL, 5, 0)
INSERT dbo.HOADON(CheckIn, CheckOut, MaB, Trangthai) VALUES (GETDATE(), NULL, 4, 1)

SELECT * FROM HOADON

INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (1, 5, 1)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (1, 8, 1)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (1, 8, 2)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (2, 1, 1)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (2, 11, 1)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (3, 20, 2)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (3, 1, 1)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (4, 17, 1)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (4, 2, 3)
INSERT dbo.CHITIETHOADON(MaHD, MaTU, Soluong) VALUES (5, 10, 2)

SELECT * FROM CHITIETHOADON


GO

CREATE PROCEDURE TAIKHOAN_TenUser
@ten nvarchar  (100)
AS
BEGIN
	SELECT * FROM dbo.TAIKHOAN WHERE TenUser= @ten
END

GO

CREATE PROCEDURE DANGNHAP
@ten nvarchar(100), @mk nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.TAIKHOAN WHERE TenUser = @ten AND Matkhau = @mk
END
GO

CREATE PROCEDURE DANHSACHBAN
AS SELECT * FROM dbo.BAN
GO

use QLCaPhe
GO
SELECT * FROM dbo.CHITIETHOADON WHERE MaHD = 6
SELECT * FROM dbo.HOADON 


SELECT t.TenTU, c.Soluong, t.Gia, t.Gia*c.Soluong AS Tongtien
FROM dbo.CHITIETHOADON c, dbo.HOADON h, dbo.THUCUONG t
WHERE c.MaHD = h.MaHD
AND c.MaTU = t.MaTU
AND h.MaB = 3
AND h.Trangthai = 0
GO
CREATE PROCEDURE THEMHOADON
@maB int
AS
BEGIN
	INSERT dbo.HOADON
		(CheckIn, CheckOut, MaB, Trangthai) 
	VALUES
		(GETDATE(), NULL, @maB, 0)
END
GO

CREATE PROCEDURE THEMCTHD
@maHD int, @maTU int, @soluong int
AS
BEGIN
	INSERT dbo.CHITIETHOADON
		(MaHD, MaTU, Soluong) 
	VALUES (@maHD, @maTU, @soluong)
END
GO

SELECT MAX(MaHD) FROM dbo.HOADON
GO

ALTER PROCEDURE THEMCTHD
@maHD int, @maTU int, @soluong int
AS
BEGIN
	DECLARE @isCoCTHD int;
	DECLARE @soluongmon int = 1;

	SELECT @isCoCTHD = MaCTHD, @soluongmon = c.Soluong 
	FROM dbo.CHITIETHOADON c WHERE MaHD = @maHD
	AND MaTU = @maTU;

	IF(@isCoCTHD > 0)
	BEGIN
		DECLARE @soluongmoi int = @soluongmon + @soluong
		IF (@soluongmoi >0)
			UPDATE dbo.CHITIETHOADON SET Soluong = @soluongmon + @soluong WHERE MaTU = @maTU
		ELSE
			DELETE dbo.CHITIETHOADON WHERE MaHD = @maHD AND MaTU = @maTU
	END
	ELSE 
	BEGIN
		INSERT dbo.CHITIETHOADON
			(MaHD, MaTU, Soluong) 
		VALUES (@maHD, @maTU, @soluong)
	END
	
END
GO

UPDATE dbo.HOADON SET Trangthai = 1 WHERE MaHD = 1
GO

CREATE TRIGGER CAPNHAT_CTHD
ON dbo.CHITIETHOADON FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @maHD int

	SELECT @maHD = MaHD FROM inserted

	DECLARE @maB int

	SELECT @maB = MaB FROM dbo.HOADON WHERE MaHD = @maHD AND Trangthai = 0

	UPDATE dbo.BAN SET Trangthai = N'Co nguoi' WHERE MaB = @maB
END
GO

CREATE TRIGGER CAPNHAT_HD
ON dbo.HOADON FOR UPDATE
AS
BEGIN
	
	DECLARE @maHD int

	SELECT @maHD = MaHD FROM inserted

	DECLARE @maB int

	SELECT @maB = MaB FROM dbo.HOADON WHERE MaHD = @maHD 

	DECLARE @soluong int = 0;
	
	SELECT @soluong = COUNT(*) FROM dbo.HOADON WHERE MaB = @maB AND Trangthai = 0

	if(@soluong = 0)
		UPDATE dbo.BAN SET Trangthai = N'Trong'
END
GO

ALTER TRIGGER CAPNHAT_HD
ON dbo.HOADON FOR UPDATE
AS
BEGIN
	
	DECLARE @maHD int

	SELECT @maHD = MaHD FROM inserted

	DECLARE @maB int

	SELECT @maB = MaB FROM dbo.HOADON WHERE MaHD = @maHD 

	DECLARE @soluong int = 0;
	
	SELECT @soluong = COUNT(*) FROM dbo.HOADON WHERE MaB = @maB AND Trangthai = 0

	if(@soluong = 0)
		UPDATE dbo.BAN SET Trangthai = N'Trong' WHERE MaB = @maB
END
GO

DELETE dbo.CHITIETHOADON

DELETE dbo.HOADON

ALTER TABLE dbo.HOADON
ADD Discount int

UPDATE HOADON SET Discount = 0
GO
use QLCaPhe
GO
ALTER PROCEDURE THEMHOADON
@maB int
AS
BEGIN
	INSERT dbo.HOADON
		(CheckIn, CheckOut, MaB, Trangthai, Discount) 
	VALUES
		(GETDATE(), NULL, @maB, 0, 0)
END
GO

use QLCaPhe
GO
ALTER PROCEDURE CHUYENBAN
 @maB1 int, @maB2 int
AS
BEGIN
	DECLARE @maHD1 int
	DECLARE @maHD2 int

	DECLARE @ismaB1Trong int = 1
	DECLARE @ismaB2Trong int = 1

	SELECT @maHD2 = MaHD FROM dbo.HOADON WHERE MaB = @maB2 AND Trangthai = 0
	SELECT @maHD1 = MaHD FROM dbo.HOADON WHERE MaB = @maB1 AND Trangthai = 0

	IF  (@maHD1 is NULL)
	BEGIN
		INSERT INTO dbo.HOADON 
				(CheckIn, CheckOut,MaB, Trangthai, Discount)
		VALUES (GETDATE(), NULL, @maB1, 0, 0)

		SELECT @maHD1 = MAX(MaHD) FROM dbo.HOADON WHERE MaB = @maB1 AND Trangthai = 0
	END

	SELECT @ismaB1Trong = COUNT (*) FROM dbo.CHITIETHOADON WHERE MaHD = @maHD1

	IF  (@maHD2 is NULL)
	BEGIN
		INSERT INTO dbo.HOADON 
				(CheckIn, CheckOut,MaB, Trangthai, Discount)
		VALUES (GETDATE(), NULL, @maB2, 0, 0)

		SELECT @maHD2 = MAX(MaHD) FROM dbo.HOADON WHERE MaB = @maB2 AND Trangthai = 0

	END

	SELECT @ismaB2Trong = COUNT (*) FROM dbo.CHITIETHOADON WHERE MaHD = @maHD2

	SELECT MaCTHD INTO MAHD_THONGTINBAN FROM dbo.CHITIETHOADON WHERE MaHD = @maHD2

	UPDATE dbo.CHITIETHOADON SET MaHD = @maHD2 WHERE MaHD = @maHD1

	UPDATE dbo.CHITIETHOADON SET MaHD = @maHD1 WHERE MACTHD IN (SELECT * FROM MAHD_THONGTINBAN)

	DROP TABLE MAHD_THONGTINBAN

	if (@ismaB1Trong = 0)
		UPDATE dbo.BAN SET Trangthai = N'Trong' WHERE MaB = @maB2

	if (@ismaB2Trong = 0)
		UPDATE dbo.BAN SET Trangthai = N'Trong' WHERE MaB = @maB1
END
GO



GO
ALTER TRIGGER CAPNHAT_CTHD
ON dbo.CHITIETHOADON FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @maHD int

	SELECT @maHD = MaHD FROM inserted

	DECLARE @maB int

	SELECT @maB = MaB FROM dbo.HOADON WHERE MaHD = @maHD AND Trangthai = 0


	UPDATE dbo.BAN SET Trangthai = N'Co nguoi' WHERE MaB = @maB
	
END
GO


ALTER TRIGGER CAPNHAT_CTHD
ON dbo.CHITIETHOADON FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @maHD int

	SELECT @maHD = MaHD FROM inserted

	DECLARE @maB int

	SELECT @maB = MaB FROM dbo.HOADON WHERE MaHD = @maHD AND Trangthai = 0

	DECLARE @count int
	SELECT @count = COUNT(*) FROM dbo.CHITIETHOADON WHERE MaHD = @maHD

	if(@count > 0)
		UPDATE dbo.BAN SET Trangthai = N'Co nguoi' WHERE MaB = @maB
	else
		UPDATE dbo.BAN SET Trangthai = N'Trong' WHERE MaB = @maB
END
GO
select * from  BAN

ALTER TABLE HOADON ADD TongTien FLOAT

DELETE HOADON
go

CREATE PROC GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT b.TenB, h.TongTien, CheckIn, CheckOut, Discount 
	FROM HOADON AS h, BAN AS b 
	WHERE CheckIn >= @checkIn AND CheckOut <= @checkOut
	AND h.Trangthai = 1
	AND b.MaB = h.MaB
end
go

CREATE PROC CapNhatTK
@tenUser nvarchar(100), @tenTK nvarchar(100), @matkhau nvarchar(100), @matkhaumoi nvarchar(100)
AS
BEGIN
	DECLARE @isDungMK int = 0

	SELECT @isDungMK = COUNT(*) FROM TAIKHOAN WHERE TenUser = @tenUser AND Matkhau = @matkhau

	IF(@isDungMK = 1)
	BEGIN
		IF (@matkhaumoi = NULL OR @matkhaumoi ='')
		BEGIN
			UPDATE TAIKHOAN SET TenTK = @tenTK WHERE TenUser = @tenUser
		END
		ELSE
			UPDATE TAIKHOAN SET TenTK = @tenTK, Matkhau = @matkhaumoi WHERE TenUser = @tenUser

	END
END
GO

CREATE TRIGGER XoaCTHD
ON dbo.CHITIETHOADON FOR DELETE
AS
BEGIN
	DECLARE @maCTHD int
	DECLARE @maHD int

	SELECT @maCTHD = MaCTHD, @maHD = deleted.MaHD FROM deleted

	DECLARE @maB int
	SELECT @maB = MaB FROM dbo.HOADON WHERE MaHD = @maHD

	DECLARE @count int = 0
	SELECT @count = COUNT(*) FROM dbo.CHITIETHOADON c, dbo.HOADON h WHERE h.MaHD = c.MaHD AND h.MaHD = @maHD AND h.Trangthai = 0 
	
	IF(@count = 0)
		UPDATE dbo.BAN SET Trangthai =  N'Trong' WHERE MaB = @maB
END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

GO
CREATE PROC GetListHD_Ngay_Trang
@checkIn date, @checkOut date, @Trang int
AS
BEGIN
	DECLARE @SoDong int = 10
	DECLARE @DongChon int = @SoDong
	DECLARE @TruDong int = (@Trang - 1)* @SoDong

	;WITH HienThiHD AS (SELECT h.MaHD, b.TenB, h.TongTien, CheckIn, CheckOut, Discount 
	FROM HOADON AS h, BAN AS b 
	WHERE CheckIn >= @checkIn AND CheckOut <= @checkOut
	AND h.Trangthai = 1
	AND b.MaB = h.MaB)

	SELECT TOP (@DongChon) * FROM HienThiHD WHERE MaHD NOT IN
	(SELECT TOP (@TruDong) MaHD FROM HienThiHD)
END
GO

CREATE PROC GetSoTrang_Ngay
@checkIn date, @checkOut date
AS
BEGIN
	SELECT COUNT(*)
	FROM HOADON AS h, BAN AS b 
	WHERE CheckIn >= @checkIn AND CheckOut <= @checkOut
	AND h.Trangthai = 1
	AND b.MaB = h.MaB
END
GO
create proc [dbo].[Account_GetAll]
as
	select * from NhanVien
GO

/****** Object:  StoredProcedure [dbo].[BillDetails_InsertUpdateDelete]    Script Date: 12/8/2021 3:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[BillDetails_InsertUpdateDelete]
@ID int output,
@ID_HD int,
@ToyId int,
@SoLuong int,
@Action int
as
	IF @Action = 0 -- Nếu Action = 0, thêm dữ liệu
	BEGIN
		insert into ChiTietHoaDon(ID_HD, ID_DC, SoLuong) values (@ID_HD, @ToyId, @SoLuong)
		SELECT @id = SCOPE_IDENTITY()
	END
	ELSE IF @Action = 1 -- Nếu Action = 1, cập nhật dữ liệu
	BEGIN
		update ChiTietHoaDon
		set SoLuong = @SoLuong
		where ID = @ID and ID_HD = @ID_HD
	END
	ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
	BEGIN
		Delete ChiTietHoaDon where ID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[DoChoi_InsertUpdateDelete]    Script Date: 12/8/2021 3:36:34 PM ******/
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DoChoi_InsertUpdateDelete]
	 @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
	 @TenSanPham nvarchar(1000),
	 @ID_Loai int,
	 @DoTuoi nvarchar(100),
	 @XuatXu nvarchar(100),
	 @ThuongHieu nvarchar(1000),
	 @SoLuongTon int,
	 @GiaBan int,
	 @GiaNhap int,
	 @HinhAnh image,
	 @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
IF @Action = 0 -- Nếu Action = 0, thêm dữ liệu
BEGIN
	INSERT INTO [DoChoi] ([TenSanPham],[ID_Loai],[DoTuoi],[XuatXu],
		[ThuongHieu],[SoLuongTon],[GiaBan],[GiaNhap],[HinhAnh])
	VALUES (@TenSanPham, @ID_Loai,@DoTuoi,@XuatXu,@ThuongHieu,@SoLuongTon,@GiaBan,@GiaNhap,@HinhAnh)
	SET @ID = @@identity -- Thiết lập ID tự tăng
END
ELSE IF @Action = 1 -- Nếu Action = 1, cập nhật dữ liệu
BEGIN
	UPDATE [DoChoi]
	SET [TenSanPham] = @TenSanPham,[ID_Loai]=@ID_Loai,[SoLuongTon]=@SoLuongTon,
		[ThuongHieu]=@ThuongHieu,[GiaBan]=@GiaBan,[GiaNhap] = @GiaNhap,[HinhAnh] = @HinhAnh
	WHERE [ID] = @ID
END
ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
BEGIN
	DELETE FROM [DoChoi] WHERE [ID] = @ID
END
GO

/****** Object:  StoredProcedure [dbo].[HoaDon_InsertUpdateDelete]    Script Date: 12/8/2021 3:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HoaDon_InsertUpdateDelete]
	 @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
	 @TenKH nvarchar(1000),
	 @SDT nvarchar(1000),
	 @NgayBan smalldatetime,
	 @KhuyenMai decimal (2,2),
	 @ID_NV int,
	 @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
IF @Action = 0 -- Nếu Action = 0, thêm dữ liệu
BEGIN
	INSERT INTO [HoaDon] ([TenKH],[SDT],[NgayBan],[KhuyenMai],[ID_NV])
 
	VALUES (@TenKH,@SDT,@NgayBan,@KhuyenMai,@ID_NV)
	SET @ID = @@identity -- Thiết lập ID tự tăng
END
ELSE IF @Action = 1 -- Nếu Action = 1, cập nhật dữ liệu
BEGIN
	UPDATE [HoaDon]
	SET [TenKH] = @TenKH,[SDT] = @SDT, [NgayBan] = @NgayBan,[KhuyenMai]=@KhuyenMai,[ID_NV]=@ID_NV
	WHERE [ID] = @ID
END
ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
BEGIN
	DELETE FROM [HoaDon] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Toy_GetAll]    Script Date: 12/8/2021 3:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Toy_GetAll]
as
	select * from DoChoi
GO
/****** Object:  StoredProcedure [dbo].[Type_GetAll]    Script Date: 12/8/2021 3:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Type_GetAll]
as
	select * from Loai
GO
/****** Object:  StoredProcedure [dbo].[Type_InsertUpdateDelete]    Script Date: 12/8/2021 3:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Type_InsertUpdateDelete]
	 @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
	 @ID_Cha int,
	 @TenLoai nvarchar (1000),
	 @MoTa nvarchar(1000),
	 @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
IF @Action = 0 -- Nếu Action = 0, thêm dữ liệu
BEGIN
	INSERT INTO [Loai] ([ID_Cha],[TenLoai],[MoTa])
 
	VALUES (@ID_Cha,@TenLoai,@MoTa)
	SET @ID = @@identity -- Thiết lập ID tự tăng
END
ELSE IF @Action = 1 -- Nếu Action = 1, cập nhật dữ liệu
BEGIN
	UPDATE [Loai]
	SET [ID_Cha] = @ID_Cha,[TenLoai] = @TenLoai, [MoTa] = @MoTa 
	WHERE [ID] = @ID
END
ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
BEGIN
	DELETE FROM [Loai] WHERE [ID] = @ID
END
GO
------------Lấy_IDCha----------------
create proc [dbo].[Loai_GetIDCha]
as
	select * from Loai
	where ID_Cha = 0
GO
--------Lấy_IDCon------------------------
create proc [dbo].[Loai_GetIDCon]
as
	select * from Loai
	where ID_Cha != 0
GO

-----Số lượng hóa đơn----------------
create proc [dbo].[HoaDon_SoLuong]
as
	SELECT COUNT(HoaDon.ID) as SoLuong
	FROM HoaDon
GO
------Chi phí nhập hàng-------------
create proc [dbo].[Toy_ChiPhiNhap]
as
	SELECT SUM(DoChoi.GiaNhap * DoChoi.SoLuongTon) as TongChiPhiNhap
	FROM DoChoi
GO
----Lấy thông tin Bill------------
create proc [dbo].[Bill_GetAll]
as
	select * from HoaDon
go

--Tổng chi phí khuyến mãi--
create proc [dbo].[Get_Discount]
as
	select SUM(ChiTietHoaDon.SoLuong * DoChoi.GiaBan * HoaDon.KhuyenMai) as TongKhuyenMai
	from HoaDon
	join ChiTietHoaDon on ChiTietHoaDon.ID_HD = HoaDon.ID
	join DoChoi on DoChoi.ID = ChiTietHoaDon.ID_DC
go

-- Tính doanh thu--
create proc [dbo].[Get_DoanhThu]
as
	select SUM(ChiTietHoaDon.SoLuong * DoChoi.GiaBan) as DoanhThu
	from ChiTietHoaDon
	join DoChoi on DoChoi.ID = ChiTietHoaDon.ID_DC
go
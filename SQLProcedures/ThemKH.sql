USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[ThemKH]    Script Date: 04/03/2018 23:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[ThemKH]
@cmnd nvarchar(20),
@hoten nvarchar(MAX),
@makh nvarchar(50),
@dienthoai nvarchar(50),
@email nvarchar(50),
@diachi nvarchar(255),
@ngaysinh datetime,
@ngaycap datetime,
@noicap nvarchar(255),
@quoctich nvarchar(50),
@sotk nvarchar(50),
@gioitinh bit

as 
begin
insert into KHACHHANG (CMND, HOTEN, MAKH,DIENTHOAI1, EMAIL,DIACHI1,NGAYSINH,NGAYCAP,NOICAP,QUOCTICH,GIOITINH)
values (@cmnd,@hoten,@makh,@dienthoai, @email,@diachi,CONVERT(datetime,@ngaycap, 103),Convert(datetime,@noicap,103),@noicap,@quoctich,@gioitinh)
insert into TAI_KHOAN (SOTK,CMND) 
values (@sotk,@cmnd)
end
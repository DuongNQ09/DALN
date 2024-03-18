USE [DEVEXPRESSDEMO]
GO

/****** Object:  Table [dbo].[BANGCONG_NHANVIEN_CHITIET]    Script Date: 22/01/2022 4:12:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BANGCONG_NHANVIEN_CHITIET](
	[ID] [int] NOT NULL,
	[MAKYCONG] [nvarchar](50) NULL,
	[MACTY] [nvarchar](50) NULL,
	[MANV] [int] NULL,
	[HOTEN] [nvarchar](50) NULL,
	[NGAY] [datetime] NULL,
	[THU] [nvarchar](50) NULL,
	[GIOVAO] [nvarchar](50) NULL,
	[GIORA] [nvarchar](50) NULL,
	[NGAYPHEP] [float] NULL,
	[CONGNGAYLE] [float] NULL,
	[CONGCHUNHAT] [float] NULL,
	[KYHIEU] [nvarchar](50) NULL,
	[GHICHU] [nvarchar](500) NULL,
	[CREATED_BY] [int] NULL,
	[CREATED_DATE] [datetime] NULL,
	[UPDATED_BY] [int] NULL,
	[UPDATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_BANGCONG_NHANVIEN_CT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

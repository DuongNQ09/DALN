USE [DEVEXPRESSDEMO]
GO

/****** Object:  Table [dbo].[KYCONGCHITIET]    Script Date: 22/01/2022 4:13:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KYCONGCHITIET](
	[MAKYCONG] [int] NOT NULL,
	[MANV] [int] NOT NULL,
	[HOTEN] [nvarchar](50) NULL,
	[MACTY] [nvarchar](4) NULL,
	[D1] [nvarchar](10) NULL,
	[D2] [nvarchar](10) NULL,
	[D3] [nvarchar](10) NULL,
	[D4] [nvarchar](10) NULL,
	[D5] [nvarchar](10) NULL,
	[D6] [nvarchar](10) NULL,
	[D7] [nvarchar](10) NULL,
	[D8] [nvarchar](10) NULL,
	[D9] [nvarchar](10) NULL,
	[D10] [nvarchar](10) NULL,
	[D11] [nvarchar](10) NULL,
	[D12] [nvarchar](10) NULL,
	[D13] [nvarchar](10) NULL,
	[D14] [nvarchar](10) NULL,
	[D15] [nvarchar](10) NULL,
	[D16] [nvarchar](10) NULL,
	[D17] [nvarchar](10) NULL,
	[D18] [nvarchar](10) NULL,
	[D19] [nvarchar](10) NULL,
	[D20] [nvarchar](10) NULL,
	[D21] [nvarchar](10) NULL,
	[D22] [nvarchar](10) NULL,
	[D23] [nvarchar](10) NULL,
	[D24] [nvarchar](10) NULL,
	[D25] [nvarchar](10) NULL,
	[D26] [nvarchar](10) NULL,
	[D27] [nvarchar](10) NULL,
	[D28] [nvarchar](10) NULL,
	[D29] [nvarchar](10) NULL,
	[D30] [nvarchar](10) NULL,
	[D31] [nvarchar](10) NULL,
	[NGAYCONG] [float] NULL,
	[NGAYPHEP] [float] NULL,
	[NGHIKHONGPHEP] [float] NULL,
	[CONGNGAYLE] [float] NULL,
	[CONGCHUNHAT] [float] NULL,
	[TONGNGAYCONG] [float] NULL,
 CONSTRAINT [PK_KYCONGCHITIET_1] PRIMARY KEY CLUSTERED 
(
	[MAKYCONG] ASC,
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


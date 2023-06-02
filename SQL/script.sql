USE [StokTakip]
GO
/****** Object:  Table [dbo].[bodinoz]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bodinoz](
	[UretimNo] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[MalzemeCinsi] [varchar](max) NULL,
	[SiparisMiktari] [int] NULL,
	[En] [int] NULL,
	[Kalinlik] [int] NULL,
	[KorukBilgisi] [varchar](max) NULL,
	[KoronaBilgisi] [varchar](max) NULL,
	[RenkBilgisi] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UretimNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kesim]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kesim](
	[UretimNo] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[EbatBilgisi] [int] NULL,
	[PaketSayisi] [int] NULL,
	[SevkiyatSekli] [varchar](max) NULL,
	[kesimUsta] [varchar](max) NULL,
	[FaturaCinsi] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UretimNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[matbaa]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[matbaa](
	[UretimNo] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[KazanBilgisi] [varchar](max) NULL,
	[BaskiRenkleriBilgisi] [varchar](max) NULL,
	[Ebat] [int] NULL,
	[Kilo] [int] NULL,
	[Metre] [int] NULL,
	[Rulo] [int] NULL,
	[matbaaUsta] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UretimNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[orders]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[DeliverDate] [datetime] NULL,
	[LotNo] [int] NULL,
	[FirmName] [varchar](max) NULL,
	[JobName] [varchar](max) NULL,
	[Notes] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[permission]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[URLid] [int] NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[roles]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[userrole] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stok]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stok](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirmaAdı] [varchar](max) NULL,
	[UrunCinsi] [varchar](max) NULL,
	[UrunMiktarı] [int] NULL,
	[UrunTuru] [varchar](max) NULL,
	[tarih] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Uretim]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uretim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[UretimBaslangicTarihi] [date] NULL,
	[UretimBitisTarihi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[url]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[url](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 2.06.2023 16:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NOT NULL,
	[surname] [varchar](max) NOT NULL,
	[username] [varchar](max) NOT NULL,
	[userpass] [varchar](max) NOT NULL,
	[usermail] [varchar](max) NOT NULL,
	[roleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[bodinoz]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[orders] ([OrderID])
GO
ALTER TABLE [dbo].[kesim]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[orders] ([OrderID])
GO
ALTER TABLE [dbo].[matbaa]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[orders] ([OrderID])
GO
ALTER TABLE [dbo].[permission]  WITH CHECK ADD FOREIGN KEY([URLid])
REFERENCES [dbo].[url] ([ID])
GO
ALTER TABLE [dbo].[Uretim]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[orders] ([OrderID])
GO

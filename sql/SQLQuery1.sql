USE [StokTakip]
GO
/****** Object:  Table [dbo].[bodinoz]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[kesim]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[matbaa]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[orders]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[permission]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[roles]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[Stok]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[Uretim]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[url]    Script Date: 4.06.2023 13:29:19 ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 4.06.2023 13:29:19 ******/
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
SET IDENTITY_INSERT [dbo].[bodinoz] ON 

GO
INSERT [dbo].[bodinoz] ([UretimNo], [OrderID], [MalzemeCinsi], [SiparisMiktari], [En], [Kalinlik], [KorukBilgisi], [KoronaBilgisi], [RenkBilgisi]) VALUES (5018, 4018, N'plastik', 3, 30, 50, N'Körük', N'Korona', N'Sarı')
GO
SET IDENTITY_INSERT [dbo].[bodinoz] OFF
GO
SET IDENTITY_INSERT [dbo].[kesim] ON 

GO
INSERT [dbo].[kesim] ([UretimNo], [OrderID], [EbatBilgisi], [PaketSayisi], [SevkiyatSekli], [kesimUsta], [FaturaCinsi]) VALUES (5012, 4018, 50, 200, N'Tır', N'Yusuf', N'Fatura')
GO
SET IDENTITY_INSERT [dbo].[kesim] OFF
GO
SET IDENTITY_INSERT [dbo].[matbaa] ON 

GO
INSERT [dbo].[matbaa] ([UretimNo], [OrderID], [KazanBilgisi], [BaskiRenkleriBilgisi], [Ebat], [Kilo], [Metre], [Rulo], [matbaaUsta]) VALUES (5014, 4018, N'Kazan', N'Mavi', 0, 6, 0, 2, N'Mehmet')
GO
SET IDENTITY_INSERT [dbo].[matbaa] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

GO
INSERT [dbo].[orders] ([OrderID], [OrderDate], [DeliverDate], [LotNo], [FirmName], [JobName], [Notes]) VALUES (4018, CAST(N'2023-05-31 00:00:00.000' AS DateTime), CAST(N'2023-05-31 00:00:00.000' AS DateTime), 176, N'Der Plastik', N'Çöp Poşeti', N'Üretime yarın başlanmalı.')
GO
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[permission] ON 

GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (2, 1, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (5, 1, 0)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (8, 2, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (9, 2, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (10, 3, 0)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (11, 3, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (12, 3, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (13, 4, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (14, 4, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (15, 5, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (16, 6, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (17, 7, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (18, 8, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (19, 8, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (20, 9, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (21, 9, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (22, 10, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (23, 10, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (24, 11, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (25, 11, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (26, 12, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (27, 12, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (28, 13, 0)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (29, 13, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (30, 13, 2)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (1029, 1013, 1)
GO
INSERT [dbo].[permission] ([ID], [URLid], [RoleID]) VALUES (1030, 1013, 2)
GO
SET IDENTITY_INSERT [dbo].[permission] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 

GO
INSERT [dbo].[roles] ([ID], [userrole]) VALUES (1, N'admin')
GO
INSERT [dbo].[roles] ([ID], [userrole]) VALUES (2, N'user')
GO
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Stok] ON 

GO
INSERT [dbo].[Stok] ([ID], [FirmaAdı], [UrunCinsi], [UrunMiktarı], [UrunTuru], [tarih]) VALUES (1002, N'ercan', N'yusuf', 5, N'ömer', CAST(N'2023-05-26' AS Date))
GO
INSERT [dbo].[Stok] ([ID], [FirmaAdı], [UrunCinsi], [UrunMiktarı], [UrunTuru], [tarih]) VALUES (2004, N'Der', N'Plastik', 650, N'Rulo', CAST(N'2023-05-31' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Stok] OFF
GO
SET IDENTITY_INSERT [dbo].[Uretim] ON 

GO
INSERT [dbo].[Uretim] ([ID], [OrderID], [UretimBaslangicTarihi], [UretimBitisTarihi]) VALUES (3021, 4018, CAST(N'2023-05-31' AS Date), CAST(N'2023-06-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Uretim] OFF
GO
SET IDENTITY_INSERT [dbo].[url] ON 

GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (1, N'Home/Index')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (2, N'Home/withOrderDetails')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (3, N'Login/LoginUserPage')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (4, N'Home/Createplan')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (5, N'Home/WithRole')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (6, N'Home/CreateUser')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (7, N'Home/EditUser')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (8, N'Home/CreateOrder')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (9, N'Home/EditOrder')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (10, N'Home/Createstock')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (11, N'Home/StockList')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (12, N'Home/EditStock')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (13, N'Error/CustomError')
GO
INSERT [dbo].[url] ([ID], [URL]) VALUES (1013, N'Home/GetUretim')
GO
SET IDENTITY_INSERT [dbo].[url] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

GO
INSERT [dbo].[users] ([ID], [name], [surname], [username], [userpass], [usermail], [roleId]) VALUES (4, N'a', N'a', N'a', N'a', N'mail', 1)
GO
INSERT [dbo].[users] ([ID], [name], [surname], [username], [userpass], [usermail], [roleId]) VALUES (5, N'w', N'w', N'w', N'w', N'w', 2)
GO
INSERT [dbo].[users] ([ID], [name], [surname], [username], [userpass], [usermail], [roleId]) VALUES (1009, N'Yusuf Buğra', N'Ercan', N'yb.ercan', N'123456', N'yb@mail', 1)
GO
INSERT [dbo].[users] ([ID], [name], [surname], [username], [userpass], [usermail], [roleId]) VALUES (2010, N'Hamza', N'Hamza', N'hamza123', N'1234', N'hamza@mail', 2)
GO
SET IDENTITY_INSERT [dbo].[users] OFF
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

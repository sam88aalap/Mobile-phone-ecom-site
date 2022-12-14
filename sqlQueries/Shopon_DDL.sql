/****** Object:  Database [db_shopon]    Script Date: 4/4/2022 11:20:38 AM ******/
---CREATE DATABASE [db_shopon]
---GO
---USE [db_shopon]
---GO
/****** Object:  Table [dbo].[category]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[categoryid] [int] NOT NULL,
	[category] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[companyid] [int] NOT NULL,
	[companyname] [varchar](20) NULL,
	[companystatus] [char](1) NULL,
	[isdeleted] [bit] NULL,
 CONSTRAINT [PK__company__AD5755B86BA2B3C7] PRIMARY KEY CLUSTERED 
(
	[companyid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customerid] [int] NOT NULL,
	[customername] [varchar](20) NULL,
	[mobileno] [varchar](10) NULL,
	[emailid] [varchar](100) NULL,
	[password] [nchar](20) NULL,
 CONSTRAINT [PK__customer__B61ED7F52A902A4D] PRIMARY KEY CLUSTERED 
(
	[customerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customeraddress]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customeraddress](
	[customerid] [int] NULL,
	[stName] [varchar](100) NULL,
	[city] [varchar](30) NULL,
	[state] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderd]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderd](
	[orderid] [int] NOT NULL,
	[orderstatus] [varchar](20) NULL,
	[orderdate] [date] NULL,
	[customerid] [int] NULL,
	[totalAmount] [float] NULL,
 CONSTRAINT [PK__orderd__080E3775040ED1A3] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderitem]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderitem](
	[orderid] [int] NOT NULL,
	[qty] [int] NULL,
	[amount] [float] NULL,
	[pid] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[pid] [int] NOT NULL,
	[productname] [varchar](20) NULL,
	[price] [float] NULL,
	[companyid] [int] NULL,
	[categoryid] [int] NULL,
	[availablestatus] [char](1) NULL,
	[imageUrl] [varchar](50) NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK__product__DD37D91A44BAD04F] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productrating]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productrating](
	[Pid] [int] NULL,
	[Rating] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stock]    Script Date: 4/4/2022 11:20:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stock](
	[pid] [int] NULL,
	[soh] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[category] ADD  DEFAULT (NULL) FOR [category]
GO
ALTER TABLE [dbo].[company] ADD  CONSTRAINT [DF__company__company__1273C1CD]  DEFAULT (NULL) FOR [companyname]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF__customer__custom__164452B1]  DEFAULT (NULL) FOR [customername]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF__customer__mobile__173876EA]  DEFAULT (NULL) FOR [mobileno]
GO
ALTER TABLE [dbo].[orderd] ADD  CONSTRAINT [DF__orderd__orderdat__286302EC]  DEFAULT (NULL) FOR [orderdate]
GO
ALTER TABLE [dbo].[orderitem] ADD  CONSTRAINT [DF__orderitem__order__29572725]  DEFAULT (NULL) FOR [orderid]
GO
ALTER TABLE [dbo].[orderitem] ADD  CONSTRAINT [DF__orderitem__qty__2A4B4B5E]  DEFAULT (NULL) FOR [qty]
GO
ALTER TABLE [dbo].[orderitem] ADD  CONSTRAINT [DF__orderitem__pid__2B3F6F97]  DEFAULT (NULL) FOR [pid]
GO
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF__product__product__1DE57479]  DEFAULT (NULL) FOR [productname]
GO
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF__product__price__1ED998B2]  DEFAULT (NULL) FOR [price]
GO
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF__product__company__1FCDBCEB]  DEFAULT (NULL) FOR [companyid]
GO
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF__product__categor__20C1E124]  DEFAULT (NULL) FOR [categoryid]
GO
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF__product__availab__21B6055D]  DEFAULT (NULL) FOR [availablestatus]
GO
ALTER TABLE [dbo].[stock] ADD  DEFAULT (NULL) FOR [pid]
GO
ALTER TABLE [dbo].[stock] ADD  DEFAULT (NULL) FOR [soh]
GO
ALTER TABLE [dbo].[customeraddress]  WITH CHECK ADD  CONSTRAINT [fk_cid] FOREIGN KEY([customerid])
REFERENCES [dbo].[customer] ([customerid])
GO
ALTER TABLE [dbo].[customeraddress] CHECK CONSTRAINT [fk_cid]
GO
ALTER TABLE [dbo].[orderd]  WITH CHECK ADD  CONSTRAINT [fk_order_cid] FOREIGN KEY([customerid])
REFERENCES [dbo].[customer] ([customerid])
GO
ALTER TABLE [dbo].[orderd] CHECK CONSTRAINT [fk_order_cid]
GO
ALTER TABLE [dbo].[orderitem]  WITH CHECK ADD  CONSTRAINT [fk_orderItem_oid] FOREIGN KEY([orderid])
REFERENCES [dbo].[orderd] ([orderid])
GO
ALTER TABLE [dbo].[orderitem] CHECK CONSTRAINT [fk_orderItem_oid]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_category_caid] FOREIGN KEY([categoryid])
REFERENCES [dbo].[category] ([categoryid])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_category_caid]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_company_id] FOREIGN KEY([companyid])
REFERENCES [dbo].[company] ([companyid])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_company_id]
GO
ALTER TABLE [dbo].[productrating]  WITH CHECK ADD  CONSTRAINT [fk_product_id] FOREIGN KEY([Pid])
REFERENCES [dbo].[product] ([pid])
GO
ALTER TABLE [dbo].[productrating] CHECK CONSTRAINT [fk_product_id]
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD  CONSTRAINT [fk_stock_product_id] FOREIGN KEY([pid])
REFERENCES [dbo].[product] ([pid])
GO
ALTER TABLE [dbo].[stock] CHECK CONSTRAINT [fk_stock_product_id]
GO
USE [master]
GO
ALTER DATABASE [db_shopon] SET  READ_WRITE 
GO

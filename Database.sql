USE [aspnet-LaptopShopOnline]
GO
/****** Object:  Table [dbo].[About]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NULL,
	[ObjectName] [nvarchar](256) NULL,
	[Address] [nvarchar](256) NULL,
	[Mobile] [varchar](20) NULL,
	[Website] [varchar](256) NULL,
	[Email] [varchar](256) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Contact__3214EC07B68E50F5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Credential]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Credential](
	[UserGroupId] [varchar](50) NOT NULL,
	[RoleId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Credential_1] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](256) NULL,
	[Address] [nvarchar](256) NULL,
	[Content] [nvarchar](max) NULL,
	[Reply] [nvarchar](max) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Feedback__3214EC07ABFD67FA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[Id] [uniqueidentifier] NOT NULL,
	[CoppyRight] [nvarchar](100) NULL,
	[Address] [nvarchar](256) NULL,
	[PhoneNumber] [nvarchar](256) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Footer__3214EC07852F6A97] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](256) NOT NULL,
	[Link] [nvarchar](256) NULL,
	[DisplayOrder] [int] NULL,
	[ParentId] [int] NULL,
	[Target] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Menu__3214EC079B6A10D6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[News](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Summary] [nvarchar](max) NULL,
	[MetaTitle] [varchar](256) NULL,
	[Description] [nvarchar](max) NULL,
	[UrlImage] [nvarchar](256) NULL,
	[NewsCategoryId] [uniqueidentifier] NULL,
	[Warranty] [int] NULL,
	[MetaKeywords] [nvarchar](256) NULL,
	[MetaDescriptions] [nvarchar](256) NULL,
	[TopHot] [datetime] NULL,
	[ViewCount] [int] NULL,
	[Tag] [nvarchar](256) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Content__3214EC0722536217] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewsCategory]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewsCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[MetaTitle] [varchar](256) NULL,
	[ParentId] [int] NULL,
	[DisplayOrder] [int] NULL,
	[SeoTitle] [nvarchar](256) NULL,
	[MetaKeywords] [nvarchar](256) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Category__3214EC07DEE8C6AA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ShipName] [nvarchar](256) NOT NULL,
	[ShipPhone] [nvarchar](50) NOT NULL,
	[ShipAddress] [nvarchar](256) NOT NULL,
	[ShipEmail] [varchar](256) NOT NULL,
	[Status] [bit] NOT NULL CONSTRAINT [DF_Order_Status]  DEFAULT ((0)),
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Order__3214EC07DF9E2F66] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ProductId] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Code] [decimal](18, 0) NULL,
	[MetaTitle] [nvarchar](256) NULL,
	[Description] [nvarchar](max) NULL,
	[UrlImage] [nvarchar](256) NULL,
	[Price] [decimal](18, 0) NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[IncludeVAT] [bit] NULL,
	[Quantity] [int] NULL,
	[ProductCategoryId] [uniqueidentifier] NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[MetaKeywords] [nvarchar](256) NULL,
	[MetaDescriptions] [nvarchar](256) NULL,
	[TopHot] [bit] NULL,
	[IsNormalProduct2] [bit] NULL,
	[IsNormalProduct1] [bit] NULL,
	[IsNewProduct] [bit] NULL,
	[ViewCount] [int] NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Product__3214EC072E0A9E49] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[MetaTitle] [varchar](256) NULL,
	[ParentId] [int] NULL,
	[DisplayOrder] [int] NULL,
	[SeoTitle] [nvarchar](256) NULL,
	[MetaKeywords] [nvarchar](256) NULL,
	[MetaDescriptions] [nvarchar](256) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__ProductC__3214EC077834B296] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UrlImage] [nvarchar](256) NOT NULL,
	[DisplayOrder] [int] NULL,
	[Link] [nvarchar](256) NULL,
	[Description] [nvarchar](256) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__Slide__3214EC073DFECF16] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[GroupId] [varchar](50) NULL,
	[AvatarUrl] [nvarchar](256) NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[ConfirmPassword] [varchar](50) NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[ResetPasswordCode] [nvarchar](100) NULL,
	[Email] [varchar](256) NULL,
	[Address] [nvarchar](max) NULL,
	[CreatedOn] [datetimeoffset](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetimeoffset](7) NULL,
	[ModifiedBy] [nvarchar](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__User__3214EC07B2B93D14] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 2/19/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroup](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[About] ([Id], [Title], [Description], [Content], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'71725cfd-cf6d-49d9-b152-9102907d997e', N'Máy Tính Việt - Địa chỉ bán máy tính cũ giá rẻ tại TPHCM uy tín chất lượng', N'Bạn đang muốn tìm địa chỉ uy tín, chất lượng để mua cho mình một chiếc máy tính cũ giá rẻ phục vụ cho công việc của mình. Bạn không biết địa chỉ nào cung cấp máy tính cũ chất lượng, giá cả phải chẳng tại TPHCM.  Có nhiều người chia sẻ, giới thiệu đến bạn địa chỉ mua máy tính tại Máy Tính Việt. Nhưng bạn chưa đủ tin tưởng để mua? Những lý do dưới đây đã giúp Máy Tính Việt trở thành địa chỉ mua bán máy tính cũ giá rẻ uy tín, chất lượng tại TPHCM.', N'<p>Tr&ecirc;n thị trường m&aacute;y t&iacute;nh cũ nhập khẩu hi&ecirc;̣n nay chưa có m&ocirc;̣t thương hi&ecirc;̣u bán lẻ nào chuy&ecirc;n v&ecirc;̀ máy tính như ở M&aacute;y T&iacute;nh Việt. Cửa h&agrave;ng M&aacute;y T&iacute;nh Việt bán hàng chính hãng, nhập khẩu trực tiếp từ Mỹ v&agrave; Canada về Việt Nam. Bảo hành theo ti&ecirc;u chuẩn tr&ecirc;n toàn qu&ocirc;́c và được hưởng đ&acirc;̀y đủ các chương trình khuy&ecirc;́n mãi&nbsp;</p>

<p>Cửa h&agrave;ng M&aacute;y T&iacute;nh Việt đã hoạt động v&agrave; ph&aacute;t triển mạnh mẽ v&agrave; vững chắc trong nhiều năm qua tại cơ sở 219/60 Trần Văn Đang, Phường 11, Quận 3, TP. HCM. Với sự phát tri&ecirc;̉n của mảng bán lẻ online, Cửa h&agrave;ng M&aacute;y T&iacute;nh Việt cũng đang đẩy mạnh bán hàng online nhằm giúp khách hàng có th&ecirc;̉ mua b&aacute;n m&aacute;y t&iacute;nh ở nhiều khu vực kh&aacute;c nhau. Đặc biệt l&agrave; c&oacute; giá t&ocirc;́t nhất, ti&ecirc;́t ki&ecirc;̣m được tkhoảng thời gian di chuyển, đi lại.</p>

<p>Tại M&aacute;y T&iacute;nh Việt, c&aacute;c bạn c&oacute; thể thoải m&aacute;i, thỏa sức lựa chọn sản phẩm m&aacute;y t&iacute;nh x&aacute;ch tay, PC cũ với mẫu m&atilde; c&oacute; thương hiệu v&agrave; đa dạng chủng loại v&agrave; nhiều linh phụ kiện đi k&egrave;m như CPU, Ram, HDD, Nguồn&hellip;. Tất cả c&aacute;c sản phẩm m&aacute;y t&iacute;nh x&aacute;ch tay, PC cũ đều được kiểm tra v&agrave; bảo dưỡng kỹ lưỡng trước khi xuất h&agrave;ng. Ch&iacute;nh v&igrave; đa dạng về mặt h&agrave;ng v&agrave; uy t&iacute;n về chất lượng bởi sản phẩm m&aacute;y t&iacute;nh x&aacute;ch tay, PC cũ ch&iacute;nh h&atilde;ng n&ecirc;n nhiều năm qua M&aacute;y T&iacute;nh Việt được rất nhiều kh&aacute;ch h&agrave;ng quan t&acirc;m v&agrave; ủng hộ.</p>
', 0, NULL, NULL, N'admin', CAST(N'2022-02-18T20:25:27.7837873+07:00' AS DateTimeOffset))
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([Id], [Title], [ObjectName], [Address], [Mobile], [Website], [Email], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (1, N'Cơ sở 1', N'Cơ sở Hồ Chí Minh', N'261 - 263 Khánh Hội, P5, Q4, TP. Hồ Chí Minh', N'0236.333.444', N'https://latopthanhvan.com.vn', N'latopthanhvan@gmail.com', CAST(N'2019-05-29T12:22:26.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:22:01.4931931+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Contact] ([Id], [Title], [ObjectName], [Address], [Mobile], [Website], [Email], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (2, N'Cơ sở 2', N'Cơ sở Hà Nội', N'48 Hai Bà Trung, Hà Nội', N'0235.444.333', N'https://latopthanhvan.com.vn', N'latopthanhvan@gmail.com', CAST(N'2019-05-29T12:22:26.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:21:58.3224171+07:00' AS DateTimeOffset), N'admin', 0)
SET IDENTITY_INSERT [dbo].[Contact] OFF
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'ADD_USER')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'CREATE_CREDENTIAL')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'CREATE_ROLE')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'CREATE_USER_GROUP')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'DELETE_CREDENTIAL')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'DELETE_ROLE')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'DELETE_USER')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'DELETE_USER_GROUP')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'EDIT_USER')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'UPDATE_ROLE')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'UPDATE_USER_GROUP')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'VIEW_CREDENTIAL')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'VIEW_LAYOUT')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'VIEW_ROLE')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'VIEW_USER')
INSERT [dbo].[Credential] ([UserGroupId], [RoleId]) VALUES (N'ADMIN', N'VIEW_USER_GROUP')
INSERT [dbo].[Feedback] ([Id], [Name], [Phone], [Email], [Address], [Content], [Reply], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'0ea663e4-be02-4f8f-a9c7-3a2f0e4c4522', N'Nguyễn Văn A', N'0388333444', N'nguyenvana@gmail.com', N'Hà Nội', N'Tôi rất hài lòng về sản phẩm', N'Cảm ơn quý khách', CAST(N'2019-06-04T10:50:20.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2019-06-04T11:55:22.7982222+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Feedback] ([Id], [Name], [Phone], [Email], [Address], [Content], [Reply], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'b17940d6-204f-4079-9c5d-6411e2ae58fa', N'Nguyễn Văn B', N'0388333445', N'nguyenvanb@gmail.com', N'Gia Lai', N'Tôi rất hài lòng về sản phẩm', N'Cảm ơn quý khách', CAST(N'2019-06-04T10:49:28.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2019-06-04T11:55:36.4814440+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Feedback] ([Id], [Name], [Phone], [Email], [Address], [Content], [Reply], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'ae2f9c04-2189-40d4-8037-afffd451384a', N'Nguyễn Văn C', N'0388333446', N'nguyenvanc@gmail.com', N'Hải phòng', N'Tôi rất hài lòng về sản phẩm', N'Cảm ơn quý khách', CAST(N'2019-06-08T09:58:55.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2019-06-08T09:59:26.9347532+07:00' AS DateTimeOffset), N'admin', 1)
INSERT [dbo].[Feedback] ([Id], [Name], [Phone], [Email], [Address], [Content], [Reply], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'a848b336-aecf-483d-a2b5-e2d821f5be2b', N'Nguyễn Văn D', N'0388333447', N'nguyenvand@gmail.com', N'Hồ Chí Minh', N'Tôi rất hài lòng về sản phẩm', N'Cảm ơn quý khách', CAST(N'2019-06-04T10:51:31.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2019-06-04T11:55:46.6417554+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Feedback] ([Id], [Name], [Phone], [Email], [Address], [Content], [Reply], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'ac526ab9-64dd-488f-8302-fc2f18d9ea7e', N'Nguyễn Văn E', N'0388333448', N'nguyenvane@gmail.com', N'Đà Nẵng', N'Tôi rất hài lòng về sản phẩm', N'Cảm ơn quý khách', CAST(N'2019-06-04T10:48:30.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2019-06-04T11:55:52.5782255+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Footer] ([Id], [CoppyRight], [Address], [PhoneNumber], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'044bf44b-24af-4c55-a776-f93ae5e6ceb0', N'© 2022 Công Ty Cổ Phần Bán Lẻ Kỹ Thuật Số Thanh Vân', N'Địa chỉ: 261 - 263 Khánh Hội, P5, Q4, TP. Hồ Chí Minh', N'0388.333.444', NULL, NULL, CAST(N'2022-02-18T20:22:07.6661652+07:00' AS DateTimeOffset), N'admin', 0)
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (1, N'Trang chủ', N'/', 1, NULL, N'_self', CAST(N'2019-05-27T16:17:45.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2022-02-18T20:21:11.2281150+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (2, N' Giới thiệu', N'/gioi-thieu', 2, NULL, N'_self', NULL, NULL, CAST(N'2022-02-18T20:21:13.3219630+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (3, N'Tin tức', N'/tin-tuc', 3, NULL, N'_self', NULL, NULL, CAST(N'2022-02-18T20:21:14.8157124+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (4, N'Sản phẩm', N'/tat-ca-san-pham', 4, NULL, N'_self', NULL, NULL, CAST(N'2022-02-18T20:21:16.0197042+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (5, N'Liên hệ', N'#', 5, NULL, N'_self', NULL, NULL, CAST(N'2022-02-18T20:21:17.6165163+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (15, N'Thông tin liên hệ', N'#Contact', 1, 5, N'_self', NULL, NULL, CAST(N'2022-02-18T20:21:19.5855852+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (16, N'Góp ý', N'/gop-y', 2, 5, N'_self', NULL, NULL, CAST(N'2022-02-18T20:21:24.7064332+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (18, N'Phản hồi ý kiến khách hàng', N'/phan-hoi-y-kien-khach-hang', 3, 5, N'_self', NULL, NULL, CAST(N'2022-02-18T20:21:31.2171455+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (20, N'Khuyến mãi', N'/loai-tin-tuc/khuyen-mai/a2b988e6-9053-4c9d-b6fb-5ade0e050d18', 1, 3, N'_self', CAST(N'2019-06-09T17:13:06.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:21:34.2254970+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (21, N'Sự kiện', N'/loai-tin-tuc/su-kien/9d1fdd2c-e06d-402b-87de-f8746537bdbf', 2, 3, N'_self', CAST(N'2019-06-09T17:18:30.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:21:37.3697206+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Menu] ([Id], [MenuName], [Link], [DisplayOrder], [ParentId], [Target], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (22, N'Chăm sóc khách hàng', N'/loai-tin-tuc/cham-soc-khach-hang/c787ffc1-f333-484e-b176-c76d5c3d85a7', 3, 3, N'_self', CAST(N'2019-06-09T17:20:35.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:21:40.3061101+07:00' AS DateTimeOffset), N'admin', 0)
SET IDENTITY_INSERT [dbo].[Menu] OFF
INSERT [dbo].[News] ([Id], [Name], [Summary], [MetaTitle], [Description], [UrlImage], [NewsCategoryId], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [ViewCount], [Tag], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'f11b09ac-0959-4d99-a18e-1b4a3739f310', N'FREE X2 RAM – NHÂN ĐÔI SỨC MẠNH', N'FREE X2 RAM – NHÂN ĐÔI SỨC MẠNH', N'FREE-X2-RAM–NHÂN-ÐÔI', N'<h2><strong>FREE X2 RAM &ndash; NH&Acirc;N Đ&Ocirc;I SỨC MẠNH</strong></h2>

<h2>&nbsp;</h2>

<h2><strong>&nbsp;</strong></h2>

<p>Tr&ecirc;n đời c&oacute; 2 việc khiến anh em game thủ phải lo lắng: một l&agrave;&nbsp;<em>&ldquo;thiếu người y&ecirc;u&rdquo;</em>, hai l&agrave;&nbsp;<em>&ldquo;thiếu RAM laptop&rdquo;.</em>&nbsp;Thấu hiểu nỗi l&ograve;ng đ&oacute;, Kim Long Center tổ chức chương tr&igrave;nh khuyến m&atilde;i&nbsp;<strong>&ldquo;X2 RAM &ndash; NH&Acirc;N Đ&Ocirc;I SỨC MẠNH</strong>&rdquo; vừa gi&uacute;p anh em được miễn ph&iacute; n&acirc;ng cấp RAM laptop l&ecirc;n gấp đ&ocirc;i, vừa c&oacute; &ldquo;người y&ecirc;u&rdquo; l&agrave; em laptop gaming cận kề sớm tối. Một c&ocirc;ng đ&ocirc;i chuyện, chần chờ g&igrave; nữa m&agrave; kh&ocirc;ng click ngay link sản phẩm b&ecirc;n dưới n&egrave; !!!!</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p><a href="https://kimlongcenter.com/tim-kiem.html?kw=x2ram" target="_blank"><img alt="x2 ram nhân đôi sức mạnh" src="https://kimlongcenter.com/upload/image/%232020/X2%20RAM%20-%20NH%C3%82N%20%C4%90%C3%94I%20S%E1%BB%A8C%20M%E1%BA%A0NH/khuyen-mai-hot-double-ram.png" /></a></p>

<p>&nbsp;</p>

<h3><strong><img alt="enlightened" src="https://kimlongcenter.com/admin/js/ckeditor/plugins/smiley/images/lightbulb.png" title="enlightened" />&nbsp;Nội dung chương tr&igrave;nh:</strong></h3>

<h3><strong>&nbsp;</strong></h3>

<p>Khi mua c&aacute;c sản phẩm laptop trong chương tr&igrave;nh khyến m&atilde;i, kh&aacute;ch h&agrave;ng sẽ được miễn ph&iacute; n&acirc;ng cấp RAM l&ecirc;n gấp đ&ocirc;i.<br />
&nbsp;</p>

<p>(V&iacute; dụ: laptop RAM 8GB sẽ được miễn ph&iacute; n&acirc;ng cấp l&ecirc;n RAM 16GB).<br />
&nbsp;</p>

<p><strong>||&nbsp;<a href="https://kimlongcenter.com/tim-kiem.html?kw=x2ram" target="_blank">Xem liền danh s&aacute;ch sản phẩm tại đ&acirc;y</a></strong></p>

<p>&nbsp;</p>

<h3><strong><img alt="enlightened" src="https://kimlongcenter.com/admin/js/ckeditor/plugins/smiley/images/lightbulb.png" title="enlightened" /></strong><strong>&nbsp;Thời gian diễn ra chương tr&igrave;nh</strong><strong>:</strong><strong>&nbsp;từ 5/8- 31/8/2020.</strong></h3>
', N'/Content/Data/files/km6.png', N'a2b988e6-9053-4c9d-b6fb-5ade0e050d18', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2019-06-07T22:46:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:10.4569625+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[News] ([Id], [Name], [Summary], [MetaTitle], [Description], [UrlImage], [NewsCategoryId], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [ViewCount], [Tag], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'1d203ea2-63ed-4dda-a485-2b524bfbd51f', N'/////////sad', N'sad', N'ÐANG-KÝ-LI?N-TAY–NH?N-NGAY-1.000.000-VNÐ', N'<p>sdsad</p>
', N'/Content/Data/files/18.jpg', N'a2b988e6-9053-4c9d-b6fb-5ade0e050d18', 1, N'tung-bung-chao-he-sale', N'sadsad', NULL, NULL, NULL, CAST(N'2022-02-19T10:56:21.5411507+07:00' AS DateTimeOffset), N'admin', NULL, NULL, 0)
INSERT [dbo].[News] ([Id], [Name], [Summary], [MetaTitle], [Description], [UrlImage], [NewsCategoryId], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [ViewCount], [Tag], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'0dee53ce-3b1c-49be-a043-4257239c996f', N'ĐĂNG KÝ LIỀN TAY – NHẬN NGAY 1.000.000 VNĐ', N'ĐĂNG KÝ LIỀN TAY – NHẬN NGAY 1.000.000 VNĐ', N'ÐANG-Ky-LIeN-TAY–NHaN-NGAY-1.000.000-VNÐ', N'<h2 dir="ltr"><strong>ĐĂNG K&Yacute; LIỀN TAY &ndash; NHẬN NGAY 1.000.000 VNĐ</strong></h2>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">H&atilde;ng&nbsp;<strong><a href="https://kimlongcenter.com/danh-muc/laptop-dell-449.html" target="_blank">Dell</a></strong>&nbsp;kết hợp c&ugrave;ng thanh v&acirc;n&nbsp;Center mang đến chương tr&igrave;nh khuyến m&atilde;i &ldquo;Đăng K&yacute; Liền Tay - Nhận Ngay 1.000.000 VNĐ&rdquo; cực hấp dẫn&nbsp;cho&nbsp;<strong>50 kh&aacute;ch h&agrave;ng</strong>&nbsp;đầu ti&ecirc;n. &Aacute;p dụng cho d&ograve;ng sản phẩm Dell G5 5500 với voucher l&ecirc;n đến 1.000.000 đồng.</p>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">&nbsp;<img alt="Đăng ký Liền Tay Nhận Ngay Voucher 1 triệu đồng" src="https://kimlongcenter.com/upload/image/1200x628.jpg" /></p>

<p dir="ltr">&nbsp;</p>

<h2 dir="ltr"><img alt="enlightened" src="https://lh6.googleusercontent.com/k2HUSjnWtdz8XGrejon6lBavZmdOwr7tg7M1pNAE0PRz_IAMgIXMEeNvLWxkKkzPmTuZwqKr0Y2kel6cinifn5L4op34WAzcp-bU5Bkl2a8yNbdV8Xgq2UB2P7nzmpe0H-_ABD8M" title="enlightened" /><strong>Nội dung chương tr&igrave;nh:</strong></h2>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">Qu&yacute; kh&aacute;ch h&agrave;ng đăng k&yacute; tại Landing Page sẽ được voucher giảm gi&aacute; l&ecirc;n đến 1.000.000 đồng. Chương tr&igrave;nh &ldquo;Đăng K&yacute; Liền Tay - Nhận Ngay 1.000.000 VNĐ&rdquo; chỉ &aacute;p dụng cho 50 kh&aacute;ch h&agrave;ng đăng k&yacute; đầu ti&ecirc;n.</p>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">Link Landing page:&nbsp;<strong><a href="https://kimlongcenter.com/dell-g5-5500-2021.html" target="_blank">https://kimlongcenter.com/dell-g5-5500-2021.html</a></strong>&nbsp;</p>

<p dir="ltr">&nbsp;</p>

<h3 dir="ltr"><strong>*** Lưu &yacute;:&nbsp;</strong></h3>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">- Kh&ocirc;ng &aacute;p dụng đồng thời c&aacute;c chương tr&igrave;nh khuyến m&atilde;i kh&aacute;c.</p>

<p dir="ltr">- Chương tr&igrave;nh chỉ &aacute;p dụng cho kh&aacute;ch h&agrave;ng c&aacute; nh&acirc;n.</p>

<p dir="ltr">- Voucher c&oacute; gi&aacute; trị 30 ng&agrave;y kể từ ng&agrave;y nhận&nbsp;</p>
', N'/Content/Data/files/km1.jpg', N'c787ffc1-f333-484e-b176-c76d5c3d85a7', NULL, N'giay-converse', NULL, NULL, NULL, NULL, CAST(N'2019-06-06T12:57:16.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:03.6255775+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[News] ([Id], [Name], [Summary], [MetaTitle], [Description], [UrlImage], [NewsCategoryId], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [ViewCount], [Tag], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'8d6c4773-7233-49d1-8902-524bc4bc6238', N'ĐẾN NGAY GIỜ VÀNG - ƯU ĐÃI NGẬP TRÀN', N'laptop thanh van xin gửi đến các bạn chương trình GIỜ VÀNG ƯU ĐÃI như sau:  Khi mua hàng TRỰC TIẾP tại laptopthanh.vn sẽ được giảm giá 10% giày và 15% cho quần áo.', N'den-ngay-gio-vang-uu-dai-ngap-tran', N'<p dir="ltr"><strong>Chương tr&igrave;nh &ldquo; V&ograve;ng Quay May Mắn - Chắc Chắn Tr&uacute;ng Qu&agrave; &rdquo;</strong></p>

<p dir="ltr"><strong>tại&nbsp;</strong><strong>laptop thanh v&acirc;n</strong></p>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">M&ugrave;a xu&acirc;n đi qua m&ugrave;a h&egrave; lại đến, để ch&agrave;o đ&oacute;n m&ugrave;a h&egrave; 2021 Kim Long Center gửi tặng đến qu&yacute; kh&aacute;ch h&agrave;ng chương tr&igrave;nh khuyến m&atilde;i si&ecirc;u n&oacute;ng&nbsp;bỏng trong th&aacute;ng tư n&agrave;y với tổng gi&aacute; trị qu&agrave; tặng l&ecirc;n đến&nbsp;<strong>100.000.000 VNĐ.&nbsp;</strong></p>

<p>&nbsp;</p>

<p><img alt="Vòng quay may mắn" src="https://kimlongcenter.com/upload/image/1200x628(1).png" /></p>

<p>&nbsp;</p>

<h2 dir="ltr"><strong>Nội Dung Chương Tr&igrave;nh:</strong></h2>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">Kh&aacute;ch h&agrave;ng nhập th&ocirc;ng tin v&agrave;o form đăng k&yacute; quay thưởng, sau đ&oacute; quay v&ograve;ng quay may mắn để nhận được một trong c&aacute;c qu&agrave; tặng sau:</p>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">1. N&oacute;n bảo hiểm Acer</p>

<p dir="ltr">2. Tai nghe Jabra talk 5</p>

<p dir="ltr">3. Ly Predator</p>

<p dir="ltr">4. Tai nghe HP 2800</p>

<p dir="ltr">5. Tai Nghe Lenovo Yoga</p>

<p dir="ltr">6. Balo K&eacute;o Chill Bag Acer H&Atilde;NG</p>
', N'/Content/Data/files/km.png', N'a2b988e6-9053-4c9d-b6fb-5ade0e050d18', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2019-06-07T22:44:24.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:07.3218843+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[News] ([Id], [Name], [Summary], [MetaTitle], [Description], [UrlImage], [NewsCategoryId], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [ViewCount], [Tag], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'bf7bbebb-a4e8-41fb-b1df-7a3492d72d57', N'MUA LAPTOP 8 THÁNG 3 - NHẬN QUÀ THẢ GA', N'MUA LAPTOP 8 THÁNG 3 - NHẬN QUÀ THẢ GA', N'MUA-LAPTOP-8-THANG-3-NHAN-QUA-THA-GA', N'<h1>MUA LAPTOP 8 TH&Aacute;NG 3 - NHẬN QU&Agrave; THẢ GA</h1>

<p>Thứ bảy, 06/03/2021 11:07</p>

<p dir="ltr">8/3 l&agrave; ng&agrave;y Quốc tế d&agrave;nh ri&ecirc;ng cho ph&aacute;i đẹp, v&agrave;o ng&agrave;y n&agrave;y hẳn c&aacute;c chị em phụ nữ ai cũng đều mong muốn nhận được nhiều niềm vui v&agrave; hạnh ph&uacute;c trọn vẹn. Đ&acirc;y cũng l&agrave; dịp để c&aacute;nh đ&agrave;n &ocirc;ng thể hiện t&igrave;nh cảm, sự quan t&acirc;m y&ecirc;u thương của m&igrave;nh tới một nửa xinh đẹp của thế giới th&ocirc;ng qua những m&oacute;n qu&agrave; nhiều &yacute; nghĩa.&nbsp;</p>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">V&agrave; để g&oacute;p th&ecirc;m niềm vui nh&acirc;n dịp đặc biệt n&agrave;y,&nbsp;<strong>Kim Long Center&nbsp;</strong>mang đến rất nhiều qu&agrave; tặng v&ocirc; c&ugrave;ng hấp dẫn d&agrave;nh ri&ecirc;ng cho Qu&yacute; Kh&aacute;ch h&agrave;ng nữ, với chương tr&igrave;nh khuyến m&atilde;i HOT&nbsp;<strong>&ldquo;MUA LAPTOP 8 TH&Aacute;NG 3 - NHẬN QU&Agrave; THẢ GA&rdquo;.&nbsp;</strong></p>

<p>&nbsp;</p>

<p dir="ltr">C&ugrave;ng với lời cảm ơn ch&acirc;n th&agrave;nh đến to&agrave;n bộ Qu&yacute; kh&aacute;ch h&agrave;ng đ&atilde; lu&ocirc;n tin tưởng, lựa chọn mua sắm sản phẩm v&agrave; sử dụng dịch vụ của Kim Long Center trong suốt những năm qua.</p>

<p dir="ltr">&nbsp;</p>

<h2 dir="ltr"><strong>Nội Dung Chương Tr&igrave;nh:</strong></h2>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">Khi c&aacute;c kh&aacute;ch h&agrave;ng nữ đến tham quan v&agrave; chọn mua bất kỳ sản phẩm laptop n&agrave;o tại Kim Long Center, sẽ c&oacute; 100% cơ hội nhận được một trong những phần qu&agrave; th&uacute; vị dưới đ&acirc;y:&nbsp;</p>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">- N&oacute;n bảo hiểm &frac34; Acer Predator&nbsp;</p>

<p dir="ltr">- Ly giữ nhiệt Acer Predator</p>

<p dir="ltr">- Balo k&eacute;o Chill Bag Acer</p>

<p dir="ltr">- Ổ cứng HDD 1TB Slim&nbsp;</p>

<p dir="ltr">- Ổ cứng SSD M2 SATA 180GB INTEL</p>

<p dir="ltr">- Ổ cứng HDD 500GB&nbsp;</p>

<p dir="ltr">- Tai Nghe HP 2800&nbsp;</p>

<p dir="ltr">- Tai nghe BT Jabra Talk 5</p>

<p dir="ltr">- Chuột MSI Bluetooth M98</p>

<p dir="ltr">- Ram 4GB</p>

<p dir="ltr">&nbsp;</p>

<h3 dir="ltr"><strong>*** Thời gian &aacute;p dụng:&nbsp;</strong>Bắt đầu từ ng&agrave;y 7/3 đến hết ng&agrave;y 10/3/2021.</h3>
', N'/Content/Data/files/km3.png', N'9d1fdd2c-e06d-402b-87de-f8746537bdbf', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2019-06-07T22:48:05.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:13.4641265+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[News] ([Id], [Name], [Summary], [MetaTitle], [Description], [UrlImage], [NewsCategoryId], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [ViewCount], [Tag], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'5bfd24f1-e085-49ff-abbd-e6bf4887042f', N'BỘ TỨ SIÊU SALE - TẶNG VOUCHER ĐẾN 2.000.000Đ', N'BỘ TỨ SIÊU SALE - TẶNG VOUCHER ĐẾN 2.000.000Đ', N'tung-bung-chao-he-sale', N'<h2><strong>BỘ TỨ SI&Ecirc;U SALE - TẶNG VOUCHER ĐẾN 2.000.000Đ</strong></h2>

<p>&nbsp;</p>

<p>Lenovo kết hợp c&ugrave;ng Kim Long Center mang đến chương tr&igrave;nh khuyến m&atilde;i hấp dẫn th&aacute;ng 8 n&agrave;y. &Aacute;p dụng cho &quot;bộ tứ laptop&quot; thuộc d&ograve;ng&nbsp;<strong>IdeaPad Gaming 3</strong>&nbsp;v&agrave;&nbsp;<strong>Legion 5</strong>&nbsp;với Voucher đến 2.000.000Đ.</p>

<p>&nbsp;</p>

<p><a href="https://kimlongcenter.com/tim-kiem.html?kw=KMLENOVO" target="_blank"><img alt="bộ tứ siêu sale" src="https://kimlongcenter.com/upload/image/%232020/B%E1%BB%98%20T%E1%BB%A8%20SI%C3%8AU%20SALE/BO-TU-SIEU-SALE.png" /></a></p>

<p>&nbsp;</p>

<h3><strong><img alt="enlightened" src="https://kimlongcenter.com/admin/js/ckeditor/plugins/smiley/images/lightbulb.png" title="enlightened" />&nbsp;Thời gian diễn ra chương tr&igrave;nh:</strong>&nbsp;từ ng&agrave;y 11/8 đến 31/8.<br />
&nbsp;</h3>

<h3><strong><img alt="enlightened" src="https://kimlongcenter.com/admin/js/ckeditor/plugins/smiley/images/lightbulb.png" title="enlightened" />&nbsp;</strong><strong>Nội dung chương tr&igrave;nh:</strong><br />
&nbsp;</h3>

<p>Khi mua 1 trong 4 laptop gaming Lenovo trong CTKM, bạn sẽ được chọn 1 trong 2 &nbsp;option qu&agrave; tặng sau:<br />
&nbsp;</p>

<p><strong><img alt="yes" src="https://kimlongcenter.com/admin/js/ckeditor/plugins/smiley/images/thumbs_up.png" title="yes" />&nbsp;OPTION 1 ( &Aacute;p dụng với gi&aacute; ni&ecirc;m yết):</strong><br />
&nbsp;</p>

<p>- Miễn ph&iacute; gấp đ&ocirc;i RAM laptop l&ecirc;n 16GB<br />
&nbsp;</p>

<p>- Tặng th&ecirc;m VOUCHER 1 TRIỆU ĐỒNG ( mua linh-phụ kiện v&agrave; được quyền trừ thẳng v&agrave;o gi&aacute; b&aacute;n).<br />
&nbsp;</p>

<p><strong><img alt="yes" src="https://kimlongcenter.com/admin/js/ckeditor/plugins/smiley/images/thumbs_up.png" title="yes" /></strong><strong>&nbsp;OPTION 2:</strong><br />
&nbsp;</p>

<p>- Tặng VOUCHER 2 TRIỆU ĐỒNG (đ&atilde; trừ v&agrave;o gi&aacute; ni&ecirc;m yết)<br />
&nbsp;</p>

<p><strong>||&nbsp;<a href="https://kimlongcenter.com/tim-kiem.html?kw=KMLENOVO" target="_blank">XEM DANH S&Aacute;CH SẢN PHẨM TẠI Đ&Acirc;Y</a></strong></p>

<p>&nbsp;</p>

<h3><strong>!!! LƯU &Yacute;:&nbsp;Chương tr&igrave;nh chỉ &aacute;p dụng cho kh&aacute;ch h&agrave;ng c&aacute; nh&acirc;n.</strong></h3>
', N'/Content/Data/files/km1.jpg', N'a2b988e6-9053-4c9d-b6fb-5ade0e050d18', NULL, N'tung-bung-chao-he-sale', NULL, NULL, NULL, NULL, CAST(N'2019-06-07T22:41:28.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:00.4723907+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[News] ([Id], [Name], [Summary], [MetaTitle], [Description], [UrlImage], [NewsCategoryId], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [ViewCount], [Tag], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'6e3a0fa5-b167-45e2-9039-fd4debea35e3', N'Black Friday 2020 - Sale Lớn Nhất Năm - Cam Kết Giá Rẻ Nhất Thị Trường', N'Black Friday 2020 - Sale Lớn Nhất Năm - Cam Kết Giá Rẻ Nhất Thị Trường', N'Black-Friday-2021-Sale-Lon-Nhat-Nam-Cam-Ket-Gia-Re-Nhat-The-Trung', N'<h2><strong>Black Friday 2020 - Sale Lớn Nhất Năm - Cam Kết Gi&aacute; Rẻ Nhất Thị Trường</strong><br />
&nbsp;</h2>

<p>Chương tr&igrave;nh săn sale laptop lớn nhất năm&nbsp;<strong>&quot;Black Friday&quot;</strong>&nbsp;đ&atilde; quay trở lại!!! Đừng bỏ lỡ cơ hội &quot;ẵm&quot; laptop với gi&aacute; RẺ NHẤT THỊ TRƯỜNG, ưu đ&atilde;i giảm mạnh tay đến 8.000.000đ&nbsp;k&egrave;m combo qu&agrave; hấp dẫn chưa từng c&oacute; tại Kim Long Center nh&eacute;.</p>

<p>&nbsp;</p>

<p><a href="https://kimlongcenter.com/black-friday-2020.html" target="_blank"><img alt="black friday 2020" src="https://kimlongcenter.com/upload/image/%232020/Black%20Friday%202020/1200x628%20WEB%20BANNER%20BF_final.png" /></a></p>

<p>&nbsp;</p>

<h3><strong><img alt="enlightened" src="https://kimlongcenter.com/admin/js/ckeditor/plugins/smiley/images/lightbulb.png" title="enlightened" />&nbsp;Nội dung chương tr&igrave;nh:</strong><br />
&nbsp;</h3>

<p>Trong tuần lễ&nbsp;<strong>Black Friday</strong>, khi kh&aacute;ch h&agrave;ng mua c&aacute;c sản phẩm laptop trong chương tr&igrave;nh sẽ được &aacute;p dụng giảm gi&aacute; trực tiếp k&egrave;m nhiều qu&agrave; tặng hấp dẫn:<br />
&nbsp;</p>

<p>✅ &Aacute;p dụng hơn 40 sản phẩm laptop. Từ d&ograve;ng văn ph&ograve;ng, đồ họa, gaming đến cao cấp.</p>

<p>✅ Ưu đ&atilde;i giảm gi&aacute; trực tiếp đến&nbsp;<strong>8.000.000đ.</strong></p>

<p>✅ Tặng Key Windows 10 Pro bản quyền*</p>

<p>✅ Giảm gi&aacute; n&acirc;ng cấp RAM, HDD,..*</p>

<p>✅ V&agrave; c&ograve;n rất nhiều qu&agrave; tặng kh&aacute;c như balo, tai nghe ch&iacute;nh h&atilde;ng, vali k&eacute;o,... đang đợi c&aacute;c bạn rinh về nữa đ&oacute;.</p>
', N'/Content/Data/files/km4.png', N'c787ffc1-f333-484e-b176-c76d5c3d85a7', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2019-06-06T13:06:58.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:57.7066975+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[NewsCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'a2b988e6-9053-4c9d-b6fb-5ade0e050d18', N'Khuyến mãi', N'khuyen-mai', NULL, 1, N'khuyen-mai', N'khuyen-mai', CAST(N'2019-06-06T12:35:39.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:22.4287490+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[NewsCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'c787ffc1-f333-484e-b176-c76d5c3d85a7', N'Chăm sóc khách hàng', N'cham-soc-khach-hang', NULL, 3, N'cham-soc-khach-hang', N'cham-soc-khach-hang', CAST(N'2019-06-06T12:36:29.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:19.7567273+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[NewsCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'9d1fdd2c-e06d-402b-87de-f8746537bdbf', N'Sự kiện', N'su-kien', NULL, 2, N'su-kien', N'su-kien', CAST(N'2019-06-06T12:36:06.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:25:21.1355229+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Order] ([Id], [UserId], [ShipName], [ShipPhone], [ShipAddress], [ShipEmail], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'c32c881d-86d5-43f2-ac6b-48663bbfdcb2', N'e5e3f57d-1f9e-42f3-9b53-5efe5d5f442c', N'win nguyen', N'0384443456', N'Địa chỉ: 261 - 263 Khánh Hội, P5, Q4, TP. Hồ Chí Minh', N'winwin260299@gmail.com', 1, CAST(N'2022-02-18T20:18:21.0061616+07:00' AS DateTimeOffset), N'test1', NULL, NULL, 0)
INSERT [dbo].[Order] ([Id], [UserId], [ShipName], [ShipPhone], [ShipAddress], [ShipEmail], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'24a01a06-a838-4d65-8ecb-5860c7d0f350', N'e5e3f57d-1f9e-42f3-9b53-5efe5d5f442c', N'win nguyen', N'0384443456', N'Địa chỉ: 261 - 263 Khánh Hội, P5, Q4, TP. Hồ Chí Minh', N'winwin260299@gmail.com', 1, CAST(N'2022-02-18T20:18:21.0061616+07:00' AS DateTimeOffset), N'test1', NULL, NULL, 0)
INSERT [dbo].[Order] ([Id], [UserId], [ShipName], [ShipPhone], [ShipAddress], [ShipEmail], [Status], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'1ceeeb15-8d57-4b63-802f-9c7afaa25956', N'e5e3f57d-1f9e-42f3-9b53-5efe5d5f442c', N'win nguyen', N'0384443444', N'Địa chỉ: 261 - 263 Khánh Hội, P5, Q4, TP. Hồ Chí Minh', N'winwin260299@gmail.com', 1, CAST(N'2022-02-18T20:18:21.0061616+07:00' AS DateTimeOffset), N'test1', NULL, NULL, 0)
INSERT [dbo].[OrderDetail] ([ProductId], [OrderId], [Quantity], [Price], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'e8ab3637-5fa0-4b12-93ce-0e11bde67845', N'c32c881d-86d5-43f2-ac6b-48663bbfdcb2', 1, CAST(299000 AS Decimal(18, 0)), CAST(N'2022-02-18T20:18:21.0299522+07:00' AS DateTimeOffset), N'test1', NULL, NULL, 0)
INSERT [dbo].[OrderDetail] ([ProductId], [OrderId], [Quantity], [Price], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'44a76484-6ac2-4d48-a5c7-97448c545ab0', N'24a01a06-a838-4d65-8ecb-5860c7d0f350', 1, CAST(3590000 AS Decimal(18, 0)), CAST(N'2021-04-08T23:48:15.2031599+07:00' AS DateTimeOffset), N'test1', NULL, NULL, 0)
INSERT [dbo].[OrderDetail] ([ProductId], [OrderId], [Quantity], [Price], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'44a76484-6ac2-4d48-a5c7-97448c545ab0', N'1ceeeb15-8d57-4b63-802f-9c7afaa25956', 1, CAST(3590000 AS Decimal(18, 0)), CAST(N'2021-04-07T16:32:12.5662333+07:00' AS DateTimeOffset), N'test1', NULL, NULL, 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'8cf42ce1-6f0d-4d97-9b1d-03cf821bf39e', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t14.jpg', CAST(3590000 AS Decimal(18, 0)), NULL, 0, 5, N'185e17eb-86c3-4323-8faf-6fcbb2e7bd08', N'Chạy nhanh hơn, chạy xa hơn với công nghệ Floatride Run và Fleaxweave (TM)', NULL, N'reebok-floatride-run-flexweave', NULL, NULL, 1, NULL, NULL, NULL, CAST(N'2019-06-05T12:48:56.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:22:57.4007922+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'836c11c8-c252-45b6-9604-08de7011869a', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/r1.png', CAST(2000000 AS Decimal(18, 0)), NULL, 0, 5, N'35f18486-b2b4-472e-9c90-071466e5bb2d', N'SKU: 164225C, Chất liệu: Da, Màu sắc: Trắng', NULL, N'converse-jack-purcell-leather', N'converse-jack-purcell-leather', NULL, NULL, 1, NULL, NULL, CAST(N'2019-06-05T12:17:43.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:22:59.5984328+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'e8ab3637-5fa0-4b12-93ce-0e11bde67845', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/c1.jpg', CAST(299000 AS Decimal(18, 0)), NULL, 0, 19, N'de613250-d551-435b-9613-2f67164a78f6', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, CAST(N'2019-06-03T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2021-04-07T16:20:17.6163669+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'74126328-626b-450b-8728-143e2a32a202', N'Laptop Dell G3 15 i5 10300H', CAST(300000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
</ul>
', N'/Content/Data/files/t15.jpg', CAST(400000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), NULL, 50, N'f4e587a0-d114-4f30-946c-04c30e01b730', N'qwertyuiopasdfghjkl', NULL, N'hoa-hoc-11', NULL, 1, 1, 1, 1, NULL, CAST(N'2020-12-11T14:26:54.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:00.0318843+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'07b8ca65-0fa3-4aad-aace-1944c6740869', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t6(1).jpg', CAST(1300000 AS Decimal(18, 0)), NULL, 0, 5, N'35f18486-b2b4-472e-9c90-071466e5bb2d', N'SKU: 564345C, Chất liệu: Textile,  Màu sắc: Xanh', NULL, N'converse-chuck-taylor', NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-06-05T12:21:03.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:11.6252524+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'79ecab79-012d-4a7a-896d-3ea453a7d4ec', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/22.jpg', CAST(1750000 AS Decimal(18, 0)), NULL, 0, 6, N'dc7469a5-a82d-4e56-863b-e2f6f1fcf15d', N'SKU: VN0A38G1VFV Chất liệu: Da lộn/Canvas Màu sắc: Stickers/True White', NULL, N'vans-oldskool-mash-up-stickers', N'vans-oldskool-mash-up-stickers', NULL, 1, NULL, NULL, NULL, CAST(N'2019-06-05T12:29:41.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:15.4554561+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'd22b1e54-b2d1-4375-86b7-41596036ab8c', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t3.jpg', CAST(759000 AS Decimal(18, 0)), CAST(590000 AS Decimal(18, 0)), 0, 20, N'f4e587a0-d114-4f30-946c-04c30e01b730', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, CAST(N'2019-05-04T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:18.8248043+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'6af940c9-ab84-40f8-b433-42daec387bb9', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
</ul>
', N'/Content/Data/files/t1.jpg', CAST(699000 AS Decimal(18, 0)), CAST(590000 AS Decimal(18, 0)), 0, 20, N'f4e587a0-d114-4f30-946c-04c30e01b730', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, CAST(N'2019-06-04T11:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:22.9672873+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'510c5367-ff16-4646-9cd8-44770a7748d7', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t2.jpg', CAST(599000 AS Decimal(18, 0)), CAST(499000 AS Decimal(18, 0)), 0, 20, N'f4e587a0-d114-4f30-946c-04c30e01b730', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-06-01T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:27.4102680+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'c042f922-9fd4-4a0e-8056-8e904cc5e5cf', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t9.jpg', CAST(699000 AS Decimal(18, 0)), NULL, 0, 20, N'1e1200ae-1d12-4306-92ac-b05ac0bcf8ec', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-05-30T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:30.3871359+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'b14e06c8-8cd6-4c9c-b3a3-95ea614e799a', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t8.jpg', CAST(759000 AS Decimal(18, 0)), NULL, 0, 20, N'1e1200ae-1d12-4306-92ac-b05ac0bcf8ec', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-05-24T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:43.1752418+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'44a76484-6ac2-4d48-a5c7-97448c545ab0', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
</ul>
', N'/Content/Data/files/t3.jpg', CAST(3590000 AS Decimal(18, 0)), NULL, 0, 3, N'49df2e48-4b19-477c-a87b-aec64de21e48', N'New Balance 572 là mẫu giày mang thiết kế đẹp mắt, trẻ trung, có thể được xếp vào danh sách không bao giờ lỗi mốt của New Balance.', NULL, N'new-balance-572', N'new-balance-572', NULL, NULL, NULL, 1, NULL, CAST(N'2019-06-05T12:57:38.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:47.1121583+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'11b4d958-69e7-47b5-afe0-9f1b49e1b01e', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/21.jpg', CAST(2200000 AS Decimal(18, 0)), NULL, 0, 5, N'dc7469a5-a82d-4e56-863b-e2f6f1fcf15d', N'SKU: VN0A3WM9VNO, Chất liệu: Vải Canvas, Màu sắc: Xanh/Vàng', NULL, N'vans-comfycush-era', N'vans-comfycush-era', NULL, 1, NULL, NULL, NULL, CAST(N'2019-06-05T12:44:24.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:23:55.5516533+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'c9d85df8-6a73-4c5f-b10e-a7a73bd0e09a', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t11.jpg', CAST(259000 AS Decimal(18, 0)), NULL, 0, 20, N'1e1200ae-1d12-4306-92ac-b05ac0bcf8ec', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2019-06-03T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2021-04-07T16:22:15.8695814+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'59ded37f-c008-4f40-9af6-c34691f826e2', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/c2.jpg', CAST(229000 AS Decimal(18, 0)), NULL, 0, 20, N'1e1200ae-1d12-4306-92ac-b05ac0bcf8ec', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-05-21T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:04.9692139+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'a410db7a-d414-41df-bad6-c6c636940977', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t16.jpg', CAST(1750000 AS Decimal(18, 0)), NULL, 0, 10, N'dc7469a5-a82d-4e56-863b-e2f6f1fcf15d', N'SKU: VN0A38G1VFV Chất liệu: Da lộn/Canvas Màu sắc: Stickers/True White', NULL, N'van', NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-06-08T12:03:57.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:11.2158056+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'90bff1e5-4b44-4d2c-813b-c94fdad898ff', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t10.jpg', CAST(599000 AS Decimal(18, 0)), NULL, 0, 20, N'1e1200ae-1d12-4306-92ac-b05ac0bcf8ec', NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, CAST(N'2019-05-25T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:18.1122790+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'1cdc746d-7b42-4666-baad-d3ca4411b2fe', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t13.jpg', CAST(499000 AS Decimal(18, 0)), NULL, 0, 20, N'9f0de121-5036-4a23-a37e-176e1fab5ffc', NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, CAST(N'2019-05-26T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:24.6874311+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'cc41105a-fde4-4e45-b479-d84e35b6f6e2', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t4.jpg', CAST(999000 AS Decimal(18, 0)), NULL, 0, 20, N'f4e587a0-d114-4f30-946c-04c30e01b730', NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, CAST(N'2019-05-28T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:30.2973206+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'c4ecf378-3f7a-42da-af1c-e16ba17e5b6b', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<p><strong>Gi&agrave;y Nike Air Force 1 Mid &#39;07<br />
Nguồn gốc:&nbsp;&nbsp; &nbsp;Ch&iacute;nh h&atilde;ng<br />
H&atilde;ng sản xuất:&nbsp;&nbsp; &nbsp;Nike<br />
Mục đ&iacute;ch sử dụng:&nbsp;&nbsp; &nbsp;Gi&agrave;y đi h&agrave;ng ng&agrave;y, gi&agrave;y thể thao chạy bộ<br />
K&iacute;ch cỡ:&nbsp;&nbsp; &nbsp;36-44<br />
M&agrave;u sắc:&nbsp;&nbsp; &nbsp;Nhiều m&agrave;u<br />
T&igrave;nh trạng:&nbsp;&nbsp; &nbsp;Mới 100%, Full box<br />
M&atilde; SP:&nbsp;&nbsp; &nbsp;#82NK007</strong></p>
', N'/Content/Data/files/t7.jpg', CAST(1190000 AS Decimal(18, 0)), NULL, 0, 20, N'1e1200ae-1d12-4306-92ac-b05ac0bcf8ec', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2019-06-02T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:35.1998590+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'73586220-5579-426b-b831-ed1f166ae0f1', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/23.jpg', CAST(199000 AS Decimal(18, 0)), CAST(99000 AS Decimal(18, 0)), 0, 9, N'f4e587a0-d114-4f30-946c-04c30e01b730', NULL, NULL, N'yzy-350-hag-f1', NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-06-05T12:02:25.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:38.8238642+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'7bcd2a38-03a1-4cee-be22-ef7a628acf27', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t5.jpg', CAST(950000 AS Decimal(18, 0)), CAST(850000 AS Decimal(18, 0)), 0, 9, N'4af55b5a-7ef5-4026-ae30-675149352730', NULL, NULL, N'balenciaga-triple-s', NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2019-06-05T12:07:32.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:43.5827666+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Product] ([Id], [Name], [Code], [MetaTitle], [Description], [UrlImage], [Price], [PromotionPrice], [IncludeVAT], [Quantity], [ProductCategoryId], [Detail], [Warranty], [MetaKeywords], [MetaDescriptions], [TopHot], [IsNormalProduct2], [IsNormalProduct1], [IsNewProduct], [ViewCount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'd2c573a6-7c30-49b7-8173-f1d3c18fe5bf', N'Laptop Dell G3 15 i5 10300H', CAST(200000 AS Decimal(18, 0)), N'Laptop-Dell-G3-15-i5-10300H', N'<ul>
	<li>
	<p>15.6&quot;, 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit</p>
	</li>
	<li>
	<p>Intel Core i5-10300H</p>
	</li>
	<li>
	<p>8 GB, DDR4, 2933 MHz</p>
	</li>
	<li>
	<p>HDD 1000 GB &amp; SSD 256 GB</p>
	</li>
	<li>
	<p>GeForce GTX 1650 4GB</p>
	</li>
</ul>
', N'/Content/Data/files/t12.jpg', CAST(1990000 AS Decimal(18, 0)), CAST(1290000 AS Decimal(18, 0)), 0, 20, N'9f0de121-5036-4a23-a37e-176e1fab5ffc', NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, CAST(N'2019-04-24T15:18:33.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-02-18T20:24:47.7672969+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'f4e587a0-d114-4f30-946c-04c30e01b730', N'DELL', N'DELL', NULL, 1, N'DELL', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:08:15.6541101+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'35f18486-b2b4-472e-9c90-071466e5bb2d', N'MACBOOK', N'MACBOOK', NULL, 2, N'MACBOOK', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:09:04.4967341+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'9f0de121-5036-4a23-a37e-176e1fab5ffc', N'Asus', N'Asus', NULL, 3, N'Asus', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:09:32.3864173+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'de613250-d551-435b-9613-2f67164a78f6', N'ACER', N'ACER', NULL, 4, N'ACER', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:10:01.1838065+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'4af55b5a-7ef5-4026-ae30-675149352730', N'HP Envy', N'HPEnvy', NULL, 5, N'HPEnvy', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:10:30.3201450+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'185e17eb-86c3-4323-8faf-6fcbb2e7bd08', N'Lenovo', N'Lenovo', NULL, 6, N'Lenovo', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:10:56.2432729+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'49df2e48-4b19-477c-a87b-aec64de21e48', N'HP Spectre', N'HPSpectre', NULL, 7, N'HPSpectre', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:11:35.0385278+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'1e1200ae-1d12-4306-92ac-b05ac0bcf8ec', N'Laptop Avita', N'LaptopAvita', NULL, 8, N'LaptopAvita', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:13:08.2721075+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[ProductCategory] ([Id], [Name], [MetaTitle], [ParentId], [DisplayOrder], [SeoTitle], [MetaKeywords], [MetaDescriptions], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'dc7469a5-a82d-4e56-863b-e2f6f1fcf15d', N'MSI', N'MSI', NULL, 9, N'MSI', NULL, NULL, NULL, N'admin', CAST(N'2021-04-07T16:12:43.3268422+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'ADD_USER', N'Thêm User')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'CREATE_CREDENTIAL', N'Thêm Credential')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'CREATE_ROLE', N'Thêm Role')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'CREATE_USER_GROUP', N'Thêm UserGroup')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'DELETE_CREDENTIAL', N'Xóa Credential')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'DELETE_ROLE', N'Xóa Role')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'DELETE_USER', N'Xóa User')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'DELETE_USER_GROUP', N'Xóa UserGroup')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'EDIT_USER', N'Cập nhật User')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'UPDATE_CREDENTIAL', N'Cập nhật Credential')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'UPDATE_ROLE', N'Cập nhật Role')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'UPDATE_USER_GROUP', N'Cập nhật UserGroup')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'VIEW_CREDENTIAL', N'Xem Credential')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'VIEW_LAYOUT', N'Xem giao diện')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'VIEW_ROLE', N'Xem Role')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'VIEW_USER', N'Xem User')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'VIEW_USER_GROUP', N'Xem UserGroup')
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([Id], [UrlImage], [DisplayOrder], [Link], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (1, N'/Content/Data/files/lide3.jpg', 1, NULL, NULL, NULL, N'admin', CAST(N'2022-02-18T20:21:52.7601129+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Slide] ([Id], [UrlImage], [DisplayOrder], [Link], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (2, N'/Content/Data/files/lide2.jpg', 2, NULL, N'no', NULL, N'admin', CAST(N'2022-02-18T20:21:51.1372780+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[Slide] ([Id], [UrlImage], [DisplayOrder], [Link], [Description], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (3, N'/Content/Data/images/lide1.jpg', 3, NULL, N'no', NULL, N'admin', CAST(N'2022-02-18T20:21:49.5874621+07:00' AS DateTimeOffset), N'admin', 0)
SET IDENTITY_INSERT [dbo].[Slide] OFF
INSERT [dbo].[User] ([Id], [GroupId], [AvatarUrl], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [ResetPasswordCode], [Email], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'b9c6d5c0-e616-40a0-9f04-202a371075b3', N'ADMIN', N'/Content/Data/files/banner2.jpg', N'admin', N'0192023a7bbd73250516f069df18b500', N'0192023a7bbd73250516f069df18b500', N'nguyen van', N'A', NULL, N'nghia38511@ubk.edu.vn', N'Đà Nẵng', CAST(N'2019-04-21T15:31:55.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2022-02-18T20:29:15.1310553+07:00' AS DateTimeOffset), N'admin', 0)
INSERT [dbo].[User] ([Id], [GroupId], [AvatarUrl], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [ResetPasswordCode], [Email], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) VALUES (N'e5e3f57d-1f9e-42f3-9b53-5efe5d5f442c', N'MEMBER', NULL, N'test1', N'4297f44b13955235245b2497399d7a93', N'4297f44b13955235245b2497399d7a93', N'win', N'nguyen', NULL, N'winwin260299@gmail.com', N'Địa chỉ: 261 - 263 Khánh Hội, P5, Q4, TP. Hồ Chí Minh', CAST(N'2021-04-07T14:02:03.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2022-02-18T20:17:56.1499012+07:00' AS DateTimeOffset), N'test1', 0)
INSERT [dbo].[UserGroup] ([Id], [Name]) VALUES (N'ADMIN', N'Quản trị')
INSERT [dbo].[UserGroup] ([Id], [Name]) VALUES (N'MEMBER', N'Thành viên')
INSERT [dbo].[UserGroup] ([Id], [Name]) VALUES (N'MOD', N'Moderitor')
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK__Content__Categor__412EB0B6] FOREIGN KEY([NewsCategoryId])
REFERENCES [dbo].[NewsCategory] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK__Content__Categor__412EB0B6]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Product__5070F446] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Product__5070F446]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UserGroup] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserGroup]
GO

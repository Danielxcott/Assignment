USE [Pet]
GO
/****** Object:  Table [dbo].[cats]    Script Date: 12/9/2022 2:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cats](
	[cat_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_cats] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dogs]    Script Date: 12/9/2022 2:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dogs](
	[dog_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dogs] PRIMARY KEY CLUSTERED 
(
	[dog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cats] ON 

INSERT [dbo].[cats] ([cat_id], [name]) VALUES (1, N'whiskers')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (2, N'Felix')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (3, N'Fluffy')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (4, N'Angel')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (5, N'Lady')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (6, N'Snow')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (7, N'Lucky')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (8, N'Lola')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (9, N'Luna')
INSERT [dbo].[cats] ([cat_id], [name]) VALUES (10, N'Smokey')
SET IDENTITY_INSERT [dbo].[cats] OFF
GO
SET IDENTITY_INSERT [dbo].[dogs] ON 

INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (1, N'Lucky')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (2, N'Snow')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (3, N'Golden')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (4, N'Bella')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (5, N'Daisy')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (6, N'Lucy')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (7, N'Lola')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (8, N'Jack')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (9, N'Bear')
INSERT [dbo].[dogs] ([dog_id], [name]) VALUES (10, N'Rocky')
SET IDENTITY_INSERT [dbo].[dogs] OFF
GO

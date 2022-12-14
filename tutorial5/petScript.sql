USE [Pet]
GO
/****** Object:  Table [dbo].[Cats]    Script Date: 12/9/2022 2:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cats](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cats] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dogs]    Script Date: 12/9/2022 2:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dogs](
	[DogId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dogs] PRIMARY KEY CLUSTERED 
(
	[DogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cats] ON 

INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (1, N'whiskers')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (2, N'Felix')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (3, N'Fluffy')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (4, N'Angel')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (5, N'Lady')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (6, N'Snow')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (7, N'Lucky')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (8, N'Lola')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (9, N'Luna')
INSERT [dbo].[Cats] ([CatId], [Name]) VALUES (10, N'Smokey')
SET IDENTITY_INSERT [dbo].[Cats] OFF
GO
SET IDENTITY_INSERT [dbo].[Dogs] ON 

INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (1, N'Lucky')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (2, N'Snow')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (3, N'Golden')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (4, N'Bella')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (5, N'Daisy')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (6, N'Lucy')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (7, N'Lola')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (8, N'Jack')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (9, N'Bear')
INSERT [dbo].[Dogs] ([DogId], [Name]) VALUES (10, N'Rocky')
SET IDENTITY_INSERT [dbo].[Dogs] OFF
GO

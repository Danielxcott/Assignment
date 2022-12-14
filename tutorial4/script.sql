USE [Cinema]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 12/9/2022 12:03:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Address] [text] NOT NULL,
	[SalutationId] [int] NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 12/9/2022 12:03:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MemberId] [int] NOT NULL,
	[MoviesRented] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salutations]    Script Date: 12/9/2022 12:03:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salutations](
	[SalutationId] [int] IDENTITY(1,1) NOT NULL,
	[Salutation] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Salutations] PRIMARY KEY CLUSTERED 
(
	[SalutationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([MemberId], [Fullname], [Address], [SalutationId]) VALUES (1, N'Sandy', N'First Street Plot No 4', 2)
INSERT [dbo].[Members] ([MemberId], [Fullname], [Address], [SalutationId]) VALUES (2, N'John', N'Second Street Plot No 5', 1)
INSERT [dbo].[Members] ([MemberId], [Fullname], [Address], [SalutationId]) VALUES (3, N'Jonet Jones', N'Second Street Plot No 7', 1)
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
INSERT [dbo].[Movies] ([MemberId], [MoviesRented]) VALUES (1, N'Daddy''s Little Girls')
INSERT [dbo].[Movies] ([MemberId], [MoviesRented]) VALUES (1, N'Clash of the Titans')
INSERT [dbo].[Movies] ([MemberId], [MoviesRented]) VALUES (2, N'Forgetting Sarah Marshal')
INSERT [dbo].[Movies] ([MemberId], [MoviesRented]) VALUES (2, N'Clash of the Titans')
INSERT [dbo].[Movies] ([MemberId], [MoviesRented]) VALUES (3, N'Daddy''s Little Girls')
GO
SET IDENTITY_INSERT [dbo].[Salutations] ON 

INSERT [dbo].[Salutations] ([SalutationId], [Salutation]) VALUES (1, N'Mr')
INSERT [dbo].[Salutations] ([SalutationId], [Salutation]) VALUES (2, N'Ms')
SET IDENTITY_INSERT [dbo].[Salutations] OFF
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Salutations] FOREIGN KEY([SalutationId])
REFERENCES [dbo].[Salutations] ([SalutationId])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Salutations]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Members]
GO

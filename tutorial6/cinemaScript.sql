USE [Cinema]
GO
/****** Object:  Table [dbo].[members]    Script Date: 12/9/2022 3:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[members](
	[memberId] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[address] [text] NOT NULL,
	[salutationId] [int] NOT NULL,
 CONSTRAINT [PK_members] PRIMARY KEY CLUSTERED 
(
	[memberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movies]    Script Date: 12/9/2022 3:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies](
	[memberId] [int] NOT NULL,
	[moviesRented] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salutations]    Script Date: 12/9/2022 3:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salutations](
	[salutationId] [int] IDENTITY(1,1) NOT NULL,
	[salutation] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_salutations] PRIMARY KEY CLUSTERED 
(
	[salutationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[members] ON 

INSERT [dbo].[members] ([memberId], [fullname], [address], [salutationId]) VALUES (1, N'Sandy', N'First Street Plot No 4', 2)
INSERT [dbo].[members] ([memberId], [fullname], [address], [salutationId]) VALUES (2, N'John', N'Second Street Plot No 5', 1)
INSERT [dbo].[members] ([memberId], [fullname], [address], [salutationId]) VALUES (3, N'Jonet Jones', N'Second Street Plot No 7', 1)
SET IDENTITY_INSERT [dbo].[members] OFF
GO
INSERT [dbo].[movies] ([memberId], [moviesRented]) VALUES (1, N'Daddy''s Little Girls')
INSERT [dbo].[movies] ([memberId], [moviesRented]) VALUES (1, N'Clash of the Titans')
INSERT [dbo].[movies] ([memberId], [moviesRented]) VALUES (2, N'Forgetting Sarah Marshal')
INSERT [dbo].[movies] ([memberId], [moviesRented]) VALUES (2, N'Clash of the Titans')
INSERT [dbo].[movies] ([memberId], [moviesRented]) VALUES (3, N'Daddy''s Little Girls')
GO
SET IDENTITY_INSERT [dbo].[salutations] ON 

INSERT [dbo].[salutations] ([salutationId], [salutation]) VALUES (1, N'Mr')
INSERT [dbo].[salutations] ([salutationId], [salutation]) VALUES (2, N'Ms')
SET IDENTITY_INSERT [dbo].[salutations] OFF
GO
ALTER TABLE [dbo].[members]  WITH CHECK ADD  CONSTRAINT [FK_members_salutations] FOREIGN KEY([salutationId])
REFERENCES [dbo].[salutations] ([salutationId])
GO
ALTER TABLE [dbo].[members] CHECK CONSTRAINT [FK_members_salutations]
GO
ALTER TABLE [dbo].[movies]  WITH CHECK ADD  CONSTRAINT [FK_movies_members] FOREIGN KEY([memberId])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[movies] CHECK CONSTRAINT [FK_movies_members]
GO

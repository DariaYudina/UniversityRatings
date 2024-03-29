USE [UniversityRating]
GO
/****** Object:  Table [dbo].[CHARTDATA]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHARTDATA](
	[ChartDataId] [int] IDENTITY(1,1) NOT NULL,
	[ChartTimeStamp] [datetime] NOT NULL,
	[ChartValue] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ChartDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indicator]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicator](
	[Indicator_Id] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorName] [nvarchar](300) NULL,
 CONSTRAINT [PK_Indicator] PRIMARY KEY CLUSTERED 
(
	[Indicator_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indicators]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicators](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[University_Id] [int] NULL,
	[Value] [int] NULL,
	[UnitOfMeasure] [nvarchar](300) NULL,
	[Year] [int] NULL,
	[Indicator_Id] [int] NULL,
 CONSTRAINT [PK_Indicators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Rating_Id] [int] IDENTITY(1,1) NOT NULL,
	[University_Id] [int] NULL,
	[RatingValue] [float] NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[Rating_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Universities]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[University_Id] [int] IDENTITY(1,1) NOT NULL,
	[UniversityName] [nvarchar](300) NULL,
 CONSTRAINT [PK_Universities1] PRIMARY KEY CLUSTERED 
(
	[University_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](300) NULL,
	[Password] [nvarchar](300) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHARTDATA] ADD  DEFAULT (getdate()) FOR [ChartTimeStamp]
GO
ALTER TABLE [dbo].[Indicators]  WITH CHECK ADD  CONSTRAINT [FK_Indicators_Indicator] FOREIGN KEY([Indicator_Id])
REFERENCES [dbo].[Indicator] ([Indicator_Id])
GO
ALTER TABLE [dbo].[Indicators] CHECK CONSTRAINT [FK_Indicators_Indicator]
GO
ALTER TABLE [dbo].[Indicators]  WITH CHECK ADD  CONSTRAINT [FK_Indicators_Universities] FOREIGN KEY([University_Id])
REFERENCES [dbo].[Universities] ([University_Id])
GO
ALTER TABLE [dbo].[Indicators] CHECK CONSTRAINT [FK_Indicators_Universities]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Universities] FOREIGN KEY([University_Id])
REFERENCES [dbo].[Universities] ([University_Id])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Universities]
GO
/****** Object:  StoredProcedure [dbo].[AddRating]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddRating]
	-- Add the parameters for the stored procedure here
	 @University_Id int,
	 @RatingValue int
AS
BEGIN 
	insert into Ratings( University_Id, RatingValue)
	values (@University_Id, @RatingValue);
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllIndicators]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllIndicators]
	 @UniversityId int
AS
BEGIN
	select Ind.Indicator_Id, Ind.University_Id, Ind.IndicatorName, Ind.[Value], Ind.UnitOfMeasure, Univ.UniversityName from Indicators as Ind
	join Universities as Univ on Ind.University_Id = Univ.University_Id
	where Ind.University_Id = @UniversityId 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers] AS
SELECT [Login], [Password], [Role]
FROM Users
GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterUser] 
	-- Add the parameters for the stored procedure here
	 @Login nvarchar(300),
	 @Password nvarchar(300),
	 @Role nvarchar(300)
AS
BEGIN 
	insert into Users ([Login],[Password], [Role])
	values (@Login, @Password, @Role);
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateIndicator]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:

CREATE PROCEDURE [dbo].[UpdateIndicator]
	 @Indicator_Id int,
	 @Value int
AS
BEGIN 
	Update Indicators
	Set [Value] = @Value
	where [Indicator_Id] = @Indicator_Id ;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRating]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRating]
	-- Add the parameters for the stored procedure here
	 @Rating_Id int,
	 @University_Id int,
	 @RatingValue int
AS
BEGIN 
	Update Ratings
	Set [RatingValue] = @RatingValue
	where [Rating_Id] = @Rating_Id and University_Id = @University_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoleUser]    Script Date: 6/2/2021 9:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRoleUser]
	 @Login nvarchar(300),
	 @Role nvarchar(300)
AS
BEGIN
	Update Users
	Set [Role] = @Role
	where [Login] = @Login;
END
GO

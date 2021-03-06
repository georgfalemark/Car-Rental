USE [master]
GO
/****** Object:  Database [BiluthyrningAB_GeorgF�lemark]    Script Date: 2019-03-08 18:35:27 ******/
CREATE DATABASE [BiluthyrningAB_GeorgF�lemark]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BiluthyrningAB_GeorgF�lemark', FILENAME = N'C:\Users\Administrator\BiluthyrningAB_GeorgF�lemark.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BiluthyrningAB_GeorgF�lemark_log', FILENAME = N'C:\Users\Administrator\BiluthyrningAB_GeorgF�lemark_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BiluthyrningAB_GeorgF�lemark].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET ARITHABORT OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET  MULTI_USER 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET QUERY_STORE = OFF
GO
USE [BiluthyrningAB_GeorgF�lemark]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BiluthyrningAB_GeorgF�lemark]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2019-03-08 18:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 2019-03-08 18:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingId] [uniqueidentifier] NOT NULL,
	[NumberOfKm] [decimal](18, 2) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[ReturnDate] [datetime2](7) NOT NULL,
	[CarId] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[OnGoing] [bit] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 2019-03-08 18:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [uniqueidentifier] NOT NULL,
	[LicenseNumber] [nvarchar](max) NOT NULL,
	[CarType] [int] NOT NULL,
	[NumberOfDrivenKm] [int] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2019-03-08 18:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[PersonNumber] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190305181857_migration1', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190306095354_migration2', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190308105113_migge3', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190308134128_migge4', N'2.1.4-rtm-31024')
INSERT [dbo].[Bookings] ([BookingId], [NumberOfKm], [StartDate], [ReturnDate], [CarId], [CustomerId], [OnGoing]) VALUES (N'409b1d82-62df-4870-9036-22343dc90e5d', CAST(77.00 AS Decimal(18, 2)), CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-01-06T00:00:00.0000000' AS DateTime2), N'b6d0c6c7-a3f2-49cc-a4dd-802756c3dde4', N'575711d4-58ab-48ca-b996-e35eeb70ecda', 0)
INSERT [dbo].[Bookings] ([BookingId], [NumberOfKm], [StartDate], [ReturnDate], [CarId], [CustomerId], [OnGoing]) VALUES (N'7c8aeac1-72be-49f8-872c-47226e4e060f', CAST(44.00 AS Decimal(18, 2)), CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-01-06T00:00:00.0000000' AS DateTime2), N'd3694a38-f966-4753-8cab-23725a8289ba', N'575711d4-58ab-48ca-b996-e35eeb70ecda', 1)
INSERT [dbo].[Bookings] ([BookingId], [NumberOfKm], [StartDate], [ReturnDate], [CarId], [CustomerId], [OnGoing]) VALUES (N'e60e7534-f271-4de3-8dfd-92215d28a948', CAST(777.00 AS Decimal(18, 2)), CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-01-19T00:00:00.0000000' AS DateTime2), N'4684bdfc-3cd3-43a4-8e52-014c7079640b', N'6dba17cd-a4ed-4b16-9dcc-78e347cbfe53', 0)
INSERT [dbo].[Bookings] ([BookingId], [NumberOfKm], [StartDate], [ReturnDate], [CarId], [CustomerId], [OnGoing]) VALUES (N'a20a1bf8-5b23-4c29-b788-9b4ea511f234', CAST(0.00 AS Decimal(18, 2)), CAST(N'2018-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2018-06-02T00:00:00.0000000' AS DateTime2), N'0583ff36-ba9e-43ad-a932-c074dca144ae', N'8dcf2a25-0451-46d6-aeda-b2025c6de46a', 1)
INSERT [dbo].[Bookings] ([BookingId], [NumberOfKm], [StartDate], [ReturnDate], [CarId], [CustomerId], [OnGoing]) VALUES (N'2676d7df-3a5c-4566-b081-f725f6f4668f', CAST(0.00 AS Decimal(18, 2)), CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-01-02T00:00:00.0000000' AS DateTime2), N'90e1f4fd-ec2b-4dcb-ada5-26655aba1bb6', N'8dcf2a25-0451-46d6-aeda-b2025c6de46a', 1)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'4684bdfc-3cd3-43a4-8e52-014c7079640b', N'GGG789', 1, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'20ae6ce1-3b3f-4b7b-b4e0-088b1acebe93', N'DDR477', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'd3694a38-f966-4753-8cab-23725a8289ba', N'RRE454', 1, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'90e1f4fd-ec2b-4dcb-ada5-26655aba1bb6', N'TRE787', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'594813f3-0963-4c28-bf1c-2fec7d5afefd', N'FDF777', 0, 45)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'20d6fe15-1419-4a73-a3ff-3d9abf03784a', N'DDR477', 1, 78)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'64200984-4669-4c8d-9f52-4a7491be2eab', N'TEW475', 0, 1000)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'bfd92663-4c9e-4f86-8643-51d6e18d0bfe', N'TRE787', 0, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'64262459-ef9a-4291-af31-5432a2d40d95', N'REE788', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'cd04db4a-fcfb-478f-8a85-5eb2af50c70b', N'TRE787', 2, 1000)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'031708d3-e4ba-45ca-96a1-611a3f2b8365', N'TRE777', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'b2f89f40-a327-4a5b-9034-6831c734821c', N'DDR477', 0, 267)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'ebd48a6c-f030-407e-8975-72020b344046', N'TRE787', 0, 800)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'b6d0c6c7-a3f2-49cc-a4dd-802756c3dde4', N'TRE787', 1, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'ae89f240-da31-4246-b18d-8042325dfcb6', N'GGG789', 1, 800)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'd5c4afd9-6a59-42f5-ad0d-8c995c0fdc59', N'BBB777', 1, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'ec6ff900-bcad-476c-8b71-8eda8dff6293', N'TEW475', 0, 100)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'b64f2265-8318-4c46-8d12-9a1edfa9583b', N'FDF478', 0, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'3eef66f2-6881-49a1-95b2-9bc0a3bf553b', N'DDR477', 1, 100)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'619308e6-4c7b-4b97-924b-9e50f184d351', N'TRE787', 0, 80)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'1a6bb720-6e5c-460d-8919-ab196f50e65f', N'RRE454', 1, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'a54292ea-c749-4eba-9bf3-ad0bbada158a', N'RRE454', 0, 78)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'd41ff3f9-a05a-4e19-9189-b2d4af03f82e', N'TRE787', 1, 10)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'd323a9cd-95c1-48fe-ba45-b3c29c2957f1', N'DDR477', 2, 800)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'0b275eb2-bcfb-4752-ab10-b5e417b9cc2e', N'GGG789', 2, 100)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'04f259e2-46cc-4348-a08e-ba614d490f49', N'DDD444', 2, 444)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'e3b0e35c-4beb-4ded-b944-be8bd9f33fb9', N'RRE454', 0, 10000)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'0583ff36-ba9e-43ad-a932-c074dca144ae', N'TRE777', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'dde84321-4b02-4e35-aacf-c6c74b0ab14f', N'TEW475', 0, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'cd05982e-8aab-4d0f-b5d9-c8d803eb30ee', N'RER333', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'36442c95-7201-4c17-874e-d72d56fce944', N'GGG789', 0, 47)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'64ffcc6b-b23d-485c-accf-d79087dc46f5', N'TEW475', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'1691e070-2515-4e59-8ff7-e792aa52ae31', N'DDR921', 1, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'6aa8b66b-27be-413e-bdc6-ed5b4cebd87c', N'TEW475', 1, 45)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'6975cf7f-3070-4597-8f84-edefa8470b1f', N'TEW475', 0, 88)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'6b3a065d-0b39-4258-9351-ef3a906336d3', N'TRE787', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'bb083d7d-5350-4d70-9ab8-f0311c3a1455', N'EWE787', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'491281b0-9933-46b7-8180-f21ad4807b68', N'RER454', 0, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'a5df1bc1-1088-4db6-9db8-fc307a2688ea', N'TEW475', 0, 45)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'1fe9700a-bae1-45f9-bf9b-ff4f2d9c0c24', N'ASD454', 2, 0)
INSERT [dbo].[Cars] ([CarId], [LicenseNumber], [CarType], [NumberOfDrivenKm]) VALUES (N'a6b7fa9a-193c-48c7-b2ab-ffedd3f16e91', N'RRE454', 0, 100)
INSERT [dbo].[Customers] ([CustomerId], [PersonNumber], [FirstName], [LastName]) VALUES (N'6dba17cd-a4ed-4b16-9dcc-78e347cbfe53', N'140509-0909', N'Gamledam', N'Fälemark')
INSERT [dbo].[Customers] ([CustomerId], [PersonNumber], [FirstName], [LastName]) VALUES (N'8dcf2a25-0451-46d6-aeda-b2025c6de46a', N'950504-7878', N'Marcus', N'Furst')
INSERT [dbo].[Customers] ([CustomerId], [PersonNumber], [FirstName], [LastName]) VALUES (N'a477dca0-e128-4af3-b403-b4bfb8c732ed', N'940505-7777', N'Esther', N'Fälemark')
INSERT [dbo].[Customers] ([CustomerId], [PersonNumber], [FirstName], [LastName]) VALUES (N'575711d4-58ab-48ca-b996-e35eeb70ecda', N'960506-0632', N'Georg', N'Fälemark')
INSERT [dbo].[Customers] ([CustomerId], [PersonNumber], [FirstName], [LastName]) VALUES (N'11ae8b0e-ea21-4ca7-baf3-ff642ae1776a', N'950710-5287', N'Elsa', N'Andersson')
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2019-03-08 18:35:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2019-03-08 18:35:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2019-03-08 18:35:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2019-03-08 18:35:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2019-03-08 18:35:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2019-03-08 18:35:29 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2019-03-08 18:35:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bookings_CarId]    Script Date: 2019-03-08 18:35:29 ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_CarId] ON [dbo].[Bookings]
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bookings_CustomerId]    Script Date: 2019-03-08 18:35:29 ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_CustomerId] ON [dbo].[Bookings]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings] ADD  DEFAULT ((0)) FOR [OnGoing]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Cars_CarId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Customers_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [BiluthyrningAB_GeorgF�lemark] SET  READ_WRITE 
GO

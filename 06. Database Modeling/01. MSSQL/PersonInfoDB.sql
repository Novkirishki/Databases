USE [master]
GO
/****** Object:  Database [PersonInfoDB]    Script Date: 10/7/2015 12:35:10 PM ******/
CREATE DATABASE [PersonInfoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonInfoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\PersonInfoDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonInfoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\PersonInfoDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonInfoDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonInfoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonInfoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonInfoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonInfoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonInfoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonInfoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonInfoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonInfoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonInfoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonInfoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonInfoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonInfoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonInfoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonInfoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonInfoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonInfoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonInfoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonInfoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonInfoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonInfoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonInfoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonInfoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonInfoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonInfoDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonInfoDB] SET  MULTI_USER 
GO
ALTER DATABASE [PersonInfoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonInfoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonInfoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonInfoDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PersonInfoDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonInfoDB', N'ON'
GO
USE [PersonInfoDB]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 10/7/2015 12:35:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [text] NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 10/7/2015 12:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 10/7/2015 12:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 10/7/2015 12:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 10/7/2015 12:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (1, N'bul.Aleksandur Malinov 31', 1)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (2, N'Ostri Vrah-2-B-14', 2)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (3, N'ul.San Stefano 105-B', 3)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (4, N'2790 NE 187th St, Miami, FL 33180', 6)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (5, N'361A Old Finch Avenue', 7)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (6, N'6, rue Arsene Houssaye, 75008', 5)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'North America')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Asia')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (2, N'Germany', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (3, N'France', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (4, N'USA', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (5, N'Mexico', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (6, N'Canada', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (7, N'China', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (8, N'India', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (9, N'Japan', 3)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Ivan ', N'Petrov', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Simeon ', N'Bojilov', 2)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Dragomir ', N'Petkov', 3)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (4, N'Natasha ', N'Jeleva', 4)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (5, N'Kristiqn', N'Dobromirov', 5)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Vratsa', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (3, N'Burgas', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (4, N'Munchen', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (5, N'Paris', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (6, N'Miami', 4)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (7, N'Toronto', 6)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (8, N'Mexico ', 5)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (9, N'Tokyo', 9)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [PersonInfoDB] SET  READ_WRITE 
GO

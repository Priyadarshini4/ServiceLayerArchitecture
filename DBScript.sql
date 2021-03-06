USE [master]
GO
/****** Object:  Database [Sample]    Script Date: 09/19/2013 12:17:31 ******/
CREATE DATABASE [Sample] ON  PRIMARY 
( NAME = N'Sample', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\Sample.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Sample_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\Sample_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Sample] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sample] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Sample] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Sample] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Sample] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Sample] SET ARITHABORT OFF
GO
ALTER DATABASE [Sample] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Sample] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Sample] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Sample] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Sample] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Sample] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Sample] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Sample] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Sample] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Sample] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Sample] SET  DISABLE_BROKER
GO
ALTER DATABASE [Sample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Sample] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Sample] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Sample] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Sample] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Sample] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Sample] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Sample] SET  READ_WRITE
GO
ALTER DATABASE [Sample] SET RECOVERY FULL
GO
ALTER DATABASE [Sample] SET  MULTI_USER
GO
ALTER DATABASE [Sample] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Sample] SET DB_CHAINING OFF
GO
USE [Sample]
GO
/****** Object:  Table [dbo].[GILog]    Script Date: 09/19/2013 12:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[Exception] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GI_User]    Script Date: 09/19/2013 12:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GI_User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_GI_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_AuthenticateUser]    Script Date: 09/19/2013 12:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AuthenticateUser] 
	-- Add the parameters for the stored procedure here
	@UserName varchar(50),
	@Password varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;-- If we "Turned ON" No count, it will not return any rows count from database.

    -- Insert statements for procedure here
  
	SELECT count(*)
	FROM GI_User with (nolock)--SQL server engine parse the NOLOCK statement and not perform locks for a given operation.
	WHERE UserName=@UserName and Password=@Password
	
	
END
GO

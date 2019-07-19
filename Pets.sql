USE [master]
GO

/****** Object:  Database [Pets]    Script Date: 7/19/2019 3:57:35 AM ******/
CREATE DATABASE [Pets]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pets].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Pets] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Pets] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Pets] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Pets] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Pets] SET ARITHABORT OFF 
GO

ALTER DATABASE [Pets] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Pets] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Pets] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Pets] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Pets] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Pets] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Pets] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Pets] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Pets] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Pets] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Pets] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Pets] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Pets] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Pets] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO

ALTER DATABASE [Pets] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Pets] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [Pets] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Pets] SET RECOVERY FULL 
GO

ALTER DATABASE [Pets] SET  MULTI_USER 
GO

ALTER DATABASE [Pets] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Pets] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Pets] SET  READ_WRITE 
GO



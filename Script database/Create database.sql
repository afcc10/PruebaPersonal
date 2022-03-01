USE [master]
GO

/****** Object:  Database [Polizas]    Script Date: 1/03/2022 9:39:42 a. m. ******/
CREATE DATABASE [Polizas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Polizas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Polizas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Polizas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Polizas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Polizas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Polizas] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Polizas] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Polizas] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Polizas] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Polizas] SET ARITHABORT OFF 
GO

ALTER DATABASE [Polizas] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [Polizas] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Polizas] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Polizas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Polizas] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Polizas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Polizas] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Polizas] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Polizas] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Polizas] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Polizas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Polizas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Polizas] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Polizas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Polizas] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Polizas] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [Polizas] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Polizas] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Polizas] SET  MULTI_USER 
GO

ALTER DATABASE [Polizas] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Polizas] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Polizas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Polizas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Polizas] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Polizas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Polizas] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Polizas] SET  READ_WRITE 
GO



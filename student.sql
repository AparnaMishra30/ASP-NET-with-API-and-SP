USE [master]
GO
/****** Object:  Database [Student]    Script Date: 11-12-2024 12.22.02 PM ******/
CREATE DATABASE [Student]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Student', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Student.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Student_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Student_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Student].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Student] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Student] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Student] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Student] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Student] SET ARITHABORT OFF 
GO
ALTER DATABASE [Student] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Student] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Student] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Student] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Student] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Student] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Student] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Student] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Student] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Student] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Student] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Student] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Student] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Student] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Student] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Student] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Student] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Student] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Student] SET RECOVERY FULL 
GO
ALTER DATABASE [Student] SET  MULTI_USER 
GO
ALTER DATABASE [Student] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Student] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Student] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Student] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Student', N'ON'
GO
USE [Student]
GO
/****** Object:  User [rajput]    Script Date: 11-12-2024 12.22.02 PM ******/
CREATE USER [rajput] FOR LOGIN [Goldie] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  StoredProcedure [dbo].[sp_student]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [sp_student] @Ind=3,@fname='Aparna Mishra' , @pswd='123AP@' 
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_student]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@fname varchar(70)='',
@mob bigint=0 ,
@calender date='',
@gen varchar(25)='',
@cat varchar(25)='',
@Department varchar(25)='',
@pswd varchar(15)='',
@conpswd varchar(15)='',
@Ind int =0,
@id int =0,
@typeofuser int=0,
@StateId int=0,
@districtId int=0
AS
BEGIN
	if(@Ind=1)
	begin
	insert into Register (fname,mob,calender,gen,cat,Department,pswd,conpswd,districtId,StateId) values (@fname,@mob,@calender,@gen,@cat,@Department,@pswd,@conpswd,@districtId,@StateId)
	select 1 res
	end
	if(@Ind=2)
	begin
	select deptname,deptcode from Depart
	select StateId,StateName from State
	end
	IF(@Ind=3)
	begin
	--select r.fname,r.mob,d.deptname from Register as r , Depart as d where fname='Aparna Mishra' and pswd='123AP@'  and d.deptcode = r.Department
	--select r.fname,r.mob,d.deptname,r.typeofuser from Register as r , Depart as d where fname COLLATE latin1_General_bin =@fname and pswd COLLATE latin1_General_bin=@pswd  and d.deptname = r.Department
	select fname,mob,Department,typeofuser from Register where fname collate latin1_general_bin =@fname and pswd collate latin1_general_bin =@pswd 
	end
	IF(@Ind=4)
	begin
	if(@typeofuser=1)
	begin
	select a.menutype,a.url from Access as a , register as r where a.studentAccess=1 and r.fname=@fname
	end
	else if(@typeofuser=2) 
	begin
	select a.menutype,a.url from Access as a , register as r where a.TeacherAccess=1 and r.fname=@fname
	end
	end
	IF(@Ind=5)
	begin
	--select id,fname,mob,calender,gen,cat,d.deptname as Department from Register as r, Depart as d where d.deptname=r.Department
		select id,fname,mob,calender,gen,cat,Department from Register 
	end
	IF(@Ind=6)
	begin
	update Register set fname=@fname,mob=@mob,calender=@calender where id=@id
	end
	IF(@Ind=7)
	begin
	delete Register where id=@id
	end
	IF(@Ind=8)
	begin
	select districtId,districtName from district where StateId=@StateId
	end
	END
select * from register

GO
/****** Object:  Table [dbo].[Access]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Access](
	[menucode] [int] NULL,
	[menutype] [varchar](25) NULL,
	[url] [varchar](150) NULL,
	[studentAccess] [int] NULL,
	[TeacherAccess] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Depart]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Depart](
	[deptname] [varchar](50) NULL,
	[deptcode] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[district]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[district](
	[districtId] [int] IDENTITY(1,1) NOT NULL,
	[districtName] [varchar](100) NULL,
	[StateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[districtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Register]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Register](
	[fname] [varchar](50) NULL,
	[mob] [varchar](50) NOT NULL,
	[calender] [date] NULL,
	[gen] [varchar](25) NULL,
	[cat] [varchar](25) NULL,
	[Department] [varchar](25) NULL,
	[pswd] [varchar](15) NULL,
	[conpswd] [varchar](15) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeofuser] [int] NULL,
	[districtId] [int] NULL,
	[StateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[State]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[typeofuser]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[typeofuser](
	[typecode] [int] NULL,
	[usertype] [varchar](25) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[functionexample]    Script Date: 11-12-2024 12.22.02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[functionexample] 
(	
	@fname varchar(50)
	-- Add the parameters for the function here
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select * from register where fname=@fname
    --select * from register as r LEFT JOIN Depart as d ON r.Department=d.deptcode 
)

GO
ALTER TABLE [dbo].[district]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
USE [master]
GO
ALTER DATABASE [Student] SET  READ_WRITE 
GO

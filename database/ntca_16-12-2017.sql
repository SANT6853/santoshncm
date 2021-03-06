USE [master]
GO
/****** Object:  Database [NTCA_MIS]    Script Date: 12/16/2017 11:07:03 AM ******/
CREATE DATABASE [NTCA_MIS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NTCA_MIS', FILENAME = N'D:\database\data\NTCA_MIS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NTCA_MIS_log', FILENAME = N'D:\database\data\NTCA_MIS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NTCA_MIS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NTCA_MIS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NTCA_MIS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NTCA_MIS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NTCA_MIS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NTCA_MIS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NTCA_MIS] SET ARITHABORT OFF 
GO
ALTER DATABASE [NTCA_MIS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NTCA_MIS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NTCA_MIS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NTCA_MIS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NTCA_MIS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NTCA_MIS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NTCA_MIS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NTCA_MIS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NTCA_MIS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NTCA_MIS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NTCA_MIS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NTCA_MIS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NTCA_MIS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NTCA_MIS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NTCA_MIS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NTCA_MIS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NTCA_MIS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NTCA_MIS] SET RECOVERY FULL 
GO
ALTER DATABASE [NTCA_MIS] SET  MULTI_USER 
GO
ALTER DATABASE [NTCA_MIS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NTCA_MIS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NTCA_MIS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NTCA_MIS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [NTCA_MIS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [NTCA_MIS]
GO
/****** Object:  User [ntcausr]    Script Date: 12/16/2017 11:07:03 AM ******/
CREATE USER [ntcausr] FOR LOGIN [ntcausr] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ntca1]    Script Date: 12/16/2017 11:07:03 AM ******/
CREATE USER [ntca1] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ntca]    Script Date: 12/16/2017 11:07:03 AM ******/
CREATE USER [ntca] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [ntcausr]
GO
ALTER ROLE [db_owner] ADD MEMBER [ntca1]
GO
ALTER ROLE [db_owner] ADD MEMBER [ntca]
GO
/****** Object:  UserDefinedTableType [dbo].[AnimalType]    Script Date: 12/16/2017 11:07:03 AM ******/
CREATE TYPE [dbo].[AnimalType] AS TABLE(
	[Animalid] [int] NULL,
	[TotalAnimal] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TypeFamilyAnimal]    Script Date: 12/16/2017 11:07:03 AM ******/
CREATE TYPE [dbo].[TypeFamilyAnimal] AS TABLE(
	[RowNumber] [int] NULL,
	[ID] [int] NULL,
	[Familyid] [int] NULL,
	[AnimalType] [int] NULL,
	[NOofAnimal] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TypeFamilyMember]    Script Date: 12/16/2017 11:07:03 AM ******/
CREATE TYPE [dbo].[TypeFamilyMember] AS TABLE(
	[RowNumber] [int] NULL,
	[MemberID] [int] NULL,
	[familyid] [int] NULL,
	[MemberName] [varchar](100) NULL,
	[Age] [int] NULL,
	[Year_Month] [char](1) NULL,
	[Gender] [char](1) NULL,
	[Relation] [varchar](50) NULL,
	[AadharCardNo] [varchar](20) NULL,
	[AadharCardFile] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_String_To_Table]    Script Date: 12/16/2017 11:07:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_String_To_Table]   

(  

 @String VARCHAR(max), /* input string */  

 @Delimeter char(1),   /* delimiter */  

 @TrimSpace bit   

)      /* kill whitespace? */  

  

RETURNS @Table TABLE ( [Val] VARCHAR(4000) )  

AS  

BEGIN  

    DECLARE @Val    VARCHAR(4000)  

    WHILE LEN(@String) > 0  

    BEGIN  

  SET @Val    = LEFT(@String,  

   ISNULL(NULLIF(CHARINDEX(@Delimeter, @String) - 1, -1),  

   LEN(@String)))  

  SET @String = SUBSTRING(@String,  

   ISNULL(NULLIF(CHARINDEX(@Delimeter, @String), 0),  

   LEN(@String)) + 1, LEN(@String))  

  IF @TrimSpace = 1 Set @Val = LTRIM(RTRIM(@Val))  

    INSERT INTO @Table ( [Val] )  

        VALUES ( @Val )  

    END  

    RETURN  

END


GO
/****** Object:  UserDefinedFunction [dbo].[fnSplitString]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  FUNCTION [dbo].[fnSplitString]  ( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1)  
    )
    RETURNS
    @output TABLE(splitdata NVARCHAR(MAX)  ) 
    BEGIN 
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1
    BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1 

        INSERT INTO @output (splitdata)  
        VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start) 

     END 
     RETURN  
     END

GO
/****** Object:  UserDefinedFunction [dbo].[GetChildCounter]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[GetChildCounter](@link_parent_id int) returns int      

AS       

 BEGIN      

  Declare @counter as int  

    

  set @counter=(  SELECT max(link_id)as counter_Child            

      FROM Web_link             

      WHERE link_parent_id = @link_parent_id   )    

    

   

       

  Return  @counter      

 END


GO
/****** Object:  UserDefinedFunction [dbo].[GetDistrictName]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [dbo].[GetDistrictName](@Tehsilid int) returns int      

AS         

 BEGIN        

  --Declare @Parentname as NVARCHAR(100)    
  declare @distID as int
      

  set @distID=(  SELECT Distid              

      FROM Tbl_Tehsil               

      WHERE Tehsil =@Tehsilid)      

      -- set @Parentname=(  SELECT DistName              

      --FROM Mst_Dist               

      --WHERE DistID =@distID) 

     

         

  Return  @distID        

 END
GO
/****** Object:  UserDefinedFunction [dbo].[GetLastUpdatedCMS]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetLastUpdatedCMS](@linkid int)returns datetime    

as    

 BEGIN    

  DECLARE @LastUpdated datetime    

  set @LastUpdated=(select max(coalesce( Rec_Update_Date,Rec_insert_date)) from Web_Link where link_id=@linkid)    

  return  @LastUpdated    

END


GO
/****** Object:  UserDefinedFunction [dbo].[GetParentName]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetParentName](@ChildID int) returns NVARCHAR(100)        

AS         

 BEGIN        

  Declare @Parentname as NVARCHAR(100)    

      

  set @Parentname=(  SELECT name              

      FROM Web_Link               

      WHERE link_id =@ChildID)      

      

     

         

  Return  @Parentname        

 END


GO
/****** Object:  UserDefinedFunction [dbo].[GetUserName]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create FUNCTION [dbo].[GetUserName](@UserID int) returns NVARCHAR(100)        

AS         

 BEGIN        

  Declare @Parentname as NVARCHAR(100)    

      

  set @Parentname=(  SELECT UserName              

      FROM Mst_Users               

      WHERE UserID =@UserID)      

      

     

         

  Return  @Parentname        

 END
GO
/****** Object:  Table [dbo].[AdminMaster]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminMaster](
	[Id] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](15) NULL,
	[AdminPassword] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CatTypeId] [int] NULL,
	[CatName] [nvarchar](200) NULL,
	[CaNametHindi] [nvarchar](200) NULL,
	[StatusId] [int] NULL,
	[ModuleId] [int] NULL,
	[UserId] [int] NULL,
	[DateInserted] [datetime] NULL,
	[DateLastUpdated] [datetime] NULL,
	[IPAddress] [nvarchar](50) NULL,
	[StateID] [int] NULL,
	[TigerReserveid] [int] NULL,
 CONSTRAINT [PK_CategoryWeb] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category_Tmp]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_Tmp](
	[TempCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CatTypeId] [int] NULL,
	[CatName] [nvarchar](200) NULL,
	[CaNametHindi] [nvarchar](200) NULL,
	[StatusId] [int] NULL,
	[ModuleId] [int] NULL,
	[CategoryId] [int] NULL,
	[UserId] [int] NULL,
	[DateInserted] [datetime] NULL,
	[DateLastUpdated] [datetime] NULL,
	[IPAddress] [nvarchar](50) NULL,
	[StateID] [int] NULL,
	[TigerReserveid] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[TempCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_Animal]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_Animal](
	[AnimalID] [int] IDENTITY(1,1) NOT NULL,
	[Animal] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mst_Animal] PRIMARY KEY CLUSTERED 
(
	[AnimalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_City]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[Distid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_Dist]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_Dist](
	[DistID] [int] IDENTITY(1,1) NOT NULL,
	[DistName] [nvarchar](100) NULL,
	[StateID] [int] NULL,
	[IpAddress] [nvarchar](50) NULL,
	[InsertedBy] [int] NULL,
	[InsertDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_Language]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Language](
	[Lang_Id] [int] IDENTITY(1,1) NOT NULL,
	[Language] [varchar](50) NULL,
	[Key] [char](2) NULL,
 CONSTRAINT [PK_Master_Language] PRIMARY KEY CLUSTERED 
(
	[Lang_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_Module]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_Module](
	[ModuleId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mst_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_Ngo]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_Ngo](
	[NgoID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name_of_NGO] [nvarchar](100) NULL,
	[Address_of_NGO] [nvarchar](200) NULL,
	[Landline_areacode] [nchar](10) NULL,
	[Landline_no] [nchar](10) NULL,
	[MobileNo] [nchar](10) NULL,
	[Work_Done_By_NGO] [nvarchar](max) NULL,
	[State] [int] NULL,
	[Dist] [int] NULL,
	[Remarks] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Submitby] [int] NULL,
	[Submitedon] [datetime] NULL,
	[Updatedon] [datetime] NULL,
 CONSTRAINT [PK_Mst_Ngo] PRIMARY KEY CLUSTERED 
(
	[NgoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_Position]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Position](
	[Position_Id] [int] IDENTITY(1,1) NOT NULL,
	[Position] [varchar](50) NULL,
 CONSTRAINT [PK_Master_Position] PRIMARY KEY CLUSTERED 
(
	[Position_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_Status]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_Status](
	[Statusid] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NULL,
	[StatusType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Statusid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_StatusType]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_StatusType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StatusType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mst_StatusType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mst_Users]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Password] [nvarchar](600) NULL,
	[UserType] [int] NULL,
	[EmailID] [nvarchar](50) NULL,
	[Address1] [nvarchar](200) NULL,
	[Address2] [nvarchar](200) NULL,
	[PermissionState] [int] NULL,
	[pincode] [char](6) NULL,
	[Landline] [nvarchar](20) NULL,
	[AreaCode] [char](5) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Mst_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_UserType]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_UserType](
	[UserTypeid] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mst_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhotoGallery]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoGallery](
	[GalleryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[MediaTypeId] [int] NULL,
	[Title] [nvarchar](200) NULL,
	[TitleRegLng] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[DescriptionRegLng] [nvarchar](200) NULL,
	[AltTag] [nvarchar](200) NULL,
	[AltTagRegLng] [nvarchar](200) NULL,
	[ImageName] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[StatusId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[DateInserted] [datetime] NULL,
	[DateLastUpdated] [datetime] NULL,
	[UserId] [int] NULL,
	[IPAddress] [nvarchar](50) NULL,
	[StateID] [int] NULL,
	[TigerReserveid] [int] NULL,
 CONSTRAINT [PK_Gallery_Web] PRIMARY KEY CLUSTERED 
(
	[GalleryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhotoGallery_tmp]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoGallery_tmp](
	[TempGalleryId] [int] IDENTITY(1,1) NOT NULL,
	[GalleryId] [int] NULL,
	[CategoryId] [int] NULL,
	[MediaTypeId] [int] NULL,
	[Title] [nvarchar](200) NULL,
	[TitleRegLng] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[DescriptionRegLng] [nvarchar](200) NULL,
	[AltTag] [nvarchar](200) NULL,
	[AltTagRegLng] [nvarchar](200) NULL,
	[ImageName] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[StatusId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[DateInserted] [datetime] NULL,
	[DateLastUpdated] [datetime] NULL,
	[UserId] [int] NULL,
	[IpAddress] [nvarchar](50) NULL,
	[StateID] [int] NULL,
	[TigerReserveid] [int] NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[TempGalleryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[state_list]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[state_list](
	[id] [int] NOT NULL,
	[StateName] [varchar](50) NOT NULL,
	[StateNameHindi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_1](
	[VillageID] [int] NULL,
	[VillageName] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Family]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Family](
	[familyid] [int] IDENTITY(1,1) NOT NULL,
	[Stateid] [int] NULL,
	[TigerReserveid] [int] NULL,
	[VillageID] [int] NULL,
	[Head_Name] [nvarchar](200) NULL,
	[Agriculature_land] [decimal](18, 2) NULL,
	[Residential_Property] [decimal](18, 2) NULL,
	[Total_Livestock] [int] NULL,
	[Other_assest] [varchar](max) NULL,
	[Longitude] [varchar](20) NULL,
	[Latitude] [varchar](20) NULL,
	[SanctionLeter] [varchar](100) NULL,
	[Submitedby] [int] NULL,
	[SubmitedDate] [datetime] NULL,
	[IPAddress] [nvarchar](20) NULL,
	[UpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[familyid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_family_animal]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_family_animal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Familyid] [int] NULL,
	[AnimalType] [int] NULL,
	[NOofAnimal] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_family_Member]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_family_Member](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[familyid] [int] NULL,
	[MemberName] [nvarchar](100) NULL,
	[Age] [int] NULL,
	[Year_Month] [varchar](1) NULL,
	[Gender] [varchar](1) NULL,
	[Relation] [varchar](50) NULL,
	[AadharCardNo] [varchar](20) NULL,
	[AadharCardFile] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Grampanchayat]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Grampanchayat](
	[GramPanchayatID] [int] IDENTITY(1,1) NOT NULL,
	[GramPanchayatName] [nvarchar](100) NULL,
	[Tehsilid] [int] NULL,
	[IPAddress] [nvarchar](50) NULL,
	[SubmitBy] [int] NULL,
	[DateofInsert] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Grampanchayat] PRIMARY KEY CLUSTERED 
(
	[GramPanchayatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_NgoFinal]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_NgoFinal](
	[NgoID] [bigint] IDENTITY(1,1) NOT NULL,
	[NgoName] [nvarchar](100) NULL,
	[NgoAddress] [nvarchar](200) NULL,
	[PhoneAreaCode] [nchar](10) NULL,
	[PhoneNumber] [nchar](10) NULL,
	[MobileNumber] [nchar](10) NULL,
	[WorkDoneByNGO] [nvarchar](max) NULL,
	[StateID] [int] NULL,
	[Dist] [int] NULL,
	[Remarks] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[StatusID] [int] NULL,
	[Submitby] [int] NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IpAddress] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_NgoFinal] PRIMARY KEY CLUSTERED 
(
	[NgoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_NgoTemp]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_NgoTemp](
	[NgoIDTemp] [bigint] IDENTITY(1,1) NOT NULL,
	[NgoID] [bigint] NULL,
	[NgoName] [nvarchar](100) NULL,
	[NgoAddress] [nvarchar](200) NULL,
	[PhoneAreaCode] [nchar](10) NULL,
	[PhoneNumber] [nchar](10) NULL,
	[MobileNumber] [nchar](10) NULL,
	[WorkDoneByNGO] [nvarchar](max) NULL,
	[StateID] [int] NULL,
	[Dist] [int] NULL,
	[Remarks] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[StatusID] [int] NULL,
	[Submitby] [int] NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IpAddress] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_NgoTemp] PRIMARY KEY CLUSTERED 
(
	[NgoIDTemp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Tehsil]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Tehsil](
	[Tehsil] [int] IDENTITY(1,1) NOT NULL,
	[Tehsil_Name] [nvarchar](100) NULL,
	[Distid] [int] NULL,
	[IPAddress] [nvarchar](50) NULL,
	[SubmitBy] [int] NULL,
	[DateofInsert] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Tehsil] PRIMARY KEY CLUSTERED 
(
	[Tehsil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_TigerReserve]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_TigerReserve](
	[TigerReserveid] [int] IDENTITY(1,1) NOT NULL,
	[TigerReserveName] [nvarchar](500) NULL,
	[TigerReserveNameHindi] [nvarchar](500) NULL,
	[NoofVillages] [int] NULL,
	[StateID] [int] NULL,
	[Dist] [smallint] NULL,
	[City] [smallint] NULL,
	[TigerReserveMap] [nvarchar](200) NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[CreatedBy] [smallint] NULL,
	[Status] [smallint] NULL,
	[CoreArea] [varchar](50) NULL,
	[BufferArea] [varchar](50) NULL,
	[latitude] [nvarchar](50) NULL,
	[longitude] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_] PRIMARY KEY CLUSTERED 
(
	[TigerReserveid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_village]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_village](
	[TempVillageid] [int] IDENTITY(1,1) NOT NULL,
	[TigerReserveID] [int] NULL,
	[Village_Name] [nvarchar](100) NULL,
	[Agriculture_Land] [decimal](18, 2) NULL,
	[Population] [varchar](50) NULL,
	[Residential_property] [decimal](18, 2) NULL,
	[Total_Standing_Trees] [int] NULL,
	[Total_Livestock] [int] NULL,
	[Relocated_from] [nvarchar](50) NULL,
	[Relocated_place] [nvarchar](50) NULL,
	[Total_well] [int] NULL,
	[Other_Assets] [varchar](max) NULL,
	[Current_location_Latitude] [varchar](50) NULL,
	[Current_location_Longitude] [varchar](50) NULL,
	[location_Latitude_From] [varchar](50) NULL,
	[location_Longitude_From] [varchar](50) NULL,
	[Submitedby] [int] NULL,
	[SubmitedDate] [datetime] NULL,
	[LastUpdatedby] [int] NULL,
	[LastUpdateDate] [datetime] NULL,
	[Status] [int] NULL,
	[Villageid] [int] NULL,
	[IPAddress] [varchar](50) NULL,
	[Stateid] [int] NULL,
 CONSTRAINT [PK_Tbl_village] PRIMARY KEY CLUSTERED 
(
	[TempVillageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_village_animal_Final]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_village_animal_Final](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[villageid] [int] NULL,
	[Animalid] [int] NULL,
	[TotalAnimal] [int] NULL,
 CONSTRAINT [PK_Tbl_village_animal_Final] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Village_Animals]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Village_Animals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[villageid] [int] NULL,
	[Animalid] [int] NULL,
	[TotalAnimal] [int] NULL,
 CONSTRAINT [PK_Tbl_Village_Animals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Village_final]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Village_final](
	[Villageid] [int] IDENTITY(1,1) NOT NULL,
	[TigerReserveID] [int] NULL,
	[Village_Name] [nvarchar](100) NULL,
	[Agriculture_Land] [decimal](18, 2) NULL,
	[Population] [varchar](50) NULL,
	[Residential_property] [decimal](18, 2) NULL,
	[Total_Standing_Trees] [int] NULL,
	[Total_Livestock] [int] NULL,
	[Relocated_from] [nvarchar](50) NULL,
	[Relocated_place] [nvarchar](50) NULL,
	[Total_well] [int] NULL,
	[Other_Assets] [varchar](max) NULL,
	[Current_location_Latitude] [varchar](50) NULL,
	[Current_location_Longitude] [varchar](50) NULL,
	[location_Latitude_From] [varchar](50) NULL,
	[location_Longitude_From] [varchar](50) NULL,
	[Submitedby] [int] NULL,
	[SubmitedDate] [datetime] NULL,
	[LastUpdatedby] [int] NULL,
	[LastUpdateDate] [datetime] NULL,
	[Status] [int] NULL,
	[IPAddress] [varchar](50) NULL,
	[Stateid] [int] NULL,
 CONSTRAINT [PK_Tbl_Village_final] PRIMARY KEY CLUSTERED 
(
	[Villageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tmp_Link]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tmp_Link](
	[Temp_Link_Id] [int] IDENTITY(1,1) NOT NULL,
	[Module_Id] [int] NULL,
	[Link_Parent_Id] [int] NULL,
	[Link_Order] [int] NULL,
	[Link_Level] [int] NULL,
	[Link_Type_Id] [int] NULL,
	[Position_Id] [int] NULL,
	[StateID] [int] NULL,
	[TigerReserveid] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Name_Reg] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[SmallDetails] [nvarchar](500) NULL,
	[Details_Reg] [nvarchar](max) NULL,
	[Browser_Title] [nvarchar](max) NULL,
	[Page_Title] [nvarchar](max) NULL,
	[Meta_Keywords] [nvarchar](max) NULL,
	[Mate_Description] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[File_Name] [nvarchar](max) NULL,
	[Image_Name] [nvarchar](max) NULL,
	[Alt_Tag] [nvarchar](max) NULL,
	[AltTag_Reg] [nvarchar](max) NULL,
	[Status_Id] [int] NULL,
	[Link_Id] [int] NULL,
	[Lang_Id] [int] NULL,
	[Inserted_By] [int] NULL,
	[Last_Updated_By] [int] NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Rec_Insert_Date] [datetime] NULL,
	[Rec_Update_Date] [datetime] NULL,
	[IpAddress] [nvarchar](max) NULL,
	[UrlName] [nvarchar](50) NULL,
	[MetaLanguage] [char](2) NULL,
	[MetaTitle] [varchar](200) NULL,
 CONSTRAINT [PK_Tmp_Link] PRIMARY KEY CLUSTERED 
(
	[Temp_Link_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Userid] [int] NOT NULL,
	[TigerReserveid] [bigint] NULL,
 CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Web_Link]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Web_Link](
	[Link_Id] [int] IDENTITY(1,1) NOT NULL,
	[Module_Id] [int] NULL,
	[Link_Parent_Id] [int] NULL,
	[Link_Order] [int] NULL,
	[Link_Level] [int] NULL,
	[Link_Type_Id] [int] NULL,
	[Position_Id] [int] NULL,
	[StateID] [int] NULL,
	[TigerReserveid] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Name_Reg] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[SmallDetails] [nvarchar](500) NULL,
	[Details_Reg] [nvarchar](max) NULL,
	[Browser_Title] [nvarchar](max) NULL,
	[Page_Title] [nvarchar](max) NULL,
	[Meta_Keywords] [nvarchar](max) NULL,
	[Mate_Description] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[File_Name] [nvarchar](max) NULL,
	[Image_Name] [nvarchar](max) NULL,
	[Alt_Tag] [nvarchar](max) NULL,
	[AltTag_Reg] [nvarchar](max) NULL,
	[Status_Id] [int] NULL,
	[Lang_Id] [int] NULL,
	[Inserted_By] [int] NULL,
	[Last_Updated_By] [int] NULL,
	[Rec_Insert_Date] [datetime] NULL,
	[Rec_Update_Date] [datetime] NULL,
	[IpAddress] [nvarchar](max) NULL,
	[UrlName] [nvarchar](50) NULL,
	[MetaLanguage] [char](2) NULL,
	[MetaTitle] [varchar](200) NULL,
 CONSTRAINT [PK_Web_Link] PRIMARY KEY CLUSTERED 
(
	[Link_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CatTypeId], [CatName], [CaNametHindi], [StatusId], [ModuleId], [UserId], [DateInserted], [DateLastUpdated], [IPAddress], [StateID], [TigerReserveid]) VALUES (1, NULL, N'NTCA first photo gallery2', N'NTCA first photo gallery2', 5, NULL, 0, CAST(N'2017-09-17 09:53:08.073' AS DateTime), NULL, N'::1', 1, 14)
INSERT [dbo].[Category] ([CategoryId], [CatTypeId], [CatName], [CaNametHindi], [StatusId], [ModuleId], [UserId], [DateInserted], [DateLastUpdated], [IPAddress], [StateID], [TigerReserveid]) VALUES (2, NULL, N'Bihar Tiger Reserve', N'Bihar Tiger Reserve', 5, NULL, 0, CAST(N'2017-09-17 12:18:02.990' AS DateTime), NULL, N'::1', 5, 9)
INSERT [dbo].[Category] ([CategoryId], [CatTypeId], [CatName], [CaNametHindi], [StatusId], [ModuleId], [UserId], [DateInserted], [DateLastUpdated], [IPAddress], [StateID], [TigerReserveid]) VALUES (3, NULL, N'Bihar Tiger Reserve 2', N'Bihar Tiger Reserve 2', 5, NULL, 1, CAST(N'2017-09-21 22:42:20.830' AS DateTime), NULL, N'::1', 5, 9)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Mst_Animal] ON 

INSERT [dbo].[Mst_Animal] ([AnimalID], [Animal]) VALUES (1, N'Cow')
INSERT [dbo].[Mst_Animal] ([AnimalID], [Animal]) VALUES (2, N'Sheep')
INSERT [dbo].[Mst_Animal] ([AnimalID], [Animal]) VALUES (3, N'Goat')
INSERT [dbo].[Mst_Animal] ([AnimalID], [Animal]) VALUES (4, N'Buffalo')
INSERT [dbo].[Mst_Animal] ([AnimalID], [Animal]) VALUES (5, N'Others')
SET IDENTITY_INSERT [dbo].[Mst_Animal] OFF
SET IDENTITY_INSERT [dbo].[Mst_Dist] ON 

INSERT [dbo].[Mst_Dist] ([DistID], [DistName], [StateID], [IpAddress], [InsertedBy], [InsertDate]) VALUES (1, N'Nalanda', 5, N'100.100.7.12', 1, CAST(N'2017-10-08 15:59:51.627' AS DateTime))
SET IDENTITY_INSERT [dbo].[Mst_Dist] OFF
SET IDENTITY_INSERT [dbo].[Mst_Language] ON 

INSERT [dbo].[Mst_Language] ([Lang_Id], [Language], [Key]) VALUES (1, N'English', N'en')
INSERT [dbo].[Mst_Language] ([Lang_Id], [Language], [Key]) VALUES (2, N'Hindi', N'hi')
SET IDENTITY_INSERT [dbo].[Mst_Language] OFF
SET IDENTITY_INSERT [dbo].[Mst_Module] ON 

INSERT [dbo].[Mst_Module] ([ModuleId], [ModuleName]) VALUES (1, N'User')
INSERT [dbo].[Mst_Module] ([ModuleId], [ModuleName]) VALUES (2, N'CMS')
INSERT [dbo].[Mst_Module] ([ModuleId], [ModuleName]) VALUES (3, N'Banner')
INSERT [dbo].[Mst_Module] ([ModuleId], [ModuleName]) VALUES (4, N'Tiger Reserve')
INSERT [dbo].[Mst_Module] ([ModuleId], [ModuleName]) VALUES (5, N'Photo Gallery')
SET IDENTITY_INSERT [dbo].[Mst_Module] OFF
SET IDENTITY_INSERT [dbo].[Mst_Position] ON 

INSERT [dbo].[Mst_Position] ([Position_Id], [Position]) VALUES (1, N'Top')
INSERT [dbo].[Mst_Position] ([Position_Id], [Position]) VALUES (2, N'Bottom')
SET IDENTITY_INSERT [dbo].[Mst_Position] OFF
SET IDENTITY_INSERT [dbo].[Mst_Status] ON 

INSERT [dbo].[Mst_Status] ([Statusid], [Status], [StatusType]) VALUES (1, N'Active', 1)
INSERT [dbo].[Mst_Status] ([Statusid], [Status], [StatusType]) VALUES (2, N'InActive', 1)
INSERT [dbo].[Mst_Status] ([Statusid], [Status], [StatusType]) VALUES (3, N'Draft', 2)
INSERT [dbo].[Mst_Status] ([Statusid], [Status], [StatusType]) VALUES (5, N'Approve', 2)
SET IDENTITY_INSERT [dbo].[Mst_Status] OFF
SET IDENTITY_INSERT [dbo].[Mst_StatusType] ON 

INSERT [dbo].[Mst_StatusType] ([id], [StatusType]) VALUES (1, N'User')
INSERT [dbo].[Mst_StatusType] ([id], [StatusType]) VALUES (2, N'TigerReserve')
INSERT [dbo].[Mst_StatusType] ([id], [StatusType]) VALUES (3, N'Village')
SET IDENTITY_INSERT [dbo].[Mst_StatusType] OFF
SET IDENTITY_INSERT [dbo].[Mst_Users] ON 

INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (1, N'superadmin', N'Birendra', N'kumar', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 1, N'birendrakr11@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (2, N'dasff', N'dsafa', N'sadf', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 2, N'krgaurav@gmail.com', N'sadf', N'sadf', 1, N'123456', N'123456', N'1111 ', N'95821', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (3, N'adsfadsf', N'dfas', N'sadf', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 2, N'kr', N'ff', N'ff', 1, N'12233 ', N'12233 ', N'     ', N'', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (4, N'stateuser', N'birendra', N'sadf', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 2, N'kr', N'sadf', N'sadf', 1, N'123456', N'123456', N'1111 ', N'95821', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (5, N'tigeruser', N'birendra', N'sadf', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 3, N'kr', N'sadf', N'sadf', 1, N'123456', N'123456', N'1111 ', N'95821', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (6, N'', N'', N'', N'', 3, N'', N'', N'', 1, N'      ', N'', N'     ', N'', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (7, N'23/CPCSEA', N'sdf', N'dsf', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 3, N'krgauravverma.11@gmail.com', N'dfsa', N'dfsa', 1, N'dfs   ', N'dfs', N'11   ', N'1111', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (8, N'', N'', N'', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 0, N'', N'', N'', 0, N'      ', N'', N'     ', N'', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (9, N'delhistate', N'delhistate', N'delhistate', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 2, N'delhistate@gmail.com', N'Delhi', N'Delhi', 9, N'110021', N'110021', N'11009', N'9898989898', 1)
INSERT [dbo].[Mst_Users] ([UserID], [UserName], [FirstName], [LastName], [Password], [UserType], [EmailID], [Address1], [Address2], [PermissionState], [pincode], [Landline], [AreaCode], [Mobile], [Status]) VALUES (10, N'Tiger1', N'Tiger1', N'Tiger1', N'A1102957491B9CE5441E111F7725F2FD0201BC32465E2536E5182D1C5E3F6B0965355C09F2C8B9111AB6D18A73B75F0F3A06E788BD2A6DFF4DDC7C4DA6ADA603', 3, N'Tiger1@gmail.com', N'tiger', N'tiger', 9, N'110021', N'110021', N'12345', N'9898989898', 1)
SET IDENTITY_INSERT [dbo].[Mst_Users] OFF
SET IDENTITY_INSERT [dbo].[Mst_UserType] ON 

INSERT [dbo].[Mst_UserType] ([UserTypeid], [UserTypeName]) VALUES (1, N'SuperAdmin')
INSERT [dbo].[Mst_UserType] ([UserTypeid], [UserTypeName]) VALUES (2, N'StateUser')
INSERT [dbo].[Mst_UserType] ([UserTypeid], [UserTypeName]) VALUES (3, N'TigerReserveUser')
SET IDENTITY_INSERT [dbo].[Mst_UserType] OFF
SET IDENTITY_INSERT [dbo].[PhotoGallery] ON 

INSERT [dbo].[PhotoGallery] ([GalleryId], [CategoryId], [MediaTypeId], [Title], [TitleRegLng], [Description], [DescriptionRegLng], [AltTag], [AltTagRegLng], [ImageName], [FileName], [StatusId], [StartDate], [EndDate], [DateInserted], [DateLastUpdated], [UserId], [IPAddress], [StateID], [TigerReserveid]) VALUES (1, 2, NULL, N'bihar photoe', N'photo in hindie', N'testing descriptione', N'description in hindie', N'bihar photoe', N'hindi photoe', N'Happy-Navratri-Images.JPG', NULL, 5, NULL, NULL, CAST(N'2017-09-21 00:41:42.603' AS DateTime), CAST(N'2017-09-21 13:03:19.370' AS DateTime), 0, N'::1', 5, 9)
INSERT [dbo].[PhotoGallery] ([GalleryId], [CategoryId], [MediaTypeId], [Title], [TitleRegLng], [Description], [DescriptionRegLng], [AltTag], [AltTagRegLng], [ImageName], [FileName], [StatusId], [StartDate], [EndDate], [DateInserted], [DateLastUpdated], [UserId], [IPAddress], [StateID], [TigerReserveid]) VALUES (2, 2, NULL, N'bihar photo1e', N'bihar photo1e', N'bihar photo1e', N'bihar photo1e', N'bihar photoe', N'bihar photoe', N'Happy-Navratri-Images.JPG', NULL, 5, NULL, NULL, CAST(N'2017-09-21 00:42:30.030' AS DateTime), CAST(N'2017-09-21 13:03:19.377' AS DateTime), 0, N'::1', 5, 9)
INSERT [dbo].[PhotoGallery] ([GalleryId], [CategoryId], [MediaTypeId], [Title], [TitleRegLng], [Description], [DescriptionRegLng], [AltTag], [AltTagRegLng], [ImageName], [FileName], [StatusId], [StartDate], [EndDate], [DateInserted], [DateLastUpdated], [UserId], [IPAddress], [StateID], [TigerReserveid]) VALUES (3, 2, NULL, N'bihar photo12', N'bihar photo12', N'bihar photo12', N'bihar photo12', N'bihar photo', N'bihar photo', N'Durga-Puja.JPG', NULL, 5, NULL, NULL, CAST(N'2017-09-21 00:45:44.167' AS DateTime), NULL, 0, N'::1', 5, 9)
INSERT [dbo].[PhotoGallery] ([GalleryId], [CategoryId], [MediaTypeId], [Title], [TitleRegLng], [Description], [DescriptionRegLng], [AltTag], [AltTagRegLng], [ImageName], [FileName], [StatusId], [StartDate], [EndDate], [DateInserted], [DateLastUpdated], [UserId], [IPAddress], [StateID], [TigerReserveid]) VALUES (4, 3, NULL, N'bihar photo', N'bihar photo1', N'bihar photo12', N'bihar photo1e', N'bihar photoe', N'hindi photoe', N'1-375.JPG', NULL, 5, NULL, NULL, CAST(N'2017-09-21 22:43:34.427' AS DateTime), NULL, 1, N'::1', 5, 9)
SET IDENTITY_INSERT [dbo].[PhotoGallery] OFF
SET IDENTITY_INSERT [dbo].[PhotoGallery_tmp] ON 

INSERT [dbo].[PhotoGallery_tmp] ([TempGalleryId], [GalleryId], [CategoryId], [MediaTypeId], [Title], [TitleRegLng], [Description], [DescriptionRegLng], [AltTag], [AltTagRegLng], [ImageName], [FileName], [StatusId], [StartDate], [EndDate], [DateInserted], [DateLastUpdated], [UserId], [IpAddress], [StateID], [TigerReserveid]) VALUES (6, NULL, 1, NULL, N'dasfdsf', N'sdfdsf', N'sdfdsf', N'sdafasdf', N'asdfds', N'sdfsdaf', N'Happy-Navratri-Images.JPG', NULL, 3, NULL, NULL, CAST(N'2017-09-21 13:48:38.117' AS DateTime), NULL, 1, N'::1', 1, 14)
INSERT [dbo].[PhotoGallery_tmp] ([TempGalleryId], [GalleryId], [CategoryId], [MediaTypeId], [Title], [TitleRegLng], [Description], [DescriptionRegLng], [AltTag], [AltTagRegLng], [ImageName], [FileName], [StatusId], [StartDate], [EndDate], [DateInserted], [DateLastUpdated], [UserId], [IpAddress], [StateID], [TigerReserveid]) VALUES (7, NULL, 1, NULL, N'werwerewr', N'werwe', N'rewr', N'werwer', N'ewrewr', N'werewrewr', N'Durga-Puja.JPG', NULL, 3, NULL, NULL, CAST(N'2017-09-21 13:48:58.297' AS DateTime), NULL, 1, N'::1', 1, 14)
SET IDENTITY_INSERT [dbo].[PhotoGallery_tmp] OFF
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (1, N'ANDAMAN AND NICOBAR ISLANDS', N'अंडमान और निकोबार द्वीप समूह')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (2, N'ANDHRA PRADESH', N'आंध्र प्रदेश')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (3, N'ARUNACHAL PRADESH', N'अरुणाचल प्रदेश')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (4, N'ASSAM', N'असम')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (5, N'BIHAR', N'बिहार')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (6, N'CHATTISGARH', N'छत्तीसगढ़')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (7, N'CHANDIGARH', N'चंडीगढ़')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (8, N'DAMAN AND DIU', N'दमन और दीव')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (9, N'DELHI', N'दिल्ली')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (10, N'DADRA AND NAGAR HAVELI', N'दादरा और नगर ​​हवेली')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (11, N'GOA', N'गोआ')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (12, N'GUJARAT', N'गुजरात')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (13, N'HIMACHAL PRADESH', N'हिमाचल प्रदेश')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (14, N'HARYANA', N'हरियाणा')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (15, N'JAMMU AND KASHMIR', N'जम्मू और कश्मीर')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (16, N'JHARKHAND', N'झारखंड')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (17, N'KERALA', N'केरल')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (18, N'KARNATAKA', N'कर्नाटक')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (19, N'LAKSHADWEEP', N'लक्षद्वीप')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (20, N'MEGHALAYA', N'मेघालय')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (21, N'MAHARASHTRA', N'महाराष्ट्र')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (22, N'MANIPUR', N'मणिपुर')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (23, N'MADHYA PRADESH', N'मध्य प्रदेश')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (24, N'MIZORAM', N'मिज़ोरम')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (25, N'NAGALAND', N'नागालैंड')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (26, N'ORISSA', N'ओडिशा')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (27, N'PUNJAB', N'पंजाब')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (28, N'PONDICHERRY', N'पांडिचेरी')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (29, N'RAJASTHAN', N'राजस्थान')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (30, N'SIKKIM', N'सिक्किम')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (31, N'TAMIL NADU', N'तमिलनाडु')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (32, N'TRIPURA', N'त्रिपुरा')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (33, N'UTTARAKHAND', N'उत्तराखंड')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (34, N'UTTAR PRADESH', N'उत्तर प्रदेश')
INSERT [dbo].[state_list] ([id], [StateName], [StateNameHindi]) VALUES (35, N'WEST BENGAL', N'पश्चिम बंगाल')
SET IDENTITY_INSERT [dbo].[Tbl_TigerReserve] ON 

INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (1, N'Kanha Tiger Reserve', N'कान्हा टाइगर रिजर्व', NULL, 23, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'22.334513', N'80.611513')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (2, N'Melghat Tiger Reserve', N'Melghat टाइगर रिजर्व', NULL, 21, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'21.406042', N'77.148516')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (3, N'Palamau Tiger Reserve', N'पलामू टाइगर रिजर्व', NULL, 16, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'24.039421', N'84.067873')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (4, N'Bandhavgarh Tiger Reserve', N'बांधवगढ़ टाइगर रिजर्व', NULL, 23, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'23.722454', N'81.024219')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (5, N'Panna Tiger Reserve', N'पन्ना टाइगर्स रिजर्व  ', NULL, 23, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'24.590466', N'79.941652')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (6, N'Satpura Tiger Reserve', N'सतपुड़ा टाइगर रिजर्व', NULL, 23, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'22.503331', N'78.435851')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (7, N'Sanjay-Dubri Tiger Reserve', N'Sanjay-Dubri टाइगर रिजर्व', NULL, 23, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'23.867828', N'82.062505')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (8, N'Sahyadri Tiger Reserve', N'Sahyadri टाइगर रिजर्व', NULL, 21, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'17.486215', N'73.809178')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (9, N'Valmiki Tiger Reserve', N'वाल्मीकि टाइगर रिजर्व', NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'27.379990', N'84.143514')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (10, N'Kaziranga Tiger Reserve', N'Kaziranga टाइगर रिजर्व', NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (11, N'Manas Tiger Reserve', N'मानस टाइगर रिजर्व', NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (12, N'Nameri Tiger Reserve', N'Nameri टाइगर रिजर्व', NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (13, N'Orang Tiger Reserve', N'Orang टाइगर रिजर्व', NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (14, N'Campbell Bay Tiger Reserve', N'Campbell Bay टाइगर रिजर्व', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (15, N'testing data', N'adfksj', 34, 9, 0, 0, N'', CAST(N'2017-09-27 15:00:28.110' AS DateTime), NULL, 1, 1, N'324', N'234234', N'4', N'23434')
INSERT [dbo].[Tbl_TigerReserve] ([TigerReserveid], [TigerReserveName], [TigerReserveNameHindi], [NoofVillages], [StateID], [Dist], [City], [TigerReserveMap], [CreationDate], [ModificationDate], [CreatedBy], [Status], [CoreArea], [BufferArea], [latitude], [longitude]) VALUES (16, N'Delhi Tiger Reserve', N'Delhi Tiger Reserve', 23, 9, 0, 0, N'', CAST(N'2017-09-27 15:34:36.917' AS DateTime), NULL, 1, 1, N'12', N'12', N'12', N'12')
SET IDENTITY_INSERT [dbo].[Tbl_TigerReserve] OFF
SET IDENTITY_INSERT [dbo].[Tbl_village_animal_Final] ON 

INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (5, 1, 1, 444)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (6, 1, 2, 333)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (7, 1, 3, 34)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (8, 1, 4, 3456)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (9, 2, 1, 1)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (10, 2, 2, 2)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (11, 2, 4, 4)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (12, 2, 3, 5)
INSERT [dbo].[Tbl_village_animal_Final] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (13, 2, 5, 8)
SET IDENTITY_INSERT [dbo].[Tbl_village_animal_Final] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Village_Animals] ON 

INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (6, NULL, 1, 8)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (7, NULL, 2, 2)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (8, NULL, 1, 121)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (9, NULL, 4, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (10, NULL, 2, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (11, NULL, 5, 12)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (12, NULL, 4, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (13, NULL, 2, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (14, NULL, 1, 12)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (15, NULL, 4, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (16, NULL, 2, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (17, NULL, 1, 12)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (18, NULL, 4, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (19, NULL, 2, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (20, NULL, 3, 12)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (21, NULL, 4, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (22, NULL, 2, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (29, 1, 2, 32)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (30, 1, 4, 3)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (31, 1, 3, 30)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (35, 6, 1, 74)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (36, 6, 2, 23)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (37, 6, 4, 101)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (38, 6, 3, 204)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (40, 7, 1, 333)
INSERT [dbo].[Tbl_Village_Animals] ([id], [villageid], [Animalid], [TotalAnimal]) VALUES (41, 7, 3, 5000)
SET IDENTITY_INSERT [dbo].[Tbl_Village_Animals] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Village_final] ON 

INSERT [dbo].[Tbl_Village_final] ([Villageid], [TigerReserveID], [Village_Name], [Agriculture_Land], [Population], [Residential_property], [Total_Standing_Trees], [Total_Livestock], [Relocated_from], [Relocated_place], [Total_well], [Other_Assets], [Current_location_Latitude], [Current_location_Longitude], [location_Latitude_From], [location_Longitude_From], [Submitedby], [SubmitedDate], [LastUpdatedby], [LastUpdateDate], [Status], [IPAddress], [Stateid]) VALUES (1, 9, N'Valmiki', CAST(73.00 AS Decimal(18, 2)), NULL, CAST(83.00 AS Decimal(18, 2)), 25, 562, N'testing place', N'Testing place 2', 41, N'25', N'25', N'22', N'25', N'33', 1, CAST(N'2017-09-27 12:26:33.863' AS DateTime), 1, CAST(N'2017-09-27 12:27:40.867' AS DateTime), 5, NULL, 5)
INSERT [dbo].[Tbl_Village_final] ([Villageid], [TigerReserveID], [Village_Name], [Agriculture_Land], [Population], [Residential_property], [Total_Standing_Trees], [Total_Livestock], [Relocated_from], [Relocated_place], [Total_well], [Other_Assets], [Current_location_Latitude], [Current_location_Longitude], [location_Latitude_From], [location_Longitude_From], [Submitedby], [SubmitedDate], [LastUpdatedby], [LastUpdateDate], [Status], [IPAddress], [Stateid]) VALUES (2, 16, N'Villageone', CAST(45.00 AS Decimal(18, 2)), NULL, CAST(3456.00 AS Decimal(18, 2)), 56, 45, N'village', N'village2', 23, N'adadfadf', N'23', N'', N'28765', N'38765', 10, CAST(N'2017-09-27 15:41:45.393' AS DateTime), NULL, NULL, 5, NULL, 9)
SET IDENTITY_INSERT [dbo].[Tbl_Village_final] OFF
SET IDENTITY_INSERT [dbo].[Tmp_Link] ON 

INSERT [dbo].[Tmp_Link] ([Temp_Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Link_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Start_Date], [End_Date], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (5, 2, 0, 0, 0, 1, 1, 1, 14, N'birendra testing for status', NULL, NULL, N'<p>birendra testing for status</p>', N'birendra testing for status', NULL, N'birendra testing for status', N'birendra testing for status', N'birendra testing for status', N'birendra testing for status', NULL, NULL, NULL, NULL, NULL, 5, NULL, 1, 0, 0, NULL, NULL, CAST(N'2017-09-09 03:18:01.030' AS DateTime), CAST(N'2017-09-09 03:30:08.570' AS DateTime), N'::1', N'birendratestingorstatus', N'en', N'birendra testing for status')
INSERT [dbo].[Tmp_Link] ([Temp_Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Link_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Start_Date], [End_Date], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (22, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'testing banner', N'testing in hindi', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'banner(1).jpg', N'alt', N'alt hin', 3, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2017-09-10 11:19:55.363' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tmp_Link] OFF
SET IDENTITY_INSERT [dbo].[UserPermission] ON 

INSERT [dbo].[UserPermission] ([id], [Userid], [TigerReserveid]) VALUES (1, 2, 14)
INSERT [dbo].[UserPermission] ([id], [Userid], [TigerReserveid]) VALUES (2, 4, 14)
INSERT [dbo].[UserPermission] ([id], [Userid], [TigerReserveid]) VALUES (6, 10, 15)
INSERT [dbo].[UserPermission] ([id], [Userid], [TigerReserveid]) VALUES (7, 10, 16)
INSERT [dbo].[UserPermission] ([id], [Userid], [TigerReserveid]) VALUES (8, 9, 15)
INSERT [dbo].[UserPermission] ([id], [Userid], [TigerReserveid]) VALUES (9, 9, 16)
INSERT [dbo].[UserPermission] ([id], [Userid], [TigerReserveid]) VALUES (10, 7, 14)
SET IDENTITY_INSERT [dbo].[UserPermission] OFF
SET IDENTITY_INSERT [dbo].[Web_Link] ON 

INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (1, 2, 0, 1, 0, 1, 1, 1, 14, N'second Tiger Reservee', NULL, NULL, N'<p>second Tiger Reservee</p>', N'TEST', NULL, N'second Tiger Reservee', N'second Tiger Reservee', N'second Tiger Reservee', N'second Tiger Reservee', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, 0, CAST(N'2017-09-10 00:08:38.263' AS DateTime), CAST(N'2017-09-10 00:08:38.263' AS DateTime), N'::1', N'secondTigerReservee', N'en', N'second Tiger Reservee')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (2, 2, 1, 1, 1, 1, 1, 1, 14, N'sublink1', NULL, NULL, N'<p>sublink1</p>', N'sublink1', NULL, N'sublink1', N'sublink1', N'sublink1', N'sublink1', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, NULL, CAST(N'2017-09-09 15:11:34.907' AS DateTime), NULL, N'::1', N'sublink1', N'en', N'sublink1')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (3, 2, 1, 2, 1, 1, 1, 1, 14, N'Sublink', NULL, NULL, N'<p>Sublink</p>', N'Sublink', NULL, N'Sublink', N'Sublink', N'Sublink', N'Sublink', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, NULL, CAST(N'2017-09-09 15:11:34.930' AS DateTime), NULL, N'::1', N'Sublink', N'en', N'Sublink')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (4, 2, 2, 1, 2, 1, 1, 1, 14, N'sublinkofsublink', NULL, NULL, N'<p>sublinkofsublink</p>', N'sublinkofsublink', NULL, N'sublinkofsublink', N'sublinkofsublink', N'sublinkofsublink', N'sublinkofsublink', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, NULL, CAST(N'2017-09-09 15:12:39.027' AS DateTime), NULL, N'::1', N'sublinkofsublink', N'en', N'sublinkofsublink')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (5, 2, 0, 2, 0, 1, 1, 1, 14, N'TigerReserveid2', NULL, NULL, N'<p>TigerReserveid2</p>', N'asdfasdfsadf', NULL, N'TigerReserveid2', N'TigerReserveid2', N'TigerReserveid2', N'TigerReserveid2', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, 0, CAST(N'2017-09-10 00:14:26.667' AS DateTime), NULL, N'::1', N'TigerReserveid2', N'en', N'TigerReserveid2')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (6, 2, 0, 3, 0, 1, 1, 1, 14, N'Home', NULL, NULL, N'<p>Home</p>', N'Home', NULL, N'Home', N'Home', N'Home', N'Home', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, NULL, CAST(N'2017-09-10 00:17:38.040' AS DateTime), NULL, N'::1', N'Home', N'en', N'Home')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (7, 2, 0, 4, 0, 1, 1, 1, 14, N'मुख्य पृष्ठ', NULL, NULL, N'<p>मुख्य पृष्ठ</p>', N'मुख्य पृष्ठ', NULL, N'मुख्य पृष्ठ', N'मुख्य पृष्ठ', N'मुख्य पृष्ठ', N'मुख्य पृष्ठ', NULL, NULL, NULL, NULL, NULL, 5, 2, 0, NULL, CAST(N'2017-09-10 00:33:55.413' AS DateTime), NULL, N'::1', N'Home', N'en', N'????? ?????')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (8, 2, 5, 1, 1, 1, 1, 1, 14, N'submenu tiger reserve', NULL, NULL, N'<p>submenu tiger reserve</p>', N'submenu tiger reserve', NULL, N'submenu tiger reserve', N'submenu tiger reserve', N'submenu tiger reserve', N'submenu tiger reserve', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, NULL, CAST(N'2017-09-10 02:33:23.493' AS DateTime), NULL, N'::1', N'submenutigerreserve', N'en', N'submenu tiger reserve')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (9, 2, 0, 5, 0, 1, 1, 5, 9, N'Bihar  Valmiki Tiger Reserve', NULL, NULL, N'<p>Bihar&nbsp; Valmiki Tiger Reserve</p>', N'Bihar  Valmiki Tiger Reserve', NULL, N'Bihar  Valmiki Tiger Reserve', N'Bihar  Valmiki Tiger Reserve', N'Bihar  Valmiki Tiger Reserve', N'Bihar  Valmiki Tiger Reserve', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, NULL, CAST(N'2017-09-10 03:04:22.127' AS DateTime), NULL, N'::1', N'bihartigerreserve', N'en', N'Bihar  Valmiki Tiger Reserve')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (10, 3, NULL, 1, NULL, NULL, NULL, 1, 14, N'testing bannere', N'testing in hindie', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'banner(5).jpg', N'alte', N'alt hine', 5, NULL, 0, 0, CAST(N'2017-09-11 01:29:34.127' AS DateTime), CAST(N'2017-09-11 01:29:34.127' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (11, 3, NULL, 1, NULL, NULL, NULL, 1, 14, N'Banner 2', N'Banner 2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'banner(5).jpg', N'Banner 2', N'Banner 2', 5, NULL, 0, 0, CAST(N'2017-09-11 01:45:30.557' AS DateTime), CAST(N'2017-09-11 01:45:30.557' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (12, 2, 0, 6, 0, 1, 2, 1, 14, N'Tiger Reserve in India', NULL, NULL, N'<p><a>Tiger Reserve in India</a></p>', N'Tiger Reserve in India', NULL, N'Tiger Reserve in India', N'Tiger Reserve in India', N'Tiger Reserve in India', N'Tiger Reserve in India', NULL, NULL, NULL, NULL, NULL, 5, 1, 1, NULL, CAST(N'2017-09-14 01:28:44.407' AS DateTime), NULL, N'::1', N'TigeReserve', N'en', N'Tiger Reserve in India')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (13, 2, 0, 7, 0, 1, 2, 1, 14, N'Why Relocation', NULL, NULL, N'<p><a>Why Relocation</a></p>', N'Why Relocation', NULL, N'Why Relocation', N'Why Relocation', N'Why Relocation', N'Why Relocation', NULL, NULL, NULL, NULL, NULL, 5, 1, 1, NULL, CAST(N'2017-09-14 01:28:44.450' AS DateTime), NULL, N'::1', N'WhyRelocation', N'en', N'Why Relocation')
INSERT [dbo].[Web_Link] ([Link_Id], [Module_Id], [Link_Parent_Id], [Link_Order], [Link_Level], [Link_Type_Id], [Position_Id], [StateID], [TigerReserveid], [Name], [Name_Reg], [Subject], [Details], [SmallDetails], [Details_Reg], [Browser_Title], [Page_Title], [Meta_Keywords], [Mate_Description], [Url], [File_Name], [Image_Name], [Alt_Tag], [AltTag_Reg], [Status_Id], [Lang_Id], [Inserted_By], [Last_Updated_By], [Rec_Insert_Date], [Rec_Update_Date], [IpAddress], [UrlName], [MetaLanguage], [MetaTitle]) VALUES (14, 2, 5, 2, 1, 1, 1, 1, 14, N'Introduction', NULL, NULL, N'<p>Valmiki Tiger Reserve forms the eastern most limit of the Himalayan  Terai forests in India, and is the only tiger reserve of Bihar. Situated  in the Gangetic Plains bio-geographic zone of the country, the forest  has combination of bhabar and terai tracts. Valmiki Tiger Reserve lies  in the north-westernmost West Champaran district of Bihar. Name of the  district has been derived from two words Champa and Aranya meaning  Forest of Champa trees.</p>
<p><b>Wild Animal Diversity</b><br />
Wild mammals found in the forests of Valmiki Tiger Reserve are Tiger, Sloth bear, Leopard, Wild dog, Bison, Wild boar etc. Several species of deer and antelopes viz barking deer, spotted deer, hog deer, sambar and blue bull are also found here. In Madanpur forest block large number of Indian flying foxes can be sighted. The Reserve has rich avi-fauna diversity. Over 250 species of birds have been reported.<br />
&nbsp;</p>', N'', NULL, N'Tiger', N'Tiger Reserve Introduction', N'intro', N'intro', NULL, NULL, NULL, NULL, NULL, 5, 1, 0, NULL, CAST(N'2017-09-14 02:42:01.770' AS DateTime), NULL, N'::1', N'aboutusintro', N'en', N'')
SET IDENTITY_INSERT [dbo].[Web_Link] OFF
ALTER TABLE [dbo].[Category_Tmp]  WITH NOCHECK ADD  CONSTRAINT [FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Mst_Users] ([UserID])
GO
ALTER TABLE [dbo].[Category_Tmp] NOCHECK CONSTRAINT [FK_UserId]
GO
/****** Object:  StoredProcedure [dbo].[AddNewUser]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[AddNewUser] 
(
		@Userid int = null,
		@UserName nvarchar(50),
           @FirstName nvarchar(20),
           @LastName nvarchar(20),
           @Password nvarchar(max),
           @UserType int,
           @EmailID nvarchar(100)
		   ,
           @Address1  nvarchar(200),
           @Address2 nvarchar(200),
           @PermissionState int,
           @pincode char(6),
           @Landline nvarchar(20),
           @AreaCode char(5),
           @Mobile nvarchar(15)
           
)
As
Begin

if(@Userid is null)
  Begin

INSERT INTO [dbo].[Mst_Users]
           ([UserName]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[UserType]
           ,[EmailID]
           ,[Address1]
           ,[Address2]
           ,[PermissionState]
           ,[pincode]
           ,[Landline]
           ,[AreaCode]
           ,[Mobile]
           ,[Status])
     VALUES
           (@UserName,
           @FirstName,
           @LastName,
           @Password,
           @UserType,
           @EmailID
		   ,
           @Address1, 
           @Address2,
           @PermissionState,
           @pincode,
           @Landline, 
           @AreaCode,
           @Mobile,
           'true')

End
Else
  Begin
      Update Mst_Users set FirstName=@FirstName,LastName=@LastName,UserType=@UserType,EmailID=@EmailID,
	                        Address1=@Address1,Address2=@Address2,PermissionState=@PermissionState,pincode=@pincode,
							Landline=@Landline,AreaCode=@AreaCode,Mobile=@Mobile where UserID=@Userid
  End

End




GO
/****** Object:  StoredProcedure [dbo].[Asp_Add_Family_Detials]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Asp_Add_Family_Detials]
(
@Stateid int,
@TigerReserveid int,
@VillageID int,
@Head_Name nvarchar(200),
@Agriculature_land decimal(18,2),
@Residential_Property decimal(18,2),
@Total_Livestock int,
@Other_assest varchar(max),
@Longitude varchar(20),
@Latitude varchar(20),
@SanctionLeter varchar(100),
@Submitedby int = null,
@IPAddress nvarchar(20),
@UpdatedBy int =null,
@FamilyMember TypeFamilyMember ReadOnly,
@FamilyAnimal TypeFamilyAnimal Readonly
)
as
Begin
   Declare @fid int
  Insert into Tbl_Family(Stateid ,TigerReserveid ,VillageID  ,Head_Name ,Agriculature_land ,Residential_Property ,
Total_Livestock ,Other_assest  ,Longitude ,Latitude  ,SanctionLeter,Submitedby  ,SubmitedDate,IPAddress)
  Values(@Stateid,@TigerReserveid,@VillageID,@Head_Name,@Agriculature_land,@Residential_Property,@Total_Livestock,
             @Other_assest,@Longitude,@Latitude,@SanctionLeter,@Submitedby,getdate(),@IPAddress)

set @fid=scope_identity()

Insert into Tbl_family_animal(Familyid,AnimalType,NOofAnimal)
               Select @fid,AnimalType,NOofAnimal from @FamilyAnimal

Insert into Tbl_family_Member(familyid,MemberName,Age,Year_Month,Gender,Relation,AadharCardNo,AadharCardFile)
Select @fid,MemberName,Age,Year_Month,Gender,Relation,AadharCardNo,AadharCardFile from @FamilyMember
 

End

GO
/****** Object:  StoredProcedure [dbo].[ASP_Approve_Village]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_Approve_Village]          
(          
   @TempVillageid INT =NULL,          
   @UserID INT = NULL,        
   @IpAddress NVARCHAR(50) = NULL,     
   
   @recordCount INT OUTPUT          
)          
AS          
BEGIN                   
  BEGIN TRY                    
   BEGIN TRANSACTION -- Start the Transaction                    
   SET NOCOUNT ON;                    
                      
  DECLARE @Old_VillageID  int                 
  SET @Old_VillageID=(select Villageid from Tbl_village where TempVillageid=@TempVillageid)                  
              
      IF @Old_VillageID IS NULL  --query to insert record from temp to final                 
   BEGIN       
   Declare @id int        
  INSERT INTO [dbo].[Tbl_Village_final]
           ([TigerReserveID],[Village_Name],[Agriculture_Land],[Population],[Residential_property],[Total_Standing_Trees]
           ,[Total_Livestock],[Relocated_from],[Relocated_place],[Total_well],[Other_Assets],[Current_location_Latitude]
           ,[Current_location_Longitude],[location_Latitude_From],[location_Longitude_From],[Submitedby]
           ,[SubmitedDate],[LastUpdatedby],[LastUpdateDate],[Status],[IPAddress],[Stateid])

SELECT TigerReserveID, Village_Name, Agriculture_Land, [Population],Residential_property,Total_Standing_Trees,
       Total_Livestock,Relocated_from,Relocated_place,Total_well,Other_Assets,Current_location_Latitude,
       Current_location_Longitude,location_Latitude_From,location_Longitude_From,Submitedby,
       SubmitedDate,LastUpdatedby, LastUpdateDate, 5,IPAddress,[Stateid]
FROM Tbl_village                                  
   WHERE TempVillageid=@TempVillageid            
             
            
        set @id=SCOPE_IDENTITY()    


   DELETE FROM Tbl_village                                    
   WHERE  TempVillageid=@TempVillageid
   
    
    Insert into Tbl_village_animal_Final (villageid,Animalid,TotalAnimal)
    select @id,Animalid,TotalAnimal from Tbl_Village_Animals where villageid=@TempVillageid
    Delete from Tbl_Village_Animals where villageid=@TempVillageid
                 
                  
   SET @recordCount=@@ROWCOUNT                 
   END           
             
       ELSE         --query to update record from temp to final           
  BEGIN              
               
  UPDATE [dbo].[Tbl_Village_final]
    SET 
      [TigerReserveID] =Tbl_village.TigerReserveID
      ,[Village_Name] = Tbl_village.Village_Name
      ,[Agriculture_Land] =Tbl_village.Agriculture_Land
      ,[Population] = Tbl_village.Population
      ,[Residential_property] = Tbl_village.Residential_property
      ,[Total_Standing_Trees] =Tbl_village.Total_Standing_Trees
      ,[Total_Livestock] =Tbl_village.Total_Livestock
      ,[Relocated_from] =Tbl_village.Relocated_from
      ,[Relocated_place] =Tbl_village.Relocated_place
      ,[Total_well] =Tbl_village.Total_well
      ,[Other_Assets] =Tbl_village.Other_Assets
      ,[Current_location_Latitude] =Tbl_village.Current_location_Latitude
      ,[Current_location_Longitude] = Tbl_village.Current_location_Longitude
      ,[location_Latitude_From] = Tbl_village.location_Latitude_From
      ,[location_Longitude_From] = Tbl_village.location_Longitude_From
     
     
      ,[LastUpdatedby] =@UserID
      ,[LastUpdateDate] = GETDATE()      
      ,[Stateid]=Tbl_village.Stateid
     FROM [Tbl_Village_final], [Tbl_village]                       
     WHERE [Tbl_Village_final].Villageid=@Old_VillageID  AND [Tbl_village].Villageid =@Old_VillageID                  
                           
               
     DELETE from [Tbl_village]   WHERE  TempVillageid=@TempVillageid  
     
     
     Delete from Tbl_village_animal_Final where villageid=@Old_VillageID

     Insert into Tbl_village_animal_Final (villageid,Animalid,TotalAnimal)
    select @Old_VillageID,Animalid,TotalAnimal from Tbl_Village_Animals where villageid=@TempVillageid
    Delete from Tbl_Village_Animals where villageid=@TempVillageid
                
     SET @recordCount=@@ROWCOUNT  
     
     
     
    
               
      END          
                
             
  SET NOCOUNT OFF;          
  COMMIT --Commit the transaction                             
 END TRY                    
                     
 BEGIN CATCH                    
 --There was an error                    
  exec sp_error_handler                    
  IF @@TRANCOUNT>0                    
   ROLLBACK                     
  RETURN -101                    
                        
 END CATCH                    
                    
 RETURN 0                    
END
GO
/****** Object:  StoredProcedure [dbo].[ASP_CountRootLevel_Link]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_CountRootLevel_Link]          

(            

 @rootLevelId int            

)             

            

AS                  

BEGIN                    

    BEGIN TRY                

                

  SET NOCOUNT ON;                   

  SELECT TOP 1 link_id,link_order,link_level,link_parent_id               

  FROM Web_Link                  

  WHERE Link_Id=@rootLevelId               

               

  SET NOCOUNT OFF;             

                

     END TRY                    

                      

  BEGIN CATCH                    

   --There was an error                    

   EXEC sp_error_handler                    

   IF @@TRANCOUNT>0                    

   ROLLBACK                     

   RETURN -101                    

  END CATCH                    

 RETURN 0                      

                

END


GO
/****** Object:  StoredProcedure [dbo].[asp_DisplayDistrict]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[asp_DisplayDistrict]       
(                    
               
 @StateID int=null,
 --Variables for paging                
                 
 @PageIndex INT = NULL,                
 @PageSize INT = NULL,                
 @RecordCount INT OUTPUT                   
                
--end                 
)                    
AS                     
 BEGIN                    
  BEGIN TRY                    
   SET NOCOUNT ON;                   
                   
   SELECT ROW_NUMBER() OVER                
      (                
       ORDER BY DistID ASC                
      )AS RowNumber, DistID, DistName,convert(NVARCHAR(10), InsertDate,103)as InsertDate,[dbo].[GetUserName](InsertedBy)as  InsertedBy                  
                        
     INTO #Results                
                     
      FROM Mst_Dist                 
      WHERE StateID=@StateID
                      
      SELECT @RecordCount = COUNT(*)                
      FROM #Results                
                           
      SELECT * FROM #Results                
     -- WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1                
                     
      DROP TABLE #Results                
               
                   
                
                  
   SET NOCOUNT OFF;                    
  END TRY                    
  BEGIN CATCH                            
   --There was an error                            
    exec sp_error_handler                            
    IF @@TRANCOUNT>0                            
    ROLLBACK                             
    RETURN -101                            
                                 
  END CATCH                                     
  RETURN 0                    
   END

GO
/****** Object:  StoredProcedure [dbo].[asp_DisplayDistrictTehshil]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[asp_DisplayDistrictTehshil]     
(                    
               
 @Distid int=null,
 --Variables for paging                
                 
 @PageIndex INT = NULL,                
 @PageSize INT = NULL,                
 @RecordCount INT OUTPUT                   
                
--end                 
)                    
AS                     
 BEGIN                    
  BEGIN TRY                    
   SET NOCOUNT ON;                   
                   
   SELECT ROW_NUMBER() OVER                
      (                
       ORDER BY Tehsil ASC                
      )AS RowNumber, Tehsil, Tehsil_Name,convert(NVARCHAR(10), DateofInsert,103)as DateofInsert,[dbo].[GetUserName](SubmitBy)as  SubmitBy                  
                        
     INTO #Results                
                     
      FROM Tbl_Tehsil                 
      WHERE Distid=@Distid
                      
      SELECT @RecordCount = COUNT(*)                
      FROM #Results                
                           
      SELECT * FROM #Results                
     -- WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1                
                     
      DROP TABLE #Results                
               
                   
                
                  
   SET NOCOUNT OFF;                    
  END TRY                    
  BEGIN CATCH                            
   --There was an error                            
    exec sp_error_handler                            
    IF @@TRANCOUNT>0                            
    ROLLBACK                             
    RETURN -101                            
                                 
  END CATCH                                     
  RETURN 0                    
   END

GO
/****** Object:  StoredProcedure [dbo].[asp_DisplayTehshilGrampanchayat]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[asp_DisplayTehshilGrampanchayat]     
(                    
               
 @Tehsilid int=null,
 --Variables for paging                
                 
 @PageIndex INT = NULL,                
 @PageSize INT = NULL,                
 @RecordCount INT OUTPUT                   
                
--end                 
)                    
AS                     
 BEGIN                    
  BEGIN TRY                    
   SET NOCOUNT ON;                   
                   
   SELECT ROW_NUMBER() OVER                
      (                
       ORDER BY GramPanchayatID ASC                
      )AS RowNumber, GramPanchayatID, GramPanchayatName,convert(NVARCHAR(10), DateofInsert,103)as DateofInsert,[dbo].[GetUserName](SubmitBy)as  SubmitBy                  
                        
     INTO #Results                
                     
      FROM Tbl_Grampanchayat                 
      WHERE Tehsilid=@Tehsilid
                      
      SELECT @RecordCount = COUNT(*)                
      FROM #Results                
                           
      SELECT * FROM #Results                
     -- WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1                
                     
      DROP TABLE #Results                
               
                   
                
                  
   SET NOCOUNT OFF;                    
  END TRY                    
  BEGIN CATCH                            
   --There was an error                            
    exec sp_error_handler                            
    IF @@TRANCOUNT>0                            
    ROLLBACK                             
    RETURN -101                            
                                 
  END CATCH                                     
  RETURN 0                    
   END

GO
/****** Object:  StoredProcedure [dbo].[Asp_forntuserLogin]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Asp_forntuserLogin]

(
@UserName nvarchar(50)
)
As
Begin
    Select * from Mst_Users where [UserName]=@UserName and [Status]='True' and UserType <> 1
End

GO
/****** Object:  StoredProcedure [dbo].[Asp_Get_family_AnimalList]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Proc [dbo].[Asp_Get_family_AnimalList]
(
@familyidId int
)
as
Begin
  Select ROW_NUMBER() OVER (ORDER by ID) as RowNumber,[ID],Familyid,AnimalType,NOofAnimal from Tbl_family_animal where Familyid=@familyidId
  
End

GO
/****** Object:  StoredProcedure [dbo].[ASP_Get_Gallery_Tmp]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_Get_Gallery_Tmp]                

(                

 @TempGalleryId  INT = NULL,                

 @CategoryId    INT = NULL,                

 @StatusID  INT = NULL ,  

 @CatName nvarchar(100)=NULL,           

 @StateID int = null,
 @TigerReserveID int = null,        

 --Variables for paging              

               

 @PageIndex INT = NULL,              

 @PageSize INT = NULL,              

 @RecordCount INT OUTPUT                 

              

--end                  

)                

AS                 

 BEGIN                

  BEGIN TRY                

   SET NOCOUNT ON;                

                   

   IF @StatusID != 5              

                   

   BEGIN                

                   

     SELECT ROW_NUMBER() OVER              

      (              

            ORDER BY [TempGalleryId] ASC              

      )AS RowNumber, [TempGalleryId],[CategoryId],[MediaTypeId],[Title],[TitleRegLng],[Description],DescriptionRegLng,([Description]+' '+'('+[DescriptionRegLng]+')')as [Description_Com] ,                

      [AltTag],[AltTagRegLng],[ImageName],[FileName],[StatusId],[GalleryId],                

      CONVERT(NVARCHAR(10),[StartDate],101) AS [StartDate],                

      CONVERT(NVARCHAR(10),[EndDate],101) AS [EndDate],[DateInserted],                

      [DateLastUpdated],[UserId]             

                  

      INTO #Results            

                     

    FROM PhotoGallery_tmp               

    WHERE TempGalleryId=ISNULL(@TempGalleryId,TempGalleryId)                  

     AND CategoryId=ISNULL(@CategoryId,CategoryId)                

     AND StatusID = @StatusID  AND StateID = @StateID AND TigerReserveid = @TigerReserveID         

                 

      SELECT @RecordCount = COUNT(*)              

      FROM #Results              

                         

      SELECT * FROM #Results              

      --WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1              

                   

      DROP TABLE #Results              

                   

   END                

                   

   ELSE                

                   

   BEGIN                

                   

     SELECT ROW_NUMBER() OVER              

      (              

            ORDER BY [GalleryId] ASC              

      )AS RowNumber, [GalleryId]AS [TempGalleryId],[GalleryId],[CategoryId],[MediaTypeId],[Title],[TitleRegLng],[Description],DescriptionRegLng,([Description]+' '+'('+[DescriptionRegLng]+')')as [Description_Com] ,                

    [AltTag],[AltTagRegLng],[ImageName],[FileName],[StatusId],                

      CONVERT(NVARCHAR(10),[StartDate],101) AS [StartDate],                

      CONVERT(NVARCHAR(10),[EndDate],101) AS [EndDate],                

      [DateInserted],[DateLastUpdated],[UserId]             

                  

       INTO #Results1             

                      

    FROM PhotoGallery               

    WHERE GalleryId=ISNULL(@TempGalleryId,GalleryId)                 

     AND CategoryId=ISNULL(@CategoryId,CategoryId)                

     AND StatusID = @StatusID AND StateID = @StateID AND TigerReserveid = @TigerReserveID           

                 

      SELECT @RecordCount = COUNT(*)              

      FROM #Results1              

                         

      SELECT * FROM #Results1              

      --WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1              

                   

      DROP TABLE #Results1                 

                     

   END                

                

   SET NOCOUNT OFF;                

  END TRY                

  BEGIN CATCH                        

   --There was an error                        

    exec sp_error_handler                        

    IF @@TRANCOUNT>0                        

    ROLLBACK                         

    RETURN -101                        

                             

  END CATCH                                 

  RETURN 0             

   END






GO
/****** Object:  StoredProcedure [dbo].[ASP_Get_Gallery_Tmp_Edit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_Get_Gallery_Tmp_Edit]    

(        

 @TempGalleryId  INT = NULL,        

 @MCategoryId    INT = NULL,        

 @StatusID  INT = NULL        

)        

AS         

 BEGIN        

  BEGIN TRY        

   SET NOCOUNT ON;        

           

   IF @StatusID !=5        

           

   BEGIN        

           

    SELECT [TempGalleryId],[CategoryId],[MediaTypeId],[Title],[TitleRegLng],[Description],DescriptionRegLng,([Description]+' '+'('+[DescriptionRegLng]+')')as [Description_Com] ,        

      [AltTag],[AltTagRegLng],[ImageName],[FileName],[StatusId],[GalleryId],        

      CONVERT(NVARCHAR(10),[StartDate],101) AS [StartDate],        

      CONVERT(NVARCHAR(10),[EndDate],101) AS [EndDate],[DateInserted],        

      [DateLastUpdated],[UserId],StateID,TigerReserveid        

    FROM PhotoGallery_tmp      

    WHERE TempGalleryId=ISNULL(@TempGalleryId,TempGalleryId)          

     AND CategoryId=ISNULL(@MCategoryId,CategoryId)        

     AND StatusID = @StatusID        

           

   END        

           

   ELSE        

           

   BEGIN        

           

    SELECT [GalleryId]AS [TempGalleryId],[GalleryId],[CategoryId],[MediaTypeId],[Title],[TitleRegLng],[Description],DescriptionRegLng,([Description]+' '+'('+[DescriptionRegLng]+')')as [Description_Com] ,        

    [AltTag],[AltTagRegLng],[ImageName],[FileName],[StatusId],        

      CONVERT(NVARCHAR(10),[StartDate],101) AS [StartDate],        

      CONVERT(NVARCHAR(10),[EndDate],101) AS [EndDate],        

      [DateInserted],[DateLastUpdated],[UserId],StateID,TigerReserveid        

    FROM PhotoGallery   

    WHERE GalleryId=ISNULL(@TempGalleryId,GalleryId)         

     AND CategoryId=ISNULL(@MCategoryId,CategoryId)        

     AND StatusID = @StatusID        

             

   END        

        

   SET NOCOUNT OFF;        

  END TRY        

  BEGIN CATCH                

   --There was an error                

    exec sp_error_handler                

    IF @@TRANCOUNT>0                

    ROLLBACK                 

    RETURN -101                

                     

  END CATCH                         

  RETURN 0        

   END






GO
/****** Object:  StoredProcedure [dbo].[ASP_Get_NGODetails]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[ASP_Get_NGODetails]                
(                
 @NgoIDTemp  INT = NULL,                
                
 @StatusID  INT = NULL ,  
            
 @StateID int = null,
        
 --Variables for paging              
               
 @PageIndex INT = NULL,              
 @PageSize INT = NULL,              
 @RecordCount INT OUTPUT                 
              
--end                  
)                
AS                 
 BEGIN                
  BEGIN TRY                
   SET NOCOUNT ON;                
                   
   IF @StatusID != 5              
                   
   BEGIN                
                   
     SELECT ROW_NUMBER() OVER              
      (              
            ORDER BY NgoIDTemp ASC              
      )AS RowNumber, NgoIDTemp,NgoID,NgoName,NgoAddress,PhoneNumber,MobileNumber,WorkDoneByNGO,StatusID            
                  
      INTO #Results            
                     
    FROM tbl_NgoTemp               
    WHERE NgoIDTemp=ISNULL(@NgoIDTemp,NgoIDTemp)                  
     AND StatusID = @StatusID  AND StateID = @StateID 
                 
      SELECT @RecordCount = COUNT(*)              
      FROM #Results              
                         
      SELECT * FROM #Results              
      --WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1              
                   
      DROP TABLE #Results              
                   
   END                
                   
   ELSE                
                   
   BEGIN                
                   
     SELECT ROW_NUMBER() OVER              
      (              
            ORDER BY [NgoID] ASC              
      )AS RowNumber, NgoID as NgoIDTemp ,NgoID,NgoName,NgoAddress,PhoneNumber,MobileNumber,WorkDoneByNGO,StatusID       
                  
       INTO #Results1             
                      
    FROM tbl_NgoFinal               
    WHERE NgoID=ISNULL(@NgoIDTemp,NgoID)                 
                  
     AND StatusID = @StatusID AND StateID = @StateID            
                 
      SELECT @RecordCount = COUNT(*)              
      FROM #Results1              
                         
      SELECT * FROM #Results1              
      --WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1              
                   
      DROP TABLE #Results1                 
                     
   END                
                
   SET NOCOUNT OFF;                
  END TRY                
  BEGIN CATCH             
   --There was an error                        
    exec sp_error_handler                        
    IF @@TRANCOUNT>0                        
    ROLLBACK                         
    RETURN -101                        
                             
  END CATCH                                 
  RETURN 0             
   END
GO
/****** Object:  StoredProcedure [dbo].[ASP_Get_Photo_Category_Name]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_Get_Photo_Category_Name]   

(        

  @StateID INT = NULL,              

  @TigerReserveID INT = NULL

)            

 AS               

 BEGIN              

  BEGIN TRY              

 SET NOCOUNT ON;         

  SELECT CategoryId,([CatName])as PhotoCategoryName           

  FROM Category            

  WHERE StatusID!=8   and StateID=@StateID and TigerReserveid=@TigerReserveID     

          

        

 SET NOCOUNT OFF;              

  END TRY              

  BEGIN CATCH                      

   --There was an error                      

    exec sp_error_handler                      

    IF @@TRANCOUNT>0                      

    ROLLBACK                       

    RETURN -101                      

                           

  END CATCH                               

  RETURN 0              

   END






GO
/****** Object:  StoredProcedure [dbo].[ASP_Get_Village_DetailsForEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[ASP_Get_Village_DetailsForEdit]
(
  @Villageid int,
  @Stattus int
)
AS
Begin
    if (@Stattus = 3)
	  Begin
	        

SELECT [TempVillageid]
,[TigerReserveID]
,[Village_Name]
,[Agriculture_Land]
,[Population]
,[Residential_property]
,[Total_Standing_Trees]
,[Total_Livestock]
,[Relocated_from]
,[Relocated_place]
,[Total_well]
,[Other_Assets]
,[Current_location_Latitude]
,[Current_location_Longitude]
,[location_Latitude_From]
,[location_Longitude_From]
,[Submitedby]
,[SubmitedDate]
,[LastUpdatedby]
,[LastUpdateDate]
,[Status]
,[Villageid],[Stateid]
  FROM [dbo].[Tbl_village] where  TempVillageid=@Villageid
  End
  Else
     Begin
	   

SELECT [Villageid],[TigerReserveID],[Village_Name],[Agriculture_Land],[Population],[Residential_property],[Total_Standing_Trees]
,[Total_Livestock],[Relocated_from],[Relocated_place],[Total_well],[Other_Assets],[Current_location_Latitude],[Current_location_Longitude]
,[location_Latitude_From],[location_Longitude_From],[Submitedby],[SubmitedDate],[LastUpdatedby],[LastUpdateDate],[Status],[Stateid]
 FROM [dbo].[Tbl_Village_final]  where  Villageid=@Villageid
  End
End

GO
/****** Object:  StoredProcedure [dbo].[ASP_GetData_For_Edit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_GetData_For_Edit]       

(        

 @LangId int =null,        

 @Status_Id int=null,        

 @TempLink_Id int=null        

)        

AS          

 BEGIN          

           

 BEGIN TRY                

   BEGIN TRAN             

  SET NOCOUNT ON;            

                

    IF  @Status_Id!=5      

  BEGIN            

     SELECT [Temp_Link_Id],[Module_Id],         

    [Name],[Page_Title],[Details]          

     ,[Image_Name] ,[Alt_Tag],[Status_Id],Link_Id          

     ,[Rec_Insert_Date],[Rec_Update_Date],Name_Reg,AltTag_Reg ,stateID ,TigerReserveid        

     FROM Tmp_Link        

     WHERE Status_Id=@Status_Id AND [Temp_Link_Id]=@TempLink_Id      

             

  END        

 ELSE   

  BEGIN        

          

   SELECT Link_Id AS TempLink_Id,[Module_Id],         

    [Name],[Page_Title],[Details]          

     ,[Image_Name] ,[Alt_Tag],[Status_Id],Link_Id          

     ,[Rec_Insert_Date],[Rec_Update_Date],Name_Reg,AltTag_Reg ,stateID ,TigerReserveid           

    FROM  Web_Link        

    WHERE  Status_Id=@Status_Id  AND Link_Id=@TempLink_Id     

          

  END               

               

  SET NOCOUNT OFF;             

    COMMIT TRAN                

  END TRY                

                  

  BEGIN CATCH                

   --There was an error                

   EXEC sp_error_handler                

   IF @@TRANCOUNT>0                

   ROLLBACK                 

   RETURN -101                

  END CATCH                

 RETURN 0                

           

 END


GO
/****** Object:  StoredProcedure [dbo].[ASP_GetDistrictNameEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ASP_GetDistrictNameEdit]               
(                  
 @DistID INT = NULL             
             
)                  
AS                   
 BEGIN                  
  BEGIN TRY                  
   SET NOCOUNT ON;                 
               
                
     SELECT DistID,DistName,StateID               
      FROM Mst_Dist                 
      WHERE DistID=isnull(@DistID,DistID)                   
                   
                
   SET NOCOUNT OFF;                  
  END TRY                  
  BEGIN CATCH                          
   --There was an error                          
    exec sp_error_handler                          
    IF @@TRANCOUNT>0                          
    ROLLBACK                           
    RETURN -101                          
                               
  END CATCH                                   
  RETURN 0                  
   END

GO
/****** Object:  StoredProcedure [dbo].[ASP_GetDistrictTehshilNameEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ASP_GetDistrictTehshilNameEdit]               
(                  
 @Tehsil INT = NULL             
             
)                  
AS                   
 BEGIN                  
  BEGIN TRY                  
   SET NOCOUNT ON;                 
               
                
     SELECT Tehsil,Tehsil_Name,Distid               
      FROM Tbl_Tehsil                 
      WHERE Tehsil=isnull(@Tehsil,Tehsil)                   
                   
                
   SET NOCOUNT OFF;                  
  END TRY                  
  BEGIN CATCH                          
   --There was an error                          
    exec sp_error_handler                          
    IF @@TRANCOUNT>0                          
    ROLLBACK                           
    RETURN -101                          
                               
  END CATCH                                   
  RETURN 0                  
   END

GO
/****** Object:  StoredProcedure [dbo].[ASP_GetNgoDetailsForEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ASP_GetNgoDetailsForEdit]               
(                  
 @NgoIDTemp INT = NULL,                  
 @StatusId INT = NULL             
             
)                  
AS                   
 BEGIN                  
  BEGIN TRY                  
   SET NOCOUNT ON;                 
   IF  @StatusId!=5 --StatusID = 6 for approved records.                
                   
 BEGIN                
SELECT [NgoIDTemp]
      ,[NgoID]
      ,[NgoName]
      ,[NgoAddress]
      ,[PhoneAreaCode]
      ,[PhoneNumber]
      ,[MobileNumber]
      ,[WorkDoneByNGO]
      ,[StateID]
      ,[Dist]
      ,[Remarks]
      ,[Attachment]
      ,[StatusID]
      ,[Submitby]
      ,[InsertDate]
      ,[UpdateDate]
      ,[IpAddress]
  FROM [dbo].[tbl_NgoTemp]
  WHERE NgoIDTemp=isnull(@NgoIDTemp,NgoIDTemp)                   
  and StatusID=@StatusId             
                 
 END                
              
                 
   ELSE                
                   
   BEGIN                
                     
 
SELECT [NgoID]
      ,[NgoName]
      ,[NgoAddress]
      ,[PhoneAreaCode]
      ,[PhoneNumber]
      ,[MobileNumber]
      ,[WorkDoneByNGO]
      ,[StateID]
      ,[Dist]
      ,[Remarks]
      ,[Attachment]
      ,[StatusID]
      ,[Submitby]
      ,[InsertDate]
      ,[UpdateDate]
      ,[IpAddress]
  FROM [dbo].[tbl_NgoFinal]
              
      WHERE NgoID=isnull(@NgoIDTemp,NgoID)                  
      and StatusID=@StatusId                
                      
   END                
                
   SET NOCOUNT OFF;                  
  END TRY                  
  BEGIN CATCH                          
   --There was an error                          
    exec sp_error_handler                          
    IF @@TRANCOUNT>0                          
    ROLLBACK                           
    RETURN -101                          
                               
  END CATCH                                   
  RETURN 0                  
   END
GO
/****** Object:  StoredProcedure [dbo].[ASP_GetPhotoCategoryEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_GetPhotoCategoryEdit]               

(                  

 @TempMCategoryId INT = NULL,                  

 @StatusId INT = NULL             

             

)                  

AS                   

 BEGIN                  

  BEGIN TRY                  

   SET NOCOUNT ON;                 

   IF  @StatusId!=5 --StatusID = 6 for approved records.                

                   

 BEGIN                

                

     SELECT [TempCategoryId],[CatName],CaNametHindi,[StatusId],                  

       [CategoryId],[UserId],[DateInserted],[DateLastUpdated],ModuleId,StateID, TigerReserveID                 

      FROM Category_Tmp                 

      WHERE TempCategoryId=isnull(@TempMCategoryId,TempCategoryId)                   

      and StatusId=@StatusId             

                 

 END                

              

                 

   ELSE                

                   

   BEGIN                

                     

    SELECT [CategoryId]AS [TempCategoryId],[CatName],CaNametHindi,[StatusId],                 

       [CategoryId],[UserId],[DateInserted],[DateLastUpdated],ModuleId ,StateID, TigerReserveID                 

      FROM Category                 

      WHERE CategoryId=isnull(@TempMCategoryId,CategoryId)                  

      and StatusId=@StatusId                

                      

   END                

                

   SET NOCOUNT OFF;                  

  END TRY                  

  BEGIN CATCH                          

   --There was an error                          

    exec sp_error_handler                          

    IF @@TRANCOUNT>0                          

    ROLLBACK                           

    RETURN -101                          

                               

  END CATCH                                   

  RETURN 0                  

   END






GO
/****** Object:  StoredProcedure [dbo].[ASP_GetTehshilGrampanchayatNameEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ASP_GetTehshilGrampanchayatNameEdit]               
(                  
 @GramPanchayatID INT = NULL             
             
)                  
AS                   
 BEGIN                  
  BEGIN TRY                  
   SET NOCOUNT ON;                 
               
                
     SELECT GramPanchayatID,GramPanchayatName,Tehsilid,[dbo].[GetDistrictName](Tehsilid ) as DistrictID           
      FROM Tbl_Grampanchayat                 
      WHERE GramPanchayatID=isnull(@GramPanchayatID,GramPanchayatID)                   
                   
                
   SET NOCOUNT OFF;                  
  END TRY                  
  BEGIN CATCH                          
   --There was an error                          
    exec sp_error_handler                          
    IF @@TRANCOUNT>0                          
    ROLLBACK                           
    RETURN -101                          
                               
  END CATCH                                   
  RETURN 0                  
   END

GO
/****** Object:  StoredProcedure [dbo].[ASP_InsertUpdateDelete_Category]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_InsertUpdateDelete_Category]          

(          

   @TempMCategoryId INT =NULL,          

   @UserID INT = NULL,        

   @IpAddress NVARCHAR(50) = NULL,     
   


   @recordCount INT OUTPUT          

)          

AS          

BEGIN                   

  BEGIN TRY                    

   BEGIN TRANSACTION -- Start the Transaction                    

   SET NOCOUNT ON;                    

                      

  DECLARE @Temp_Old_MCategoryId  int                 

        SET @Temp_Old_MCategoryId=(select CategoryId from Category_Tmp where TempCategoryId=@TempMCategoryId)                  

              

      IF @Temp_Old_MCategoryId IS NULL  --query to insert record from temp to final                 

   BEGIN               

   INSERT INTO Category          

        ([CatName],CaNametHindi,[StatusId],         

      [UserId],[DateInserted],IpAddress,ModuleId,StateID,TigerReserveID)          

             

      SELECT [CatName],CaNametHindi,5,          

        @UserID,DateInserted,@IpAddress,ModuleId,StateID,TigerReserveID     

      FROM Category_Tmp                                     

   WHERE TempCategoryId=@TempMCategoryId            

             

   DELETE FROM Category_Tmp                                    

   WHERE  TempCategoryId=@TempMCategoryId             

                  

   SET @recordCount=@@ROWCOUNT                 

   END           

             

       ELSE         --query to update record from temp to final           

  BEGIN              

               

   UPDATE [Category]          

       SET [Category].[CatName]         = [Category_Tmp].CatName,           

       [Category].CaNametHindi   = [Category_Tmp].CaNametHindi,           

       [Category].[StatusId]        = 5,           

       [Category].StateID =       [Category_Tmp].StateID,
	    
		[Category].TigerReserveID  = [Category_Tmp].TigerReserveID, 

       [Category].[UserId]          = @UserID  ,        

       [Category].[ModuleId]   = [Category_Tmp].ModuleId,        

        [Category].[IpAddress]   = @IpAddress,        

       [Category].[DateLastUpdated] = GETDATE()          

                 

     FROM [Category], [Category_Tmp]                       

     WHERE [Category].CategoryId=@Temp_Old_MCategoryId  AND [Category_Tmp].CategoryId =@Temp_Old_MCategoryId                  

                           

               

     DELETE from Category_Tmp   WHERE  TempCategoryId=@TempMCategoryId              

     SET @recordCount=@@ROWCOUNT             

      END          

                

             

  SET NOCOUNT OFF;          

  COMMIT --Commit the transaction                             

 END TRY                    

                     

 BEGIN CATCH                    

 --There was an error                    

  exec sp_error_handler                    

  IF @@TRANCOUNT>0                    

   ROLLBACK                     

  RETURN -101                    

                        

 END CATCH                    

                    

 RETURN 0                    

END






GO
/****** Object:  StoredProcedure [dbo].[ASP_InsertUpdateDelete_Gallery]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ASP_InsertUpdateDelete_Gallery]    

(    

    

   @TempGalleryId INT =NULL,        

   @UserID INT = NULL,     

   @IpAddress NVARCHAR(50) = NULL,     

   @recordCount INT OUTPUT     

           )    

AS    

 BEGIN             

  BEGIN TRY              

   BEGIN TRANSACTION -- Start the Transaction              

   SET NOCOUNT ON;              

                

      DECLARE @Temp_Old_GalleryId  int     

       SET @Temp_Old_GalleryId=(select GalleryId from PhotoGallery_tmp where TempGalleryId=@TempGalleryId)                

            

   IF @Temp_Old_GalleryId IS NULL  --query to insert record from temp to final               

              

        BEGIN     

     INSERT INTO PhotoGallery    

          ([CategoryId],[MediaTypeId],[Title],[TitleRegLng],[Description],    

          [DescriptionRegLng],[AltTag],[AltTagRegLng],[ImageName],[FileName],    

          [StatusId],[StartDate],[EndDate],[DateInserted],[UserId],IpAddress,StateID,TigerReserveid)    

     SELECT    

         [CategoryId],[MediaTypeId],[Title],[TitleRegLng],[Description],    

         [DescriptionRegLng],[AltTag],[AltTagRegLng],[ImageName],[FileName],    

         5,[StartDate],[EndDate],[DateInserted],[UserId],@IpAddress ,StateID,TigerReserveid   

     FROM PhotoGallery_tmp                                   

     WHERE TempGalleryId=@TempGalleryId         

             

        DELETE FROM PhotoGallery_tmp                               

     WHERE  TempGalleryId=@TempGalleryId    

         

     SET @recordCount=@@ROWCOUNT                

      END     

       

     ELSE    --Action to update new record         

     BEGIN     

         

    UPDATE PhotoGallery    

        SET [PhotoGallery].[CategoryId]   = [PhotoGallery_tmp].CategoryId,     

        [PhotoGallery].[MediaTypeId]    = [PhotoGallery_tmp].MediaTypeId,    

        [PhotoGallery].[Title]     = [PhotoGallery_tmp].Title,     

        [PhotoGallery].[TitleRegLng]    = [PhotoGallery_tmp].TitleRegLng,     

        [PhotoGallery].[Description]    = [PhotoGallery_tmp].[Description],    

        [PhotoGallery].[DescriptionRegLng] = [PhotoGallery_tmp].DescriptionRegLng,     

        [PhotoGallery].[AltTag]     =[PhotoGallery_tmp].AltTag,    

        [PhotoGallery].[AltTagRegLng]   = [PhotoGallery_tmp].AltTagRegLng,     

        [PhotoGallery].[ImageName]    = [PhotoGallery_tmp].ImageName,     

        [PhotoGallery].[FileName]    = [PhotoGallery_tmp].[FileName],     

        [PhotoGallery].[StatusId]    = 5,     

        [PhotoGallery].[StartDate]         = [PhotoGallery_tmp].StartDate,     

        [PhotoGallery].[EndDate]     = [PhotoGallery_tmp].EndDate,    

        [PhotoGallery].[IpAddress]   = @IpAddress,    

        [PhotoGallery].[DateLastUpdated]   = getdate(),    

        [PhotoGallery].[UserId]            = [PhotoGallery_tmp].UserId     

     FROM [PhotoGallery], [PhotoGallery_tmp]                     

     WHERE [PhotoGallery].GalleryId=@Temp_Old_GalleryId  AND [PhotoGallery_tmp].GalleryId =@Temp_Old_GalleryId               

                         

             

     DELETE from [PhotoGallery_tmp]   WHERE  TempGalleryId=@TempGalleryId            

     SET @recordCount=@@ROWCOUNT       

      END    

          

     --ELSE IF  @ActionType=3  --Action to delete the record    

     -- BEGIN     

     --  DELETE FROM [PhotoGallery]    

     --              WHERE GalleryId=@GalleryId    

     --  SET @recordCount=@@ROWCOUNT     

     -- END    

  SET NOCOUNT OFF;    

  COMMIT --Commit the transaction                       

 END TRY              

               

 BEGIN CATCH              

 --There was an error              

  exec sp_error_handler              

  IF @@TRANCOUNT>0              

   ROLLBACK               

  RETURN -101              

                  

 END CATCH              

              

 RETURN 0              

END






GO
/****** Object:  StoredProcedure [dbo].[ASP_InsertUpdateDelete_Gallery_Tmp]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_InsertUpdateDelete_Gallery_Tmp]        

(        

        

           @ActionType         INT             =NULL,        

           @CategoryId        INT             =NULL,        

           @TempGalleryId      INT             =NULL,        

           @GalleryId          INT             =NULL,        

           @MediaTypeId        INT             =NULL,   
		   
		   @StateID			   INT			= NULL,
		   
		   @TigerReserveID		int =null,     

           @Title              NVARCHAR(200)   =NULL,        

           @TitleRegLng        NVARCHAR(200)   =NULL,        

           @Description        NVARCHAR(MAX)   =NULL,        

           @DescriptionRegLng  NVARCHAR(MAX)   =NULL,        

           @AltTag             NVARCHAR(200)   =NULL,        

           @AltTagRegLng       NVARCHAR(200)   =NULL,        

           @ImageName          NVARCHAR(MAX)   =NULL,        

           @FileName           NVARCHAR(MAX)   =NULL,        

           @StatusId           INT             =NULL,        

           @StartDate          DATETIME        =NULL,        

           @EndDate            DATETIME        =NULL,        

           @DateInserted       DATETIME        =NULL,        

           @DateLastUpdated    DATETIME        =NULL,        

           @UserId              INT            =NULL,        

           @IpAddress     NVARCHAR(50)    =NULL,       

           @recordCount INT OUTPUT        

           )        

AS        

BEGIN                 

  BEGIN TRY                  

   BEGIN TRANSACTION -- Start the Transaction                  

   SET NOCOUNT ON;                  

                    

     IF @ActionType=1    --Action to insert new record into temp          

        BEGIN         

    INSERT INTO [PhotoGallery_tmp]        

         ([CategoryId],[MediaTypeId] ,[Title] ,[TitleRegLng],[Description],        

       [DescriptionRegLng],[AltTag],[AltTagRegLng],[ImageName],[FileName],        

       [StatusId],[GalleryId],[StartDate],[EndDate],[DateInserted],[UserId],IpAddress,StateID,TigerReserveID)        

    VALUES        

       (@CategoryId,@MediaTypeId,@Title,@TitleRegLng,@Description,         

        @DescriptionRegLng,@AltTag, @AltTagRegLng,@ImageName, @FileName,         

        @StatusId, @GalleryId, @StartDate,@EndDate,GETDATE(),@UserId,@IpAddress, @StateID, @TigerReserveID)        

                          SET @recordCount=@@ROWCOUNT                    

      END         

           

     ELSE IF @ActionType=2     --Action to update new record into temp           

     BEGIN         

             

     IF @StatusId!=5         

    BEGIN         

            

    UPDATE [PhotoGallery_tmp]        

        SET [CategoryId]       = @CategoryId,         

         [MediaTypeId]       = @MediaTypeId,         

         [Title]      = @Title,         

         [TitleRegLng]    = @TitleRegLng,        

         [Description]    = @Description,         

         [DescriptionRegLng] = @DescriptionRegLng,         

         [AltTag]      = @AltTag,         

         [AltTagRegLng]      = @AltTagRegLng,        

         [ImageName]     = @ImageName,         

         [FileName]     = @FileName,         

         [StatusId]     = @StatusId,         

         [GalleryId]         = @GalleryId,         

         [StartDate]         = @StartDate,         

         [EndDate]           = @EndDate,     
		 
		 [StateID]= @StateID,
		 [TigerReserveID]=@TigerReserveID,    

         [DateLastUpdated]   = GETDATE(),       

         [IpAddress]   = @IpAddress,       

         [UserId]      = @UserId         

      WHERE TempGalleryId    =@TempGalleryId        

              

    SET @recordCount=@@ROWCOUNT           

            

    END          

            

            

     ELSE         

             

             

     BEGIN         

             

     INSERT INTO [PhotoGallery_tmp]        

         ([CategoryId],[MediaTypeId] ,[Title] ,[TitleRegLng],[Description],        

       [DescriptionRegLng],[AltTag],[AltTagRegLng],[ImageName],[FileName],        

       [StatusId],[GalleryId],[StartDate],[EndDate],[DateInserted],[UserId],[IpAddress],StateID,TigerReserveID)        

    VALUES        

       (@CategoryId,@MediaTypeId,@Title,@TitleRegLng,@Description,         

        @DescriptionRegLng,@AltTag, @AltTagRegLng,@ImageName, @FileName,         

        3, @GalleryId, @StartDate,@EndDate,GETDATE(),@UserId,@IpAddress,@StateID,@TigerReserveID)        

                

    SET @recordCount=@@ROWCOUNT                              

     END          

             

      END        

              

     ELSE IF  @ActionType=3  --Action to delete the record        

      BEGIN         

      DECLARE @tempID INT      

            

         IF @StatusId!=6        

   BEGIN      

         

   DELETE FROM [PhotoGallery_tmp]        

    WHERE TempGalleryId=@TempGalleryId        

    SET @recordCount=@@ROWCOUNT         

         

   END        

         

    ELSE      

           

     BEGIN      

           

     SET @tempID=( SELECT TempGalleryId FROM [PhotoGallery_tmp] WHERE GalleryId=@TempGalleryId)      

     IF @tempID IS NOT NULL      

           

     BEGIN      

           

      DELETE FROM [PhotoGallery_tmp]      

   WHERE TempGalleryId=@tempID      

           

  UPDATE Gallery      

  SET  StatusId=8, IpAddress=@IpAddress      

  WHERE GalleryId=@TempGalleryId      

        

  SET @recordCount=@@ROWCOUNT      

           

     END      

           

     ELSE      

           

     BEGIN      

           

     UPDATE PhotoGallery      

  SET  StatusId=8, IpAddress=@IpAddress      

  WHERE GalleryId=@TempGalleryId      

  SET @recordCount=@@ROWCOUNT      

           

     END      

          

      END       

            

          

           

     END        

  SET NOCOUNT OFF;        

  COMMIT --Commit the transaction                           

 END TRY                  

                   

 BEGIN CATCH                  

 --There was an error                  

  exec sp_error_handler                  

  IF @@TRANCOUNT>0               

   ROLLBACK                   

  RETURN -101                  

                      

 END CATCH                  

                  

 RETURN 0                  

END






GO
/****** Object:  StoredProcedure [dbo].[ASP_InsertUpdateDeleteCategoryTmp]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_InsertUpdateDeleteCategoryTmp]                      



(                      



           @ActionType INT             =NULL,                      



           @TempMCategoryId INT        =NULL,                      



           @MCategoryId INT            =NULL, 

		   

		   @StateID INT            =NULL,  

		   

		   @TigerReserveID INT            =NULL,                     



           @CatName NVARCHAR(100)      =NULL,                      



           @CatNameRegLng NVARCHAR(100)=NULL,                      



           @StatusId INT               =NULL,                      



           @UserId INT                 =NULL,                      



           @DateInserted DATETIME      =NULL,                      



           @DateLastUpdated DATETIME   =NULL,                     



           @ModuleId      INT     =NULL,                   



           @IpAddress NVARCHAR(50)   =NULL,        



           @recordCount INT OUTPUT                      



)                      



AS                      



BEGIN                               



  BEGIN TRY                                



   BEGIN TRANSACTION -- Start the Transaction                                



   SET NOCOUNT ON;                                



                                  



 IF @ActionType=1    --Action to insert new record                        



      BEGIN                       



   INSERT INTO [dbo].[Category_Tmp]                      



        ([CatName],[CaNametHindi],[StatusId], [UserId],[DateInserted],ModuleId,IpAddress,StateID, TigerReserveID)                      



     VALUES                      



        (@CatName,@CatNameRegLng,@StatusId,@UserId,GETDATE(),@ModuleId,@IpAddress,@StateID,@TigerReserveID)                      



                      



                      



   SET @recordCount=@@ROWCOUNT                                  



   END                       



                         



      ELSE IF @ActionType=2     --Action to update new record                           



     BEGIN                     



     IF @StatusId !=5               



                     



     BEGIN                



      UPDATE [Category_Tmp]                      



      SET [CatName]          = @CatName,                       



      [CaNametHindi]    = @CatNameRegLng,                       



      [StatusId]         = @StatusId,                       



       StateID =        @StateID,

	   

	  TigerReserveID=   @TigerReserveID,         



      

      [UserId]           = @UserId,                  



      [ModuleId]   = @ModuleId ,                 



      [DateLastUpdated]   = GETDATE() ,                 



      [IpAddress]   = @IpAddress                    



    WHERE TempCategoryId=@TempMCategoryId                      



                      



    SET @recordCount=@TempMCategoryId                         



                     



     END                



                       



    ELSE                



                    



    BEGIN                



                    



     INSERT INTO [dbo].[MediaCategory_Tmp]                      



        ([CatName],[CatNameRegLng],[StatusId],[UserId],[DateInserted],ModuleId,IpAddress,StateID, TigerReserveID)                      



     VALUES                      



        (@CatName,@CatNameRegLng,3,@UserId,GETDATE(),@ModuleId,@IpAddress,@StateID,@TigerReserveID)                      



    SET @recordCount=@@ROWCOUNT                  



    END                



                     



     END                       



     ELSE IF  @ActionType=3  --Action to delete the record                      



      BEGIN                      



                      



       DECLARE @tempID INT                



      



         IF @StatusId!=5                



   BEGIN                



    DELETE FROM [MediaCategory_Tmp]                  



    WHERE TempMCategoryId=@TempMCategoryId                  



    SET @recordCount=@@ROWCOUNT                   



   END                



                   



   ELSE                



                   



   BEGIN                



    SET @tempID=( SELECT TempMCategoryId FROM [MediaCategory_Tmp] WHERE MCategoryId=@TempMCategoryId)                



    IF @tempID IS NOT NULL                



    begin                



                     



                    



     DELETE FROM [Gallery_Tmp]                  



     WHERE MCategoryId=@TempMCategoryId                 



                     



 UPDATE gallery SET statusid=8, IpAddress=@IpAddress                



     WHERE MCategoryId=@TempMCategoryId                 



                     



     UPDATE  [MediaCategory]                 



     SET statusid=8 ,IpAddress=@IpAddress              



     WHERE MCategoryId=@TempMCategoryId                  



                      



     SET @recordCount=@@ROWCOUNT                  



                    



    end                



                    



    else                



                    



    begin                



     UPDATE gallery SET statusid=8 , IpAddress=@IpAddress                



     WHERE MCategoryId=@TempMCategoryId                 



                     



     UPDATE  [MediaCategory]                 



     SET statusid=8                 



     WHERE MCategoryId=@TempMCategoryId                  



                      



     SET @recordCount=@@ROWCOUNT                  



    end                



                    



   END                 



                        



      END                      



 SET NOCOUNT OFF;                      



  COMMIT --Commit the transaction                                         



 END TRY                                



                                 



 BEGIN CATCH                                



 --There was an error                                



  exec sp_error_handler                                



  IF @@TRANCOUNT>0                                



   ROLLBACK                                 



  RETURN -101                                



                                    



 END CATCH                                



                                



 RETURN 0                                



END










GO
/****** Object:  StoredProcedure [dbo].[asp_InsertUpdateDistrict]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[asp_InsertUpdateDistrict]                    
(                    
 @ActionType tinyint,  
 @DistID int=null,               
 @DistName varchar(100)=null,             
 @StateID int=null,
 @IpAddress varchar(50)=null,
 @InsertDate datetime=null,
 @InsertedBy int ,               
 @recordCount int output                   
)                              
as                    
BEGIN                   
                    
 BEGIN TRY                    
  BEGIN TRANSACTION -- Start the Transaction                    
  SET NOCOUNT ON;                    
                      
   if @ActionType=1                     
   BEGIN                    
    INSERT INTO Mst_Dist (DistName,StateID,IpAddress,InsertedBy,InsertDate)                    
    VALUES                    
       (@DistName,@StateID,@IpAddress,@InsertedBy,getdate())                  
                         
    set @recordCount=@@ROWCOUNT                      
   END                    
   else if @ActionType=2                     
   BEGIN            
                              
    UPDATE Mst_Dist                   
    SET                     
      DistName = @DistName,                              
	  StateID=@StateID,
	  IpAddress=@IpAddress                 
    WHERE DistID  =@DistID                   
    set @recordCount=@DistID                     
   END                          
  COMMIT --Commit the transaction                    
  SET NOCOUNT OFF;                  
END TRY                    
                     
BEGIN CATCH                    
 --There was an error                    
 exec sp_error_handler              
 IF @@TRANCOUNT>0                    
  ROLLBACK                     
 RETURN -101                    
                      
END CATCH                    
       
RETURN 0                    
                    
END

GO
/****** Object:  StoredProcedure [dbo].[asp_InsertUpdateDistrictTehshil]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[asp_InsertUpdateDistrictTehshil]                    
(                    
 @ActionType tinyint,  
 @Tehsil int=null,               
 @Tehsil_Name varchar(100)=null,             
 @Distid int=null,
 @IpAddress varchar(50)=null,
 @DateofInsert datetime=null,
 @SubmitBy int ,               
 @recordCount int output                   
)                              
as                    
BEGIN                   
                    
 BEGIN TRY                    
  BEGIN TRANSACTION -- Start the Transaction                    
  SET NOCOUNT ON;                    
                      
   if @ActionType=1                     
   BEGIN                    
    INSERT INTO Tbl_Tehsil (Tehsil_Name,Distid,IpAddress,SubmitBy,DateofInsert)                    
    VALUES                    
       (@Tehsil_Name,@Distid,@IpAddress,@SubmitBy,getdate())                  
                         
    set @recordCount=@@ROWCOUNT                      
   END                    
   else if @ActionType=2                     
   BEGIN            
                              
    UPDATE Tbl_Tehsil                   
    SET                     
      Tehsil_Name = @Tehsil_Name,                              
	  Distid=@Distid,
	  IpAddress=@IpAddress                 
    WHERE Tehsil  =@Tehsil                   
    set @recordCount=@Tehsil                     
   END                          
  COMMIT --Commit the transaction                    
  SET NOCOUNT OFF;                  
END TRY                    
                     
BEGIN CATCH                    
 --There was an error                    
 exec sp_error_handler              
 IF @@TRANCOUNT>0                    
  ROLLBACK                     
 RETURN -101                    
                      
END CATCH                    
       
RETURN 0                    
                    
END

GO
/****** Object:  StoredProcedure [dbo].[asp_InsertUpdateNGODetails]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[asp_InsertUpdateNGODetails]                    
(                    
 @ActionType tinyint,                 
 @NgoIDTemp int =null,                 
 @Module_Id int     =null,                               
 @NgoName nvarchar(100)    =null,                                    
 @NgoAddress nvarchar(200)    =null,                    
 @StateID int=null,
 @PhoneNumber nchar(10)=null,   
 @MobileNumber nchar(10)=null,                      
 @Attachment nvarchar(200)  =null,                                        
 @StatusID int     =null,                    
 @Submitby int = null,          
 @InsertDate datetime  =null,                    
 @UpdateDate datetime  =null,
 @WorkDoneByNGO nvarchar(max)=null,
 @Remarks nvarchar(max)=null,  
 @IpAddress varchar(50)=null,                    
 @recordCount int output                   
)                              
as                    
BEGIN                   
                    
 BEGIN TRY                    
  BEGIN TRANSACTION -- Start the Transaction                    
  SET NOCOUNT ON;                    
                      
   if @ActionType=1                     
   BEGIN                    
  
INSERT INTO [dbo].[tbl_NgoTemp]
           ([NgoName],[NgoAddress],[PhoneNumber],[MobileNumber]
           ,[WorkDoneByNGO],[StateID],[Remarks],[Attachment],[StatusID]
           ,[Submitby] ,[InsertDate],IpAddress)
     VALUES
           (@NgoName, @NgoAddress,@PhoneNumber,@MobileNumber,@WorkDoneByNGO,
            @StateID,@Remarks,@Attachment,@StatusID,@Submitby,GETDATE(),@IpAddress)
                 
                         
    set @recordCount=@@ROWCOUNT                      
   END                    
   else if @ActionType=2                     
   BEGIN            
   if   @StatusID!=5                   
  Begin                             
UPDATE [dbo].[tbl_NgoTemp]
   SET [NgoName] = @NgoName
      ,[NgoAddress] = @NgoAddress
      ,[PhoneNumber] = @PhoneNumber
      ,[MobileNumber] = @MobileNumber
      ,[WorkDoneByNGO] = @WorkDoneByNGO
      ,[StateID] = @StateID
      ,[Remarks] = @Remarks
      ,[Attachment] = @Attachment
      ,[StatusID] = @StatusID
      ,[Submitby] = @Submitby
      ,[IpAddress]=@IpAddress
      ,[UpdateDate] = GETDATE()
 WHERE NgoIDTemp=@NgoIDTemp
         
    set @recordCount=@@ROWCOUNT                     
   END           
    else                    
  begin                        
INSERT INTO [dbo].[tbl_NgoTemp]
           ([NgoName],[NgoAddress],[PhoneNumber],[MobileNumber]
           ,[WorkDoneByNGO],[StateID],[Remarks],[Attachment],[StatusID]
           ,[Submitby] ,[InsertDate],IpAddress,NgoID)
     VALUES
           (@NgoName, @NgoAddress,@PhoneNumber,@MobileNumber,@WorkDoneByNGO,
            @StateID,@Remarks,@Attachment,3,@Submitby,GETDATE(),@IpAddress,@NgoIDTemp)                 
     end               
    set @recordCount=@@ROWCOUNT                      
   END                          
  COMMIT --Commit the transaction                    
  SET NOCOUNT OFF;                  
END TRY                    
                     
BEGIN CATCH                    
 --There was an error                    
 exec sp_error_handler              
 IF @@TRANCOUNT>0                    
  ROLLBACK                     
 RETURN -101                    
                      
END CATCH                    
       
RETURN 0                    
                    
END
GO
/****** Object:  StoredProcedure [dbo].[asp_InsertUpdateTehshilGrampanchayat]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[asp_InsertUpdateTehshilGrampanchayat]                    
(                    
 @ActionType tinyint,  
 @GramPanchayatID int=null,               
 @GramPanchayatName varchar(100)=null,             
 @Tehsilid int=null,
 @IpAddress varchar(50)=null,
 @DateofInsert datetime=null,
 @SubmitBy int ,               
 @recordCount int output                   
)                              
as                    
BEGIN                   
                    
 BEGIN TRY                    
  BEGIN TRANSACTION -- Start the Transaction                    
  SET NOCOUNT ON;                    
                      
   if @ActionType=1                     
   BEGIN                    
    INSERT INTO Tbl_Grampanchayat (GramPanchayatName,Tehsilid,IpAddress,SubmitBy,DateofInsert)                    
    VALUES                    
       (@GramPanchayatName,@Tehsilid,@IpAddress,@SubmitBy,getdate())                  
                         
    set @recordCount=@@ROWCOUNT                      
   END                    
   else if @ActionType=2                     
   BEGIN            
                              
    UPDATE Tbl_Grampanchayat                   
    SET                     
      GramPanchayatName = @GramPanchayatName,                              
	  Tehsilid=@Tehsilid,
	  IpAddress=@IpAddress                 
    WHERE GramPanchayatID  =@GramPanchayatID                   
    set @recordCount=@GramPanchayatID                     
   END                          
  COMMIT --Commit the transaction                    
  SET NOCOUNT OFF;                  
END TRY                    
                     
BEGIN CATCH                    
 --There was an error                    
 exec sp_error_handler              
 IF @@TRANCOUNT>0                    
  ROLLBACK                     
 RETURN -101                    
                      
END CATCH                    
       
RETURN 0                    
                    
END

GO
/****** Object:  StoredProcedure [dbo].[ASP_Links_Web_Get_Menu_Parent_ID]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_Links_Web_Get_Menu_Parent_ID]    

(            

 @link_parent_id int            

)            

AS                

BEGIN                 

SET NOCOUNT ON;                

 BEGIN TRY                

                

 SELECT Link_Id,Link_Level,Link_Order,name,Meta_Keywords,Mate_Description,Page_Title      

 FROM Web_Link WHERE link_parent_id =@link_parent_id        

 order by Link_Id         

                

 END TRY                

                

 BEGIN CATCH                

                 

  EXEC sp_error_handler                    

  IF @@TRANCOUNT>0                    

     ROLLBACK                     

     RETURN -101                   

                

 END CATCH                

 RETURN 0                

 SET NOCOUNT OFF;                 

END


GO
/****** Object:  StoredProcedure [dbo].[ASP_NGO_Id]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ASP_NGO_Id]                
(              
 @NgoID INT=NULL              
)                  
AS                    
 BEGIN                     
  SET NOCOUNT ON;                    
    BEGIN TRY                    
                       
     BEGIN TRAN                    
                         
      SELECT NgoID FROM tbl_NgoTemp               
      where NgoID  in (SELECT NgoID FROM tbl_NgoFinal WHERE NgoID=@NgoID)                     
                       
     COMMIT TRAN                    
                       
    END TRY                    
                      
    BEGIN CATCH                    
                        
     EXEC sp_error_handler                        
     IF @@TRANCOUNT>0                        
     ROLLBACK                         
     RETURN -101                       
                       
    END CATCH                    
   RETURN 0                    
  SET NOCOUNT OFF;                     
END

GO
/****** Object:  StoredProcedure [dbo].[ASP_PhotoGallery_Id]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_PhotoGallery_Id]                

(              

 @GalleryId INT=NULL              

)                  

AS                    

 BEGIN                     

  SET NOCOUNT ON;                    

    BEGIN TRY                    

                       

     BEGIN TRAN                    

                         

      SELECT GalleryId FROM PhotoGallery_tmp               

      where GalleryId  in (SELECT GalleryId FROM PhotoGallery WHERE GalleryId=@GalleryId)                     

                       

     COMMIT TRAN                    

                       

    END TRY                    

                      

    BEGIN CATCH                    

                        

     EXEC sp_error_handler                        

     IF @@TRANCOUNT>0                        

     ROLLBACK                         

     RETURN -101                       

                       

    END CATCH                    

   RETURN 0                    

  SET NOCOUNT OFF;                     

END






GO
/****** Object:  StoredProcedure [dbo].[Asp_Update_Family_Detials]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Asp_Update_Family_Detials]
(
@familyid int,
@Stateid int,
@TigerReserveid int,
@VillageID int,
@Head_Name nvarchar(200),
@Agriculature_land decimal(18,2),
@Residential_Property decimal(18,2),
@Total_Livestock int,
@Other_assest varchar(max),
@Longitude varchar(20),
@Latitude varchar(20),
@SanctionLeter varchar(100),
@Submitedby int = null,
@IPAddress nvarchar(20),
@UpdatedBy int =null,
@FamilyMember TypeFamilyMember ReadOnly,
@FamilyAnimal TypeFamilyAnimal Readonly
)
as
Begin

 Update Tbl_Family set Stateid=@Stateid,TigerReserveid=@TigerReserveid,VillageID=@VillageID,Head_Name=@Head_Name,Agriculature_land=@Agriculature_land,
                       Residential_Property=@Residential_Property,Total_Livestock=@Total_Livestock,Other_assest=@Other_assest,
					   Longitude=@Longitude,Latitude=@Latitude,SanctionLeter=@SanctionLeter,UpdatedBy=@Submitedby,LastUpdatedDate=GETDATE()
					   Where familyid=@familyid



  
  

  Delete from Tbl_family_animal where Familyid=@familyid
  Insert into Tbl_family_animal(Familyid,AnimalType,NOofAnimal)
               Select @familyid,AnimalType,NOofAnimal from @FamilyAnimal  

			   Delete from Tbl_family_Member where familyid=@familyid
Insert into Tbl_family_Member(familyid,MemberName,Age,Year_Month,Gender,Relation,AadharCardNo,AadharCardFile)
Select @familyid,MemberName,Age,Year_Month,Gender,Relation,AadharCardNo,AadharCardFile from @FamilyMember
 

End

GO
/****** Object:  StoredProcedure [dbo].[Asp_userLogin]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[Asp_userLogin] 
(
@UserName nvarchar(50)
)
As
Begin
   Select * from Mst_Users where [UserName]=@UserName and [Status]='True'
End


GO
/****** Object:  StoredProcedure [dbo].[ASP_Village_Id]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASP_Village_Id]                
(              
 @VillageId  INT=NULL              
)                  
AS                    
 BEGIN                     
  SET NOCOUNT ON;                    
    BEGIN TRY                    
                       
     BEGIN TRAN                    
                         
      SELECT Villageid FROM Tbl_village               
      where Villageid  in (SELECT Villageid FROM Tbl_village WHERE Villageid=@VillageId)                     
                       
     COMMIT TRAN                    
                       
    END TRY                    
                      
    BEGIN CATCH                    
                        
     EXEC sp_error_handler                        
     IF @@TRANCOUNT>0                        
     ROLLBACK                         
     RETURN -101                       
                       
    END CATCH                    
   RETURN 0                    
  SET NOCOUNT OFF;                     
END

GO
/****** Object:  StoredProcedure [dbo].[Get_Animal]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Get_Animal]
As
Begin
  
  select 
  AnimalID,Animal from Mst_Animal

End

GO
/****** Object:  StoredProcedure [dbo].[Get_Animal_By_Village_ForEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Get_Animal_By_Village_ForEdit]

(

@Villageid int,

@Status int

)

As

Begin

   if (@Status=3)

     Begin
	
	 select id,Animalid,TotalAnimal from Tbl_Village_Animals where villageid=@Villageid

	 End

   Else

     Begin

	  select id,Animalid,TotalAnimal from Tbl_village_animal_Final where villageid=@Villageid



	 

	 End

End

GO
/****** Object:  StoredProcedure [dbo].[Get_City_ByDist]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Get_City_ByDist]
(
@Distid int
)
AS
Begin
Select CityID,CityName,Distid from Mst_City where Distid=@Distid
End

GO
/****** Object:  StoredProcedure [dbo].[Get_Dist_ByState]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Get_Dist_ByState]
(
@Stateid int
)
AS
Begin
Select DistID,DistName,StateID from Mst_Dist where StateID=@Stateid
End


GO
/****** Object:  StoredProcedure [dbo].[Get_DistrictListByUser]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Get_DistrictListByUser]

(

@userid int

)

As

Begin

   Declare @PermissionState int

   select @PermissionState= PermissionState from Mst_Users where UserID=@userid

  select * from Mst_Dist s where s.StateID= case when @PermissionState is null Then s.StateID

                                                           Else @PermissionState End

	 					   

End
GO
/****** Object:  StoredProcedure [dbo].[get_FamilyList]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[get_FamilyList]
(
@stateid int,
@Tigerreserveid int,
@Villageid int,
@PageNumber int,
@PageSize int
)
As
Begin
DECLARE @OffsetCount INT
SET @OffsetCount = (@PageNumber-1)*@PageSize
Select tf.familyid, tf.Head_Name,tf.Agriculature_land,tf.Residential_Property,
tf.Total_Livestock,tf.Longitude,tf.Latitude ,COUNT(*) OVER() TotalRecord
      from Tbl_Family tf Where (tf.[Stateid]=@stateid or @stateid is null) 
                                   and (tf.TigerReserveid=@Tigerreserveid or @Tigerreserveid is null)
     and (tf.VillageID=@Villageid or @Villageid is null)
          ORDER BY tf.Head_Name
			  OFFSET @OffsetCount ROWS
			  FETCH NEXT @PageSize ROWS ONLY
End

GO
/****** Object:  StoredProcedure [dbo].[Get_FamilyMemeberList]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[Get_FamilyMemeberList]
(
@familyid int
)
As
Begin
select ROW_NUMBER() OVER (ORDER by MemberID) as RowNumber, MemberID,familyid,MemberName,Age,Year_Month,Gender,Relation,AadharCardNo,AadharCardFile from Tbl_family_Member where familyid=@familyid
End

GO
/****** Object:  StoredProcedure [dbo].[Get_StateListByUser]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Get_StateListByUser]
(
@userid int
)
As
Begin
   
    declare @userType int
	  set @userType =(select UserType from Mst_Users where UserID=@Userid)
	   if(@userType=1)
	  begin
	   select * from state_list
	  end

	  else

	  begin
	     Declare @PermissionState int
   select @PermissionState=PermissionState from Mst_Users where UserID=@userid
  select * from state_list s where s.id= case when @PermissionState is null Then s.id
                                                           Else @PermissionState End
	  end

								   
End

GO
/****** Object:  StoredProcedure [dbo].[Get_TigerReservationDetials]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Get_TigerReservationDetials]
(
@TigerReserveid int
)
As
Begin

select [TigerReserveid]
      ,[TigerReserveName]
      ,[TigerReserveNameHindi]
      ,[NoofVillages]
      ,[StateID]
      ,[Dist]
      ,[City]
      ,[TigerReserveMap]
      ,[CreationDate]
      ,[ModificationDate]
      ,[CreatedBy]
      ,[Status]
      ,[CoreArea]
      ,[BufferArea]
      ,[longitude]
      ,[latitude] from Tbl_TigerReserve where TigerReserveid=@TigerReserveid
      
End

GO
/****** Object:  StoredProcedure [dbo].[Get_TigerReservationList]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Get_TigerReservationList]
(
@Stateid int = null,
@Status int
)
As
Begin

select [TigerReserveid]
      ,[TigerReserveName]
      ,[TigerReserveNameHindi]
      ,[NoofVillages]
      ,[StateID]
      ,[Dist]
      ,[City]
      ,[TigerReserveMap]
      ,[CreationDate]
      ,[ModificationDate]
      ,[CreatedBy]
      ,[Status]
      ,[CoreArea]
      ,[BufferArea]
      ,[longitude]
      ,[latitude] 
	  from Tbl_TigerReserve 
	  where (StateID=@Stateid or @Stateid is null ) and Status=@Status 
	  order by CreationDate desc
End


GO
/****** Object:  StoredProcedure [dbo].[Get_TigerReserve]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Get_TigerReserve]
(
@Stateid int 
)
AS
Begin
select TigerReserveid,TigerReserveName,NoofVillages,[State],[Dist],[City],TigerReserveMap from Tbl_TigerReserve Where [State]=@Stateid and [Status]=3
End



GO
/****** Object:  StoredProcedure [dbo].[Get_TigerReserve_state_Permission]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Get_TigerReserve_state_Permission]
(
@Stateid int,
@Userid int,
@UserType int
)
As
Begin
    if  (@UserType=1 or @UserType=2 )
	   Begin
	      Select TigerReserveid,TigerReserveName from Tbl_TigerReserve where StateID=@Stateid and [Status]=1
	   End
    else
	  Begin
	  
	  select t.TigerReserveid,t.TigerReserveName from Tbl_TigerReserve t inner join UserPermission up
		                        on t.TigerReserveid=up.TigerReserveid
								where up.Userid= @Userid 
	  End

End



GO
/****** Object:  StoredProcedure [dbo].[Get_UserDetials]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Get_UserDetials]
(
@UserID int 
)
as
Begin
Select UserID,UserName,FirstName,LastName,UserType,EmailID,Address1,Address2,PermissionState,pincode,Landline,AreaCode,Mobile,[Status] 

from Mst_Users Where UserID=@UserID
End



GO
/****** Object:  StoredProcedure [dbo].[Get_UserList]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Get_UserList] 
(
@State int = null
)
as
Begin
Select UserID,UserName,FirstName,LastName,UserType,EmailID,Address1,Address2,PermissionState,pincode,Landline,AreaCode,Mobile,[Status] 

from Mst_Users  where (PermissionState=@State or @State is null)
order by UserID desc
End



GO
/****** Object:  StoredProcedure [dbo].[Get_VillageList]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Get_VillageList]
(
  @StateID int=null,
  @TigerReserveID int=null,
  @Status int=null,
  @PageNumber INT,
  @PageSize INT
)

AS
DECLARE @OffsetCount INT
SET @OffsetCount = (@PageNumber-1)*@PageSize
	BEGIN
	IF (@Status =3)
		BEGIN
			SELECT [TempVillageid],[Village_Name],[Relocated_from],[Relocated_place]
				  ,[Current_location_Latitude],[Current_location_Longitude]
				  ,[location_Latitude_From],[location_Longitude_From],SL.StateName,COUNT(*) OVER() TotalRecord,Tv.[Status]
     
			  FROM [dbo].[Tbl_village] TV
			  INNER JOIN Tbl_TigerReserve TR ON TV.TigerReserveID=TR.TigerReserveid
			  INNER JOIN state_list SL ON TR.StateID=SL.id
			  WHERE TV.TigerReserveID=@TigerReserveID AND TV.Status=@Status
			  ORDER BY Village_Name
			  OFFSET @OffsetCount ROWS
			  FETCH NEXT @PageSize ROWS ONLY

		END

	 ELSE
		BEGIN

			 SELECT Villageid AS [TempVillageid],[Village_Name],[Relocated_from],[Relocated_place]
			,[Current_location_Latitude],[Current_location_Longitude]
			,[location_Latitude_From],[location_Longitude_From],SL.StateName,COUNT(*) OVER() TotalRecord,TV.[Status]
     
			  FROM [dbo].[Tbl_Village_final] TV
			  INNER JOIN Tbl_TigerReserve TR ON TV.TigerReserveID=TR.TigerReserveid
			  INNER JOIN state_list SL ON TR.StateID=SL.id
			  WHERE TV.TigerReserveID=@TigerReserveID AND TV.Status=@Status
			  ORDER BY Village_Name
			  OFFSET @OffsetCount ROWS
			  FETCH NEXT @PageSize ROWS ONLY

		END
	END

GO
/****** Object:  StoredProcedure [dbo].[GetTigerReserverByState]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetTigerReserverByState]

(

@flag int,

@Userid int

)

AS

Begin

    if(@flag = 1)

	   Begin

	     Declare @Stateid int

		 select @Stateid=PermissionState from Mst_Users Where UserId=@Userid		

	     select TigerReserveid,TigerReserveName from Tbl_TigerReserve where StateID=@Stateid

	   End



	 else if(@flag=2)

	  Begin
	  declare @userType int
	  set @userType =(select UserType from Mst_Users where UserID=@Userid)

	  if(@userType=1)
	  begin
	  select t.TigerReserveid,t.TigerReserveName from Tbl_TigerReserve t
	  end

	  else

	  begin
	  select t.TigerReserveid,t.TigerReserveName from Tbl_TigerReserve t inner join UserPermission up

		                        on t.TigerReserveid=up.TigerReserveid

								where up.Userid= @Userid 
	  end
	     

	  End

End

GO
/****** Object:  StoredProcedure [dbo].[GetVillageByTigerReserverID]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[GetVillageByTigerReserverID]
(
@TigerReserveId int
)
As
Begin
select * from Tbl_Village_final where TigerReserveID=@TigerReserveId and [Status]=5
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_VillageDetails]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Insert_VillageDetails]
(
@Villageid int = null
,@TigerReserveID int = null
,@Village_Name nvarchar(100)=null 
,@Agriculture_Land decimal(18, 2)
,@Population varchar(50) = null
,@Residential_property decimal(18,2) = null
,@Total_Standing_Trees int = null
,@Total_Livestock int = null
,@Relocated_from nvarchar(50) = null
,@Relocated_place nvarchar(50) = null
,@Total_well int = null
,@Other_Assets varchar(max) = null
,@Current_location_Latitude varchar(50) = null
,@Current_location_Longitude varchar(50) = null
,@location_Latitude_From varchar(50) = null
,@location_Longitude_From varchar(50) = null
,@Submitedby int = null
,@LastUpdatedby int = null
,@stateid int = null
,@Animal_Details AnimalType READONLY 
)
AS
Begin
  Declare @id int

  Begin
    INSERT INTO [dbo].[Tbl_village]([Villageid],[TigerReserveID],[Village_Name],[Agriculture_Land],[Population],[Residential_property]
   ,[Total_Standing_Trees],[Total_Livestock],[Relocated_from],[Relocated_place],[Total_well],[Other_Assets],[Current_location_Latitude]
   ,[Current_location_Longitude],[location_Latitude_From],[location_Longitude_From],[Submitedby],[SubmitedDate],[Status],[Stateid]
   )
VALUES
(@Villageid,@TigerReserveID,@Village_Name,@Agriculture_Land,@Population,@Residential_property,@Total_Standing_Trees
,@Total_Livestock,@Relocated_from,@Relocated_place,@Total_well,@Other_Assets,@Current_location_Latitude,@Current_location_Longitude
,@location_Latitude_From,@location_Longitude_From,@Submitedby,GETDATE(),3,@stateid)
   
    set @id=SCOPE_IDENTITY()
    Insert into Tbl_Village_Animals (villageid,Animalid,TotalAnimal)
    select @id, Animalid,TotalAnimal from @Animal_Details
End

End

GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateTigerReserve]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[InsertUpdateTigerReserve]
(
@TigerReserveid int = null,
@TigerReserveName nvarchar(500) = null,
@TigerReserveNameHindi nvarchar(500) = null,
@NoofVillages int,
@StateID int,
@Dist int,
@City int,
@TigerReserveMap nvarchar(200),
@CreatedBy int,
@CoreArea varchar(50),
@BufferArea varchar(50),
@longitude nvarchar(50),
@latitude nvarchar(50),
@Status int
)
As
Begin
  if (@TigerReserveid is null)
     Begin
	   Insert into Tbl_TigerReserve(TigerReserveName,TigerReserveNameHindi,NoofVillages,StateID,Dist,City,
	                               TigerReserveMap,CreationDate,CreatedBy,[Status],CoreArea,BufferArea,longitude
								   ,latitude)
		 values(@TigerReserveName,@TigerReserveNameHindi,@NoofVillages,@StateID,@Dist,@City,@TigerReserveMap,
		          GETDATE(),@CreatedBy,@Status,@CoreArea,@BufferArea,@longitude,@latitude)
	 End
	 Else
	 Begin
	  update Tbl_TigerReserve set
	        TigerReserveName=@TigerReserveName,TigerReserveNameHindi=@TigerReserveNameHindi,
			NoofVillages=@NoofVillages,StateID=@StateID,Dist=@Dist,City=@City,TigerReserveMap=@TigerReserveMap,
			   ModificationDate=GETDATE(),CoreArea=@CoreArea,BufferArea=@BufferArea,
			   longitude=@longitude,latitude=@latitude
			   where TigerReserveid=@TigerReserveid
	 End
	 
End

GO
/****** Object:  StoredProcedure [dbo].[MST_Get_Language]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MST_Get_Language]  

(        

 @Lang_Id nvarchar(MAX) = NULL        

)        

AS         

 BEGIN        

  BEGIN TRY        

   SET NOCOUNT ON;       

     SELECT [Lang_Id],[Language]        

     FROM Mst_Language       

     WHERE ((Lang_Id=@Lang_Id) OR (@Lang_Id IS NULL))        

     --WHERE Lang_Id IN (SELECT val from dbo.fn_String_To_Table(@Lang_Id,',',1))        

        

             

   SET NOCOUNT OFF;        

  END TRY        

  BEGIN CATCH                

   --There was an error                

    exec sp_error_handler                

    IF @@TRANCOUNT>0                

    ROLLBACK                 

    RETURN -101                

                     

  END CATCH                

                  

  RETURN 0        

END


GO
/****** Object:  StoredProcedure [dbo].[MST_GetStatus]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SELECT * FROM MST_STATUS    

create PROC [dbo].[MST_GetStatus]        

(              

 @Status_Id NVARCHAR(MAX) = NULL              

)              

AS               

 BEGIN              

  BEGIN TRY              

   SET NOCOUNT ON;              

              

    SELECT [Statusid],[Status]              

    FROM Mst_Status             

    WHERE StatusType=2
	--Status_Id IN(SELECT VAL from dbo.fn_String_To_Table( @Status_Id,',',1))     

    
          

  
   SET NOCOUNT OFF;              

  END TRY              

  BEGIN CATCH                      

   --There was an error                      

    exec sp_error_handler                      

    IF @@TRANCOUNT>0                      

    ROLLBACK                       

    RETURN -101                      

                           

  END CATCH                      

                        

  RETURN 0              

END


GO
/****** Object:  StoredProcedure [dbo].[sp_CountRootOrder_Link]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_CountRootOrder_Link]          

(          

 @rootLevelId int          

)           

          

AS                

BEGIN                  

    BEGIN TRY              

              

    SET NOCOUNT ON;                 

  Select top 1 link_Id,Link_Order,link_level             

  from Web_Link                

  where link_parent_Id=@rootLevelId             

  ORDER BY Link_Order DESC            

    SET NOCOUNT OFF;           

              

     END TRY                  

                    

  BEGIN CATCH                  

   --There was an error                  

   EXEC sp_error_handler                  

   IF @@TRANCOUNT>0                  

   ROLLBACK                   

   RETURN -101                  

  END CATCH                  

 RETURN 0                    

              

END


GO
/****** Object:  StoredProcedure [dbo].[sp_Display_All_Banner]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Display_All_Banner]         

(                                

  @status_id int=null,                

  @StateID int=null,
  
  @TigerReserveID int=null,            

  @module_Id int=null                

                          

 )                                        

AS                                          

BEGIN                     

 BEGIN TRY                            

   BEGIN TRAN                         

    SET NOCOUNT ON;                       

 IF  @Status_Id!=5                    

begin                            

  SELECT [Temp_Link_Id],[Module_Id],[Name],[Page_Title],[Details]            

     ,[Image_Name]  ,[Alt_Tag],[Status_Id],[Link_Id],[Lang_Id]            

     ,[Rec_Insert_Date],[Rec_Update_Date],AltTag_Reg,StateID , TigerReserveid        

     FROM Tmp_Link          

     WHERE Status_Id=@Status_Id AND Module_Id=@module_Id  AND StateID=@StateID   and TigerReserveid=@TigerReserveID                

 end                          

                       

else                    

begin                      

  SELECT Link_Id AS Temp_Link_Id,[Module_Id],[Name],[Page_Title],[Details]            

     ,[Image_Name]  ,[Alt_Tag],[Status_Id],[Link_Id],[Lang_Id]            

     ,[Rec_Insert_Date],[Rec_Update_Date],AltTag_Reg,StateID , TigerReserveid   

    FROM  Web_Link          

    WHERE  Status_Id=@Status_Id  AND Module_Id=@module_Id AND StateID=@StateID   and TigerReserveid=@TigerReserveID                             

end                       

 SET NOCOUNT OFF;                         

    COMMIT TRAN                            

  END TRY                            

                              

  BEGIN CATCH                            

   --There was an error                            

   EXEC sp_error_handler                            

   IF @@TRANCOUNT>0                            

   ROLLBACK                             

   RETURN -101                            

  END CATCH                            

 RETURN 0                            

END


GO
/****** Object:  StoredProcedure [dbo].[sp_error_handler]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_error_handler]  

  

AS  

BEGIN  

    DECLARE @errnum INT,  

            @severity INT,  

            @errstate INT,  

            @proc NVARCHAR(126),  

            @line INT,  

            @message NVARCHAR(4000)  

    -- capture the error information that caused the CATCH block to be invoked  

    SELECT @errnum = ERROR_NUMBER(),  

           @severity = ERROR_SEVERITY(),  

           @errstate = ERROR_STATE(),  

           @proc = ERROR_PROCEDURE(),  

           @line = ERROR_LINE(),  

           @message = ERROR_MESSAGE()  

    -- raise an error message with information on the error  

    RAISERROR ('Failed to execute query for the following reason:  

 Error: %d, Severity: %d, State: %d, in proc %s at line %d, Message: "%s"',  

               16, 1, @errnum, @severity, @errstate, @proc, @line, @message)  

    RETURN  

END


GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Link_Tmp_Edit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Get_Link_Tmp_Edit]   
(                
   @TempLinkId INT = NULL,                                     
   @statusId   INT = NULL                               
)                

AS                 
 BEGIN                

  BEGIN TRY                

   SET NOCOUNT ON;              

   BEGIN              
    IF @statusId!=5                   

  BEGIN              

    SELECT [Temp_Link_Id],[Module_Id],[Link_Parent_Id],[Link_Order],[Link_Level],[Link_Type_Id],[Position_Id],[Name],               
        [Subject],[Details],[Browser_Title],[Page_Title],[Meta_Keywords],[Mate_Description],[Url],[File_Name],                
        [Image_Name],[Alt_Tag],[Status_Id],[Link_Id],[Lang_Id],[Inserted_By],[Last_Updated_By],StateID,TigerReserveid,
		MetaLanguage, MetaTitle ,UrlName ,SmallDetails            
      FROM Tmp_Link                
      WHERE ((Temp_Link_Id=@TempLinkId) OR (@TempLinkId IS NULL))
	   and ((Status_Id=@statusId) OR (@statusId IS NULL))                                 

       END                      

      ELSE                      

    BEGIN                    

   SELECT [Link_Id]as [Temp_Link_Id],[Module_Id],[Link_Parent_Id],[Link_Order],[Link_Level],[Link_Type_Id],[Position_Id],                
    [Name],[Subject],[Details],[Browser_Title],[Page_Title],[Meta_Keywords],[Mate_Description],                
    [Url],[File_Name],[Image_Name],[Alt_Tag],[Status_Id],[Lang_Id],[Inserted_By],[Last_Updated_By], Link_Id,StateID,TigerReserveid ,
	MetaLanguage, MetaTitle ,UrlName ,SmallDetails            
    FROM Web_Link             
    WHERE ((Link_Id=@TempLinkId) OR (@TempLinkId IS NULL)) 
	and ((Status_Id=@statusId) OR (@statusId IS NULL))                                 

   End                

   End            

   SET NOCOUNT OFF;                


  END TRY                
  BEGIN CATCH                        
   --There was an error                        
    exec sp_error_handler                        

    IF @@TRANCOUNT>0                        

    ROLLBACK                         

    RETURN -101                        
  END CATCH                                 
  RETURN 0                
   END


GO
/****** Object:  StoredProcedure [dbo].[sp_getApproveContent forEdit]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getApproveContent forEdit]      

(        

@Link_Id INT=null        

)        

       

AS     

 BEGIN    

  BEGIN TRY    

   SET NOCOUNT ON;          

SELECT Link_Id as Link_Id from Tmp_Link where Link_Id in (SELECT Link_Id FROM Web_Link WHERE Link_Id=@Link_Id)        

 SET NOCOUNT OFF;    

  END TRY    

  BEGIN CATCH            

   --There was an error            

    exec sp_error_handler            

    IF @@TRANCOUNT>0            

    ROLLBACK             

    RETURN -101            

                 

  END CATCH            

              

  RETURN 0    

END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetChildofRootMenu]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_GetChildofRootMenu]                    



(                            



 @link_parent_id INT=null,                            



 @lang_id INT=null                            



)                            



AS                            



BEGIN                             



 SET NOCOUNT ON;                     



                          



  SELECT link_id,name,Link_Order,Link_Level,position_id ,url,              



  [dbo].[GetChildCounter](link_id)as counter_Child ,              



  link_parent_id,UrlName,                  



  --[UrlName],                  



  Link_Type_Id                           



  FROM Web_Link                           



  WHERE link_parent_id = @link_parent_id                         



  and Lang_Id=@lang_id                       



  AND status_id=5                           



  ORDER BY Link_Order                            



                    



 SET NOCOUNT OFF;                             



END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetMainMenuForSubMenuLink]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_GetMainMenuForSubMenuLink]                                   







(                                                          







@LangID INT=NULL ,                                          







@StateID INT=NULL,







@TigerReserveID INT=NULL,







@PositionId INT=NULL,                  







@LinkParentId INT=NULL                                                         







)                                                          







AS                                                          







BEGIN                                                          







  BEGIN TRY                                                          







   BEGIN TRAN                                                   







                                                            







    SELECT Link_Id,name, Link_Parent_Id,Lang_Id, Link_Order, Link_Level,Position_Id                                                       







    FROM Web_Link                                                         







    WHERE [Lang_Id]=@LangID                                         







    AND Link_Parent_Id=@LinkParentId                                        







    AND Position_Id=@PositionId    



	               



	AND StateID=@StateID







	and TigerReserveid=@TigerReserveID



                                          







    AND Link_Id NOT IN (6,7)             







                                     







    ORDER BY Link_Order desc                                                      







                                                           







   COMMIT TRAN                                                          







  END TRY                                                          







                                                            







  BEGIN CATCH                                                          







   --There was an error                                                          







   EXEC sp_error_handler                                                          







   IF @@TRANCOUNT>0                                                          







   ROLLBACK                                                           







   RETURN -101                                                          







  END CATCH                                                          







 RETURN 0                                                          







END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetParantSublinksID]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetParantSublinksID]                       

(                        

 @LinkParentId int,                        

 @LinkLevel int,                        

 @PositionId int                        

)                        

                        

AS                        

BEGIN                         

SET NOCOUNT ON;                        

 BEGIN TRY                        

                        

  BEGIN TRAN                        

                          

   SELECT Link_Id,Name,Link_Order,Lang_Id,Position_Id from Web_Link                        

   WHERE  Link_Parent_Id=@LinkParentId                     

    and Link_Level=@LinkLevel                     

    and Position_Id=@PositionId                 

    --and Status_Id!=8          

         

   ORDER BY Link_Order asc                           

                        

  COMMIT TRAN                        

                        

 END TRY                        

                        

 BEGIN CATCH                        

                         

  EXEC sp_error_handler                            

  IF @@TRANCOUNT>0                            

     ROLLBACK                             

     RETURN -101                           

                        

 END CATCH                        

 RETURN 0                        

 SET NOCOUNT OFF;                         

END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPhotoCategoryTmp]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_GetPhotoCategoryTmp]               



(                    



 @TempMCategoryId INT = NULL,                    



 @MediaTypeId INT = NULL,             



 @ModuleId INT =NULL,                   



 @StatusId INT = NULL ,    



 @LangId int=null,                



 @StateID int=null,



 @TigerReserveID int= null,



 --Variables for paging                



                 



 @PageIndex INT = NULL,                



 @PageSize INT = NULL,                



 @RecordCount INT OUTPUT                   



                



--end                 



)                    



AS                     



 BEGIN                    



  BEGIN TRY                    



   SET NOCOUNT ON;                   



   IF  @StatusId!=5 --StatusID = 6 for approved records.                  



                     



 BEGIN                  



                  



   SELECT ROW_NUMBER() OVER                



      (                



       ORDER BY TempCategoryId ASC                



      )AS RowNumber,  TempCategoryId,[CatName],CaNametHindi,[StatusId],[UserId],[DateInserted],[DateLastUpdated],StateID,TigerReserveID                    



                        



     INTO #Results                



                     



      FROM Category_Tmp                 



      WHERE TempCategoryId=isnull(@TempMCategoryId,TempCategoryId)                   



      and StatusId=@StatusId                  

	  and TigerReserveid=@TigerReserveID and StateID=@StateID

                      



      SELECT @RecordCount = COUNT(*)                



      FROM #Results                



                           



      SELECT * FROM #Results                



     -- WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1                



                     



      DROP TABLE #Results                



               



                   



 END                  



                



                   



   ELSE                  



                     



   BEGIN                  



       SELECT ROW_NUMBER() OVER                



      (                



            ORDER BY CategoryId ASC                



      )AS RowNumber,CategoryId AS [TempCategoryId],[CatName],CaNametHindi,[StatusId],

	  CategoryId,[UserId],[DateInserted],[DateLastUpdated],StateID, TigerReserveID                    



                      



       INTO #Results1                



                       



        FROM Category                 



      WHERE CategoryId=isnull(@TempMCategoryId,CategoryId)                     



      and StatusId=@StatusId                  

	  and TigerReserveid=@TigerReserveID and StateID=@StateID

                      



       SELECT @RecordCount = COUNT(*)                



      FROM #Results1                



                           



      SELECT * FROM #Results1                



     -- WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1                



                     



      DROP TABLE #Results1                



                          



   END                  



                  



   SET NOCOUNT OFF;                    



  END TRY                    



  BEGIN CATCH                            



   --There was an error                            



    exec sp_error_handler                            



    IF @@TRANCOUNT>0                            



    ROLLBACK                             



    RETURN -101                            



                                 



  END CATCH                                     



  RETURN 0                    



   END










GO
/****** Object:  StoredProcedure [dbo].[sp_GetRootMenu]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[sp_GetRootMenu]                                   



 (                                                    



 @langid int,                                                    



 @linkparentid int,                                                    



 @moduleid int,                                                    



 @positionid int,

 @StateID int,

 @TigerReserveid int                                              



                                                   



 )                                                    



                                                     



 AS                                                    



BEGIN                                                     



SET NOCOUNT ON;                                                


   BEGIN         

   if @langid=1
   begin
    select link_id,link_type_id,url,[dbo].[GetChildCounter](link_id)as counter_Child ,UrlName,replace(name,'&','&amp;') as name,link_order,link_level,position_id,  link_parent_id                                  



   from Web_Link                                                     



   where position_id = @positionid and link_parent_id =@linkparentid                                           



   and [lang_id]=@langid                                                    



   and module_id=@moduleid                                               



   and status_id=5                                               



  and StateID=@StateID and TigerReserveid=@TigerReserveid                            

  or link_id=6

     order by case when link_id= 6 then 1  
	 else 2 
	 end                              

end
else
begin

   select link_id,link_type_id,url,[dbo].[GetChildCounter](link_id)as counter_Child ,UrlName,replace(name,'&','&amp;') as name,link_order,link_level,position_id,  link_parent_id                                  



   from Web_Link                                                     



   where position_id = @positionid and link_parent_id =@linkparentid                                             



   and [lang_id]=@langid                                                    



   and module_id=@moduleid                                               



   and status_id=5                                               



  and StateID=@StateID and TigerReserveid=@TigerReserveid                            
  or link_id=7


     order by case when link_id= 7 then 1 
	 else 2
	 end
end

   END                                              



                            



 SET NOCOUNT OFF;                                                     



END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetStateName]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetStateName]

(

	@langID int=null

)

AS

	BEGIN

		IF @langID=1

			BEGIN

				SELECT ID, statename 

				FROM state_list

				ORDER BY ID

			END

		ELSE if @langID=2

			BEGIN

				SELECT ID, StateNameHindi AS STATENAME 

				FROM state_list

				ORDER BY ID

			END
			else 
			BEGIN

				SELECT ID, statename 

				FROM state_list

				ORDER BY ID

			END

    END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetTigerReserve]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[sp_GetTigerReserve]

 (

  @LangID int=null,

  @StateID int

 )

 AS

	BEGIN

		IF  @LangID=1

			BEGIN



				SELECT TigerReserveid,TigerReserveName

				FROM Tbl_TigerReserve

				WHERE StateID=@StateID



			END



		ELSE if @LangID=2

			BEGIN



			SELECT TigerReserveid,TigerReserveNameHindi AS TigerReserveName

				FROM Tbl_TigerReserve

				WHERE StateID=@StateID



			END
		else
		begin
				SELECT TigerReserveid,TigerReserveName

				FROM Tbl_TigerReserve

				WHERE StateID=@StateID
		end


	END

GO
/****** Object:  StoredProcedure [dbo].[sp_insertUpdateWebLink]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_insertUpdateWebLink]                                                         

(                                                        

   @TempLinkId INT=NULL,                                       

   @orderCount INT=NULL,                               

   @IpAddress NVARCHAR(100)=NULL,                      

   @UpdatedBY INT =NULL,                                                       

   @recordCount INT OUTPUT                                                        

)                                                        



AS                                                        

BEGIN                                                                           

 BEGIN TRY                                                              

   BEGIN TRAN                                                           

    SET NOCOUNT ON;                                                         

    declare @tLinkID int                                                         

    declare @level int                                      

    declare @parentID int                          



set @tLinkID=(select Link_Id from Tmp_Link where Temp_Link_Id=@TempLinkId)                                      

set @parentID=(select link_Parent_Id from Tmp_Link where Temp_Link_Id=@TempLinkId)                                       



 IF exists(select Link_Order from Web_Link where Link_Parent_Id=@parentID)                                                

     BEGIN                                                

		SET @orderCount=(select MAX(Link_Order) from Web_Link where Link_Parent_Id=@parentID)                                                 

     END                                                

       ELSE                                                



     BEGIN                                                

      SET @orderCount=0                                                

     END                                                             

 IF @tLinkID is null                                                      

   BEGIN                                                           

      INSERT INTO [Web_Link]                                            

     ([Module_Id],[Link_Parent_Id],[Link_Order],[Link_Level],[Link_Type_Id],                                            

      [Position_Id],[Name],[Subject],[Details] ,[Browser_Title],[Page_Title],                                            

      [Meta_Keywords],[Mate_Description],[Url],[File_Name],[Image_Name],[Alt_Tag],                                            

      [Status_Id],[Lang_Id],[Inserted_By],[Last_Updated_By],                                           

      IPAddress,Rec_Insert_Date,Name_Reg,AltTag_Reg,SmallDetails,UrlName,MetaLanguage,MetaTitle,

	  StateID,TigerReserveid)                                                        

    SELECT [Module_Id],[Link_Parent_Id],@orderCount+1,[Link_Level],[Link_Type_Id],                                            

      [Position_Id],[Name],[Subject],[Details] ,[Browser_Title],[Page_Title],                                            

      [Meta_Keywords],[Mate_Description],[Url],[File_Name],[Image_Name],[Alt_Tag],                                            

      5,[Lang_Id],@UpdatedBY,[Last_Updated_By],

	  @IpAddress,getdate(), Name_Reg,AltTag_Reg,SmallDetails,UrlName,MetaLanguage,MetaTitle,

	  StateID,TigerReserveid                                         

      from Tmp_Link                                                       

    WHERE Temp_Link_Id=@TempLinkId                                                        



    SET @recordCount=@@ROWCOUNT                                                          

    DELETE FROM Tmp_Link                                           

    WHERE  Temp_Link_Id=@TempLinkId                 

          END                                                      



        else    

            BEGIN                                                                    

   UPDATE Web_Link              

   SET Web_Link.[Module_Id]=Tmp_Link.[Module_Id],                                                      

   Web_Link.[Link_Parent_Id]=Tmp_Link.[Link_Parent_Id],                                            

   Web_Link.[Link_Level]=Tmp_Link.[Link_Level],                       

   Web_Link.[Link_Type_Id]=Tmp_Link.[Link_Type_Id],                                                      

   Web_Link.[Name]=Tmp_Link.[Name],      

    Web_Link.[Name_Reg]=Tmp_Link.[Name_Reg],                               

   Web_Link.[Browser_Title]=Tmp_Link.[Browser_Title],                                                      

   Web_Link.[Page_Title]=Tmp_Link.[Page_Title],                                                   

   Web_Link.Details=Tmp_Link.Details,                                                      

   Web_Link.[Meta_Keywords]=Tmp_Link.[Meta_Keywords],                                           

   Web_Link.[Mate_Description]=Tmp_Link.[Mate_Description],                                                      

   Web_Link.[Url]=Tmp_Link.[Url],                                                      

   Web_Link.[Image_Name]=Tmp_Link.[Image_Name],                               

   Web_Link.[Alt_Tag]=Tmp_Link.[Alt_Tag],    

   Web_Link.AltTag_Reg=Tmp_Link.AltTag_Reg,                                                              

   Web_Link.[Status_Id]=5,                              

   Web_Link.IPAddress=@IpAddress,                                                   

   Web_Link.Last_Updated_By=@UpdatedBY,                    

   Web_Link.[Inserted_By]=@UpdatedBY,                                                             

   Web_Link.[Rec_Update_Date]=getdate(),                                             

   Web_Link.[Rec_Insert_Date]=getdate(),           

   Web_Link.[UrlName]=Tmp_Link.UrlName,

   Web_Link.[MetaLanguage]=Tmp_Link.MetaLanguage,

   Web_Link.[MetaTitle]=Tmp_Link.MetaTitle,

   Web_Link.[StateID]=Tmp_Link.StateID,

   Web_Link.[TigerReserveid]=Tmp_Link.TigerReserveid,
   Web_Link.[SmallDetails]=Tmp_Link.SmallDetails


   FROM Web_Link, Tmp_Link                                                     







   WHERE Web_Link.Link_Id = @tLinkID and Tmp_Link.Link_Id=@tLinkID                                                     







   DELETE from Tmp_Link  WHERE  Temp_Link_Id=@TempLinkId                                                        







   SET @recordCount=@@ROWCOUNT                                                      







                                                        







         END                                                      







  SET NOCOUNT OFF;                                                           







    COMMIT TRAN                                                              







  END TRY                                                              







                                    







  BEGIN CATCH                                                              







   --There was an error                                                              







 EXEC sp_error_handler                                                              







 IF @@TRANCOUNT>0                                                              







 ROLLBACK                                                               







 RETURN -101                 







  END CATCH                                                              







 RETURN 0                                                      







       







 END


GO
/****** Object:  StoredProcedure [dbo].[sp_Links_Insert_Update_Banner]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Links_Insert_Update_Banner]                    

(                    

 @ActionType tinyint,                 

 @TempLink_Id int =null,                 

 @Module_Id int     =null,                               

 @Name nvarchar(max)    =null,                                    

 @AltTag nvarchar(max)    =null,                    

 @StateID int=null,
 @TigerReserveID int=null,                        

 @Image_Name nvarchar(200)  =null,                                        

 @Status_Id int     =null,                    

 @Start_Date datetime   =null,                    

 @End_Date datetime    =null,                    

 @Link_Id int     =null,                    

 @Lang_Id int     =null,                

 @Rec_Insert_Date datetime  =null,                    

 @Rec_Update_Date datetime  =null,

 @NameReg nvarchar(max)=null,

 @AltReg nvarchar(max)=null,                      

 @recordCount int output                   

)                              

as                    

BEGIN                   

                    

 BEGIN TRY                    

  BEGIN TRANSACTION -- Start the Transaction                    

  SET NOCOUNT ON;                    

                      

   if @ActionType=1                     

   BEGIN                    

    INSERT INTO Tmp_Link ([Module_Id], [Name],Alt_Tag, [Image_Name],[Status_Id],                 

       Link_Id,[Lang_Id],[Rec_Insert_Date],[Rec_Update_Date],Name_Reg,AltTag_Reg,StateID,TigerReserveid)                    

    VALUES                    

       (@Module_Id,@Name , @AltTag,@Image_Name ,@Status_Id ,@Link_Id ,                    

       @Lang_Id ,GETDATE(),@Rec_Update_Date,@NameReg,@AltReg,@StateID,@TigerReserveID )                  

                         

    set @recordCount=@@ROWCOUNT                      

   END                    

   else if @ActionType=2                     

   BEGIN            

   if   @Status_Id!=5                   

  Begin                             

    UPDATE Tmp_Link                   

    SET                     

      [Name] = @Name,                              

      Alt_Tag = @AltTag,                    

      [Image_Name] = @Image_Name,                                

      [Status_Id] = @Status_Id,                    

      [Lang_Id] = @Lang_Id, 

       Name_Reg=@NameReg,

       AltTag_Reg=@AltReg,  
	   StateID=@StateID,
	   TigerReserveid=@TigerReserveID,                 

      [Rec_Insert_Date] = getdate(),                    

      [Rec_Update_Date] = GETDATE()                    

    WHERE Temp_Link_Id  =@TempLink_Id                   

    set @recordCount=@@ROWCOUNT                     

   END           

    else                    

  begin                        

     INSERT INTO Tmp_Link ([Module_Id],                 

       [Name],Alt_Tag,[Image_Name],[Status_Id],[Start_Date],[End_Date],                    

       Link_Id,[Lang_Id],[Rec_Insert_Date],[Rec_Update_Date],Name_Reg,AltTag_Reg,StateID,TigerReserveid)                       

     VALUES                    

       (@Module_Id,@Name ,  @AltTag , @Image_Name ,3 ,@Start_Date,@End_Date ,@Link_Id ,                    

       @Lang_Id ,GETDATE(),@Rec_Update_Date ,@NameReg,@AltReg,@StateID,@TigerReserveID)                     

     end               

    set @recordCount=@@ROWCOUNT                      

   END                          

  COMMIT --Commit the transaction                    

  SET NOCOUNT OFF;                  

END TRY                    

                     

BEGIN CATCH                    

 --There was an error                    

 exec sp_error_handler              

 IF @@TRANCOUNT>0                    

  ROLLBACK                     

 RETURN -101                    

                      

END CATCH                    

       

RETURN 0                    

                    

END


GO
/****** Object:  StoredProcedure [dbo].[sp_Tmp_link_Insert_Update]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Tmp_link_Insert_Update]                                            

(                                            



 @ActionType TINYINT = NULL,                                            

 @Temp_Link_Id INT = NULL,                                            

 @Module_Id int=NULL,                                            

 @Link_Parent_Id int=NULL,                                            

 @Link_Order int=NULL,                                            

 @Link_Level int=NULL,                                            

 @Link_Type_Id int=NULL,                                            

 @Position_Id int=NULL,                                            

 @StateID int=NULL,                                            

 @Name nvarchar(max)=NULL,                                 

 @Name_Reg NVARCHAR(max)=NULL,                                             

 @Subject nvarchar(max)=NULL,                                            

 @Details ntext=NULL,                                

 @SmallDetails nvarchar(max)=NULL,                               

 @Details_Reg NVARCHAR(MAX)=NULL,                                           

 @Browser_Title nvarchar(max)=NULL,                                            

 @Page_Title nvarchar(max)=NULL,                                            

 @Meta_Keywords nvarchar(max)=NULL,                                            

 @Mate_Description nvarchar(max)=NULL,                                            

 @Url nvarchar(max)=NULL,                                            

 @Alt_Tag nvarchar(max)=NULL,                                

 @AltTag_Reg NVARCHAR(max)=NULL,                                             

 @Status_Id int=NULL,                                            

 @Link_Id int=NULL,                                            

 @Lang_Id int=NULL,                                            

 @Inserted_By int=NULL,                                            

 @Last_Updated_By int=NULL,                                            

 @Rec_Insert_Date datetime=NULL,                                            

 @Rec_Update_Date datetime=NULL,                                        

 @UrlName NVARCHAR(50)=NULL,                           

 @MetaLng  nvarchar(2000)=null,

 @MetaTitle nvarchar(2000)=null,   

 @TigerReserveid INT =null,  

 @IpAddress varchar(50)=NULL,

 @recordCount INT OUTPUT                                            

)                                            



AS                                                     



BEGIN                                                     





  BEGIN TRY                                                      



   BEGIN TRANSACTION -- Start the Transaction                                                      



   SET NOCOUNT ON;                                                      





     IF @ActionType=1    --Action to insert new record into temp                                                   



     BEGIN                                             



    INSERT INTO [Tmp_Link]                                            



     ([Module_Id],[Link_Parent_Id],[Link_Order],[Link_Level],[Link_Type_Id],                                            

     [Position_Id],StateID,[Name],[Subject],[Details],[Browser_Title],[Page_Title],                                            

     [Meta_Keywords],[Mate_Description],[Url],[Alt_Tag],                                            

	 [Status_Id],Link_Id,[Lang_Id],[Inserted_By],                  

	 [Rec_Insert_Date],UrlName,Name_Reg,Details_Reg,AltTag_Reg,MetaLanguage,MetaTitle,        

	 TigerReserveid,IpAddress,SmallDetails)                                            



    VALUES                                            



     (@Module_Id, @Link_Parent_Id,@Link_Order,@Link_Level,@Link_Type_Id,                                    

	  @Position_Id,@StateID,@Name,@Subject,@Details,@Browser_Title,@Page_Title,             

      @Meta_Keywords,@Mate_Description,@Url,@Alt_Tag,@Status_Id,                                             

	  @Link_Id,@Lang_Id,@Inserted_By,                                            

	  getdate(),@UrlName,@Name_Reg,@Details_Reg,@AltTag_Reg,       

      @MetaLng,@MetaTitle,@TigerReserveid,@IpAddress,@SmallDetails)                                            



      SET @recordCount=SCOPE_IDENTITY()                                                     



     END                                            

   ELSE IF @ActionType=2     --Action to update new record                                                 

     BEGIN                                           

     if(@Status_Id!=5)                                        

       begin                                          

		 UPDATE [Tmp_Link]                                            

		 SET [Module_Id] = @Module_Id,                                             

		 [Link_Parent_Id] = @Link_Parent_Id,                                             

		 --[Link_Order] = @Link_Order,                                             

		 [Link_Level] = @Link_Level,                                            

		 [Link_Type_Id] = @Link_Type_Id,                                            

		 SmallDetails=@SmallDetails,                          

		 --[Position_Id] = @Position_Id,                                            

		 [StateID] = @StateID,                                            

		 [Name] = @Name,                                             

		 [Subject] = @Subject,                                            

		 [Details] = @Details,                                            

		 [Browser_Title] = @Browser_Title,                                            

		 [Page_Title] = @Page_Title,                                            

		 [Meta_Keywords] = @Meta_Keywords,                                             

		 [Mate_Description] = @Mate_Description,                                             

		 [Url] = @Url,                                            

		 [Alt_Tag] = @Alt_Tag,                                          

		 [Status_Id] = @Status_Id,                                            

		 [Last_Updated_By] = @Last_Updated_By,                                            

		 [Rec_Update_Date] = getdate() ,                                        

			UrlName= @UrlName ,                                

			[Name_Reg]        =@Name_Reg,                                               

			[Details_Reg]     =@Details_Reg,                                                

			[AltTag_Reg]      =@AltTag_Reg ,                           

			MetaLanguage=@MetaLng,

			MetaTitle=@MetaTitle ,

			IpAddress=@IpAddress,

			[TigerReserveid]=@TigerReserveid                                    

			WHERE Temp_Link_Id = @Temp_Link_Id                                            

			SET @recordCount=@@rowcount                                             

			SET @recordCount=@Temp_Link_Id               

    end                                          



      else                                                    

    begin                             



      INSERT INTO [Tmp_Link]                                            





     ([Module_Id],[Link_Parent_Id],[Link_Order],[Link_Level],[Link_Type_Id],     

	 [StateID],[Name],[Subject],[Details],[Browser_Title],[Page_Title],                                            

	 [Meta_Keywords],[Mate_Description],[Url],[Alt_Tag],                                            

Link_Id,[Lang_Id],[Inserted_By],                                            

 [Rec_Insert_Date],UrlName,Name_Reg,                      



 Details_Reg,AltTag_Reg,MetaLanguage,MetaTitle,TigerReserveid,IpAddress,SmallDetails)                                            

VALUES                                            



 (@Module_Id, @Link_Parent_Id,@Link_Order,@Link_Level,@Link_Type_Id,                                            

   @StateID,@Name,@Subject,@Details,@Browser_Title,@Page_Title,                                            

  @Meta_Keywords,@Mate_Description,@Url,@Alt_Tag,                                             

  @Link_Id,@Lang_Id,@Inserted_By,                                        

 getdate(),@UrlName,@Name_Reg,@Details_Reg,@AltTag_Reg,@MetaLng,@MetaTitle,@TigerReserveid,@IpAddress,@SmallDetails)                                            

 set @recordCount=SCOPE_IDENTITY()                  

  end                                                   

  END                                                                    

 SET NOCOUNT OFF;                                            

COMMIT --Commit the transaction                                                      

 END TRY                                                      



 BEGIN CATCH                                                      



 --There was an error    



  exec sp_error_handler                         





  IF @@TRANCOUNT>0                                                      





   ROLLBACK                                                       



  RETURN -101                                                      



 END CATCH                                                      



 RETURN 0                                                      

 

END



GO
/****** Object:  StoredProcedure [dbo].[sp_TmpDataDisplayInGrid]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @i int



--exec [sp_TmpDataDisplayInGrid]  null,2,2,1,0,1,14,3,null,null,@i output  







CREATE PROC [dbo].[sp_TmpDataDisplayInGrid]                                                                      







(                                                                                      



  @Temp_Link_Id INT =NULL,                                                                                    



  @module_Id INT =NULL,                                                                          



  @Lang_Id INT  = NULL,                                                                  



  @position_Id INT =NULL,                                                                



  @List_value INT =NULL,                                                              



  @StateID INT =NULL,                                                



  @TigerReserveid int = NULL,                                                                    



  @Statusid int =null,



  --Variables for paging                         







 @PageIndex INT  = NULL,                                                                    



 @PageSize INT  = NULL,                                                                    



 @RecordCount INT OUTPUT                       







  --end                                                                                        







)                                                                                      







AS                                                                                       







 BEGIN                                                                                      







  BEGIN TRY                                                                                      











   SET NOCOUNT ON;                                                                                    







  BEGIN                                                                       















  IF @Statusid!=5                                                                    







   BEGIN                                                                                                







    SELECT ROW_NUMBER() OVER(ORDER BY coalesce(convert(datetime,[Rec_Update_Date]),convert(datetime,[Rec_Insert_Date])) desc)AS RowNumber,



	[Temp_Link_Id],[Module_Id],[Link_Parent_Id],[Link_Order],[Link_Level],[Link_Type_Id]



  ,[Position_Id],[StateID],[TigerReserveid],[Name],[Name_Reg],[Subject],[Details],[SmallDetails]



 ,[Details_Reg],[Browser_Title],[Page_Title] ,[Meta_Keywords],[Mate_Description],[Url]



 ,[File_Name],[Image_Name],[Alt_Tag],[AltTag_Reg],[Status_Id],[Link_Id]







   ,[Lang_Id],[Inserted_By],[Last_Updated_By],[Start_Date],[End_Date],[Rec_Insert_Date]







  ,[Rec_Update_Date],[IpAddress],[UrlName],[MetaLanguage],[MetaTitle]          



 FROM Tmp_Link                               



WHERE ((Module_Id=@module_Id) OR (@module_Id IS NULL)) AND ((Lang_Id=@Lang_Id) OR (@Lang_Id IS NULL))  



 AND   StateID=@StateID AND    TigerReserveid=@TigerReserveid  And Status_Id= @Statusid                                                         







 AND ((Position_Id=@position_Id) OR (@position_Id IS NULL))AND((Link_Parent_Id=@List_value) OR (@List_value IS NULL))                                           







   SELECT @RecordCount = COUNT(*)                                      















   FROM Tmp_Link                                                                                                         















   End                                                                 















   ELSE if @Statusid=5                             















  BEGIN               















   SELECT ROW_NUMBER() OVER                                          







   (  ORDER BY coalesce(convert(datetime,[Rec_Update_Date]),convert(datetime,[Rec_Insert_Date])) desc)AS RowNumber,



   [Link_Id] AS Temp_Link_Id ,[Module_Id],[Link_Parent_Id],[Link_Order],[Link_Level],[Link_Type_Id],  [Position_Id],[Name],[Subject],                                 



   CAST([Details]AS NVARCHAR(max)) AS [Details],SmallDetails , [Browser_Title],[Page_Title],                                                                              



	[Meta_Keywords],[Mate_Description],[Url],[Image_Name],[Alt_Tag],[Status_Id],[Lang_Id],[Last_Updated_By],                                                      



 replace(CONVERT(NVARCHAR(11), Rec_Insert_Date,106),' ','-')AS [Rec_Insert_Date],[Rec_Update_Date]                           



 FROM Web_Link                                                                           







   WHERE ((Module_Id=@module_Id) OR (@module_Id IS NULL)) AND ((Lang_Id=@Lang_Id) OR (@Lang_Id IS NULL))                        



   AND ((Position_Id=@position_Id) OR (@position_Id IS NULL)) AND((Link_Parent_Id=@List_value) OR (@List_value IS NULL))                                                                 



   AND   StateID=@StateID  AND    TigerReserveid=@TigerReserveid  And Status_Id= @Statusid 



   and Link_Id not in(6,7)  



   SELECT @RecordCount = COUNT(*)                                                     















   FROM Web_Link                                                                     















  END                          







    END                                                                                    







 SET NOCOUNT OFF;                                                                                      



   END TRY                                                                                      







   BEGIN CATCH                                                                                              







   --There was an error                                                                                              







    exec sp_error_handler                                                                                              



    IF @@TRANCOUNT>0                                                                                              



    ROLLBACK                                                                                               







    RETURN -101                                    



  END CATCH                                                                                              



  RETURN 0                                                                                      







END


GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateVillage]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_UpdateVillage]
(
@Villageid int = null
,@tmpVillageID int =null
,@TigerReserveID int = null
,@Village_Name nvarchar(100)=null 
,@Agriculture_Land decimal(18, 2)
,@Population varchar(50) = null
,@Residential_property decimal(18,2) = null
,@Total_Standing_Trees int = null
,@Total_Livestock int = null
,@Relocated_from nvarchar(50) = null
,@Relocated_place nvarchar(50) = null
,@Total_well int = null
,@Other_Assets varchar(max) = null
,@Current_location_Latitude varchar(50) = null
,@Current_location_Longitude varchar(50) = null
,@location_Latitude_From varchar(50) = null
,@location_Longitude_From varchar(50) = null
,@Submitedby int = null
,@LastUpdatedby int = null
,@StatusID int=null
,@Stateid int = null
,@Animal_Details AnimalType READONLY 
)
AS
Begin
Declare @id int
if (@StatusID =3)

	begin
	UPDATE [dbo].[Tbl_village]
	SET 
      [TigerReserveID] =@TigerReserveID
      ,[Village_Name] = @Village_Name
      ,[Agriculture_Land] =@Agriculture_Land
      ,[Population] = @Population
      ,[Residential_property] = @Residential_property
      ,[Total_Standing_Trees] =@Total_Standing_Trees
      ,[Total_Livestock] =@Total_Livestock
      ,[Relocated_from] =@Relocated_from
      ,[Relocated_place] =@Relocated_place
      ,[Total_well] =@Total_well
      ,[Other_Assets] =@Other_Assets
      ,[Current_location_Latitude] =@Current_location_Latitude
      ,[Current_location_Longitude] = @Current_location_Longitude
      ,[location_Latitude_From] = @location_Latitude_From
      ,[location_Longitude_From] = @location_Longitude_From
     
     
      ,[LastUpdatedby] =@LastUpdatedby
      ,[LastUpdateDate] = GETDATE()
	  ,[Stateid]=@Stateid
      WHERE TempVillageid = @tmpVillageID
	  set @id=@tmpVillageID
		
	  Delete from Tbl_Village_Animals where villageid=@id
    Insert into Tbl_Village_Animals (villageid,Animalid,TotalAnimal)
    select @id, Animalid,TotalAnimal from @Animal_Details

	end

	else 

	begin
	  INSERT INTO [dbo].[Tbl_village]([Villageid],[TigerReserveID],[Village_Name],[Agriculture_Land],[Population],[Residential_property]
   ,[Total_Standing_Trees],[Total_Livestock],[Relocated_from],[Relocated_place],[Total_well],[Other_Assets],[Current_location_Latitude]
   ,[Current_location_Longitude],[location_Latitude_From],[location_Longitude_From],[Submitedby],[SubmitedDate],[Status],[Stateid]
	 )
	VALUES
	(@Villageid,@TigerReserveID,@Village_Name,@Agriculture_Land,@Population,@Residential_property,@Total_Standing_Trees
	,@Total_Livestock,@Relocated_from,@Relocated_place,@Total_well,@Other_Assets,@Current_location_Latitude,@Current_location_Longitude
	,@location_Latitude_From,@location_Longitude_From,@Submitedby,GETDATE(),3,@Stateid)
   
    set @id=SCOPE_IDENTITY()
    Insert into Tbl_Village_Animals (villageid,Animalid,TotalAnimal)
    select @id, Animalid,TotalAnimal from @Animal_Details

	end
end

GO
/****** Object:  StoredProcedure [dbo].[Update_User_TigerReserve_Permission]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Update_User_TigerReserve_Permission]
(
@StrTigerReserve nvarchar(500),
@Userid int
)
AS
Begin
Declare  @Tab Table
(
TigerReserverID int
)

Insert into @Tab
select * from dbo.[fnSplitString](@StrTigerReserve,',')

Delete from UserPermission where Userid=@Userid

Insert into UserPermission(Userid,TigerReserveid)
  select @Userid,TigerReserverID from @Tab


End

GO
/****** Object:  StoredProcedure [dbo].[USP_get_Banner]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_get_Banner]                  

(                      

 @lang_id int=null,    
 @StateID int=null,
 @Tigerreserveid int=null,                  

 @module_id int                      

)                      

                      

AS                                  

BEGIN                                    

    BEGIN TRY                                

                                

     SET NOCOUNT ON;                           

          

       if @lang_id=1

       BEGIN                    

  SELECT TOP 10 Link_Id,Module_Id,Image_Name,name,alt_tag                       

  FROM Web_Link                      

  WHERE Module_Id=@module_id                   
  and Status_Id=5 and StateID=@StateID and Tigerreserveid=@Tigerreserveid

  ORDER BY coalesce(Rec_Update_Date,Rec_Insert_Date) desc   

  END  

  else

  BEGIN

   SELECT TOP 10 Link_Id,Module_Id,Image_Name,Name_Reg as name,AltTag_Reg as alt_tag                       

  FROM Web_Link                      

  WHERE Module_Id=@module_id    

  and Status_Id=5 and StateID=@StateID and Tigerreserveid=@Tigerreserveid

  ORDER BY coalesce(Rec_Update_Date,Rec_Insert_Date) desc   

  

  END               

                       

     SET NOCOUNT OFF;                             

                                

     END TRY                                    

                                      

  BEGIN CATCH                                    

   --There was an error                                    

   EXEC sp_error_handler                                    

   IF @@TRANCOUNT>0                                    

   ROLLBACK                                     

   RETURN -101                                    

  END CATCH                                    

 RETURN 0                                      

                                

END


GO
/****** Object:  StoredProcedure [dbo].[USP_GetCategory]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetCategory] 

@StateID int,

@TigerReserveID int ,

@LangID int=null    

as      

BEGIN      


With T    

As    

(    

select row_number() over(partition by CategoryId order by GalleryId desc) as RankID,    

CategoryId,MediaTypeId,GalleryId,ImageName from PhotoGallery  where StatusId=5  and StateID=@StateID and TigerReserveid=@TigerReserveID

),    

 T1    

As    

(    

select CatName,CategoryId from Category  where StatusId=5 and StateID=@StateID and TigerReserveid=@TigerReserveID 

)    

    

select * from T join T1 on T1.CategoryId=T.CategoryId      

 and  T.RankID<  2    

    

END    

  

  




GO
/****** Object:  StoredProcedure [dbo].[USP_GetFrontMenu_Root]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[USP_GetFrontMenu_Root]                                 

(                                    

 @link_id INT,                                    

 @lang_id INT                                    

)                                    

AS                                      

 BEGIN                                       

 SET NOCOUNT ON;                                      

   SELECT link_id,position_id,link_type_id as linktypeid, replace(convert(char(11),[dbo].GetLastUpdatedCMS(@link_id),106),' ','-')as Last_update,name,Browser_Title,link_parent_id,  

   [dbo].GetParentName(link_parent_id)as parent,link_level,link_order ,UrlName,     

    [Details],Meta_Keywords,Mate_Description,Page_Title,[dbo].[GetChildCounter](link_id)as counter_Child,MetaLanguage,MetaTitle                                    

   FROM Web_Link                              

   WHERE link_id=@link_id AND [LANG_ID]=@lang_Id                                    

   ORDER BY link_order                                      

 SET NOCOUNT OFF;                                       

 END     

GO
/****** Object:  StoredProcedure [dbo].[USP_GetFrontMenuSubMenu_Root]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
CREATE PROC [dbo].[USP_GetFrontMenuSubMenu_Root]         
(                          
                           
 @link_parent_id int=null,                          
 @position_id int=null,                        
 @lang_id int=null                          
)                          
AS                            
 BEGIN                             
 SET NOCOUNT ON;                            
        
  if exists(select * from Web_Link where Link_Parent_Id=@link_parent_id)      
    begin      
   SELECT Link_Id,name,Link_Type_Id,url,File_Name,[dbo].GetParentName(Link_Parent_Id) AS ParentName,Position_Id,Link_Parent_Id,Link_Level,Link_Order,UrlName -- PlaceholderOne as Url_Name                           
  FROM Web_Link                           
  where Link_Parent_Id=@link_parent_id                          
  AND [Lang_Id]=@lang_id                          
  AND Position_Id=@position_id  --and Link_Id not in(31,279,198,200)                   
  AND Status_Id=5   --StatusID=6 for approved menu                   
  ORDER BY Link_Order      
  end      
    else      
      begin      
       SELECT Link_Id,name,Link_Type_Id,url,File_Name,[dbo].GetParentName(Link_Parent_Id) AS ParentName,Position_Id,Link_Parent_Id,Link_Level,Link_Order,UrlName -- PlaceholderOne as Url_Name                           
  FROM Web_Link                           
  where Link_Parent_Id=(select Link_Parent_Id from Web_Link where Link_Id=@link_parent_id)                        
  AND [Lang_Id]=@lang_id  --and Link_Id not in(31,279,198,200)              
  AND Position_Id=@position_id                    
  AND Status_Id=5   --StatusID=6 for approved menu                   
  ORDER BY Link_Order      
      end      
           
                        
 SET NOCOUNT OFF;                             
 END        



GO
/****** Object:  StoredProcedure [dbo].[usp_GetPhotoGalleryImage]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetPhotoGalleryImage]           
(        
@PageIndex int,        
@PageSize int,  
@StateID int,
@TigerReserveID int ,     
@CategoryID int=null,       
@RecordCount int output       
)        
as            
begin          
        
SELECT ROW_NUMBER() OVER                                                      
    (                                                  
    ORDER BY [galleryid] desc                                                   
    )as RowNumber,[galleryid],alttag,Title,              
   Description,ImageName,[Filename]        
           
    INTO #Results                                                      
    FROM PhotoGallery where CategoryID=@CategoryID  and statusid=5                                          
                                   
    SELECT @RecordCount = COUNT(*)                                                      
    FROM #Results                                                     
                                                 
    SELECT * FROM #Results                                                      
    WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1                                                      
                                                 
    DROP TABLE #Results                     
             
end 
GO
/****** Object:  StoredProcedure [dbo].[usp_getTigerReserveForMap]    Script Date: 12/16/2017 11:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_getTigerReserveForMap]

As
	BEGIN
		select TigerReserveid,TigerReserveName,latitude,longitude,StateID from Tbl_TigerReserve
	END
GO
USE [master]
GO
ALTER DATABASE [NTCA_MIS] SET  READ_WRITE 
GO

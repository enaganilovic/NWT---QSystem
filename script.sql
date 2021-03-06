USE [master]
GO
/****** Object:  Database [QuestionSystem]    Script Date: 17.3.2015 23:51:20 ******/
CREATE DATABASE [QuestionSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuestinSystem', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuestinSystem.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuestinSystem_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuestinSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuestionSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuestionSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuestionSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuestionSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuestionSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuestionSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuestionSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuestionSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuestionSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuestionSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuestionSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuestionSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuestionSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuestionSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuestionSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuestionSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuestionSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuestionSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuestionSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuestionSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuestionSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuestionSystem] SET  MULTI_USER 
GO
ALTER DATABASE [QuestionSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuestionSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuestionSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuestionSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuestionSystem]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Correct] [bit] NOT NULL,
	[Question_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Answers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Archives]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Archives](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[brojBodova] [real] NOT NULL,
	[polozen] [bit] NOT NULL,
	[mentor_Id] [nvarchar](128) NULL,
	[test_ID] [int] NULL,
	[user_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Archives] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Course_ID] [int] NULL,
	[ProfilePicture] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseGroups]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseGroups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.CourseGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseGroup_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FinishedTests]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinishedTests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Question_ID] [int] NULL,
	[Test_ID] [int] NULL,
	[User_Id] [nvarchar](128) NULL,
	[CorrectAnswer_ID] [int] NULL,
	[IsCorrect] [bit] NOT NULL,
	[NumberOfPoints] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Creator_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.FinishedTests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[GroupTest_ID] [int] NULL,
	[CourseGroup_ID] [int] NULL,
	[Creator_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Groups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupTests]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupTests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.GroupTests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Activate] [bit] NOT NULL,
	[Receiver_Id] [nvarchar](128) NULL,
	[Sender_Id] [nvarchar](128) NULL,
	[Group_ID] [int] NULL,
	[Test_ID] [int] NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Notifications] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Test_ID] [int] NULL,
	[Points] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Questions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test_Group]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Group](
	[TestId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Test_Group] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tests]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Creator_Id] [nvarchar](128) NULL,
	[GroupTest_ID] [int] NULL,
	[DateTime] [datetime] NOT NULL,
	[Duration] [int] NOT NULL,
	[Points] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Tests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Group]    Script Date: 17.3.2015 23:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Group](
	[UserId] [nvarchar](128) NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.User_Group] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Question_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Question_ID] ON [dbo].[Answers]
(
	[Question_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_mentor_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_mentor_Id] ON [dbo].[Archives]
(
	[mentor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_test_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_test_ID] ON [dbo].[Archives]
(
	[test_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_user_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_user_Id] ON [dbo].[Archives]
(
	[user_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[AspNetUserClaims]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Course_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Course_ID] ON [dbo].[AspNetUsers]
(
	[Course_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseGroup_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_CourseGroup_ID] ON [dbo].[Courses]
(
	[CourseGroup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CorrectAnswer_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_CorrectAnswer_ID] ON [dbo].[FinishedTests]
(
	[CorrectAnswer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Creator_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Creator_Id] ON [dbo].[FinishedTests]
(
	[Creator_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Question_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Question_ID] ON [dbo].[FinishedTests]
(
	[Question_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Test_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Test_ID] ON [dbo].[FinishedTests]
(
	[Test_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[FinishedTests]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseGroup_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_CourseGroup_ID] ON [dbo].[Groups]
(
	[CourseGroup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Creator_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Creator_Id] ON [dbo].[Groups]
(
	[Creator_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupTest_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_GroupTest_ID] ON [dbo].[Groups]
(
	[GroupTest_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Group_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Group_ID] ON [dbo].[Notifications]
(
	[Group_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Receiver_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Receiver_Id] ON [dbo].[Notifications]
(
	[Receiver_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Sender_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Sender_Id] ON [dbo].[Notifications]
(
	[Sender_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Test_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Test_ID] ON [dbo].[Notifications]
(
	[Test_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Test_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Test_ID] ON [dbo].[Questions]
(
	[Test_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[Test_Group]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestId]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_TestId] ON [dbo].[Test_Group]
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Creator_Id]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_Creator_Id] ON [dbo].[Tests]
(
	[Creator_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupTest_ID]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_GroupTest_ID] ON [dbo].[Tests]
(
	[GroupTest_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[User_Group]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 17.3.2015 23:51:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[User_Group]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FinishedTests] ADD  DEFAULT ((0)) FOR [IsCorrect]
GO
ALTER TABLE [dbo].[FinishedTests] ADD  DEFAULT ((0)) FOR [NumberOfPoints]
GO
ALTER TABLE [dbo].[FinishedTests] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [DateTime]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Questions] ADD  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[Tests] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [DateTime]
GO
ALTER TABLE [dbo].[Tests] ADD  DEFAULT ((0)) FOR [Duration]
GO
ALTER TABLE [dbo].[Tests] ADD  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[Tests] ADD  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID]
GO
ALTER TABLE [dbo].[Archives]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Archives_dbo.AspNetUsers_mentor_Id] FOREIGN KEY([mentor_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Archives] CHECK CONSTRAINT [FK_dbo.Archives_dbo.AspNetUsers_mentor_Id]
GO
ALTER TABLE [dbo].[Archives]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Archives_dbo.AspNetUsers_user_Id] FOREIGN KEY([user_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Archives] CHECK CONSTRAINT [FK_dbo.Archives_dbo.AspNetUsers_user_Id]
GO
ALTER TABLE [dbo].[Archives]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Archives_dbo.Tests_test_ID] FOREIGN KEY([test_ID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[Archives] CHECK CONSTRAINT [FK_dbo.Archives_dbo.Tests_test_ID]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.Courses_Course_ID] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.Courses_Course_ID]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.CourseGroups_CourseGroup_ID] FOREIGN KEY([CourseGroup_ID])
REFERENCES [dbo].[CourseGroups] ([ID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.CourseGroups_CourseGroup_ID]
GO
ALTER TABLE [dbo].[FinishedTests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FinishedTests_dbo.Answers_CorrectAnswer_ID] FOREIGN KEY([CorrectAnswer_ID])
REFERENCES [dbo].[Answers] ([ID])
GO
ALTER TABLE [dbo].[FinishedTests] CHECK CONSTRAINT [FK_dbo.FinishedTests_dbo.Answers_CorrectAnswer_ID]
GO
ALTER TABLE [dbo].[FinishedTests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FinishedTests_dbo.AspNetUsers_Creator_Id] FOREIGN KEY([Creator_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[FinishedTests] CHECK CONSTRAINT [FK_dbo.FinishedTests_dbo.AspNetUsers_Creator_Id]
GO
ALTER TABLE [dbo].[FinishedTests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FinishedTests_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[FinishedTests] CHECK CONSTRAINT [FK_dbo.FinishedTests_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[FinishedTests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FinishedTests_dbo.Questions_Question_ID] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[FinishedTests] CHECK CONSTRAINT [FK_dbo.FinishedTests_dbo.Questions_Question_ID]
GO
ALTER TABLE [dbo].[FinishedTests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FinishedTests_dbo.Tests_Test_ID] FOREIGN KEY([Test_ID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[FinishedTests] CHECK CONSTRAINT [FK_dbo.FinishedTests_dbo.Tests_Test_ID]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.AspNetUsers_Creator_Id] FOREIGN KEY([Creator_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.AspNetUsers_Creator_Id]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.CourseGroups_CourseGroup_ID] FOREIGN KEY([CourseGroup_ID])
REFERENCES [dbo].[CourseGroups] ([ID])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.CourseGroups_CourseGroup_ID]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.GroupTests_GroupTest_ID] FOREIGN KEY([GroupTest_ID])
REFERENCES [dbo].[GroupTests] ([ID])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.GroupTests_GroupTest_ID]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notifications_dbo.AspNetUsers_Receiver_Id] FOREIGN KEY([Receiver_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_dbo.Notifications_dbo.AspNetUsers_Receiver_Id]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notifications_dbo.AspNetUsers_Sender_Id] FOREIGN KEY([Sender_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_dbo.Notifications_dbo.AspNetUsers_Sender_Id]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notifications_dbo.Groups_Group_ID] FOREIGN KEY([Group_ID])
REFERENCES [dbo].[Groups] ([ID])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_dbo.Notifications_dbo.Groups_Group_ID]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notifications_dbo.Tests_Test_ID] FOREIGN KEY([Test_ID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_dbo.Notifications_dbo.Tests_Test_ID]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Questions_dbo.Tests_Test_ID] FOREIGN KEY([Test_ID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_dbo.Questions_dbo.Tests_Test_ID]
GO
ALTER TABLE [dbo].[Test_Group]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Test_Group_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Test_Group] CHECK CONSTRAINT [FK_dbo.Test_Group_dbo.Groups_GroupId]
GO
ALTER TABLE [dbo].[Test_Group]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Test_Group_dbo.Tests_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Test_Group] CHECK CONSTRAINT [FK_dbo.Test_Group_dbo.Tests_TestId]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tests_dbo.AspNetUsers_Creator_Id] FOREIGN KEY([Creator_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_dbo.Tests_dbo.AspNetUsers_Creator_Id]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tests_dbo.GroupTests_GroupTest_ID] FOREIGN KEY([GroupTest_ID])
REFERENCES [dbo].[GroupTests] ([ID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_dbo.Tests_dbo.GroupTests_GroupTest_ID]
GO
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_dbo.User_Group_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_dbo.User_Group_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_dbo.User_Group_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_dbo.User_Group_dbo.Groups_GroupId]
GO
USE [master]
GO
ALTER DATABASE [QuestionSystem] SET  READ_WRITE 
GO

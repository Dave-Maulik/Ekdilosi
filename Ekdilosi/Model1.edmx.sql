
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/20/2020 10:20:05
-- Generated from EDMX file: C:\Users\maulik.dave\source\repos\Ekdilosi\Ekdilosi\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Ekdiloshi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserEvents_Admin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvents] DROP CONSTRAINT [FK_UserEvents_Admin];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEvents_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvents] DROP CONSTRAINT [FK_UserEvents_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEvents_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvents] DROP CONSTRAINT [FK_UserEvents_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admins];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UserEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserEvents];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [Admin_Id] int IDENTITY(1,1) NOT NULL,
    [Admin_Name] varchar(20)  NOT NULL,
    [Admin_Email] varchar(30)  NOT NULL,
    [Admin_Password] varchar(8)  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Event_Id] int IDENTITY(1,1) NOT NULL,
    [Event_Name] varchar(20)  NULL,
    [Event_Discription] varchar(80)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [User_Id] int IDENTITY(1,1) NOT NULL,
    [User_Name] varchar(25)  NOT NULL,
    [User_Email] varchar(25)  NOT NULL,
    [User_Password] varchar(8)  NOT NULL
);
GO

-- Creating table 'UserEvents'
CREATE TABLE [dbo].[UserEvents] (
    [Assign_Id] int IDENTITY(1,1) NOT NULL,
    [Admin_Id] int  NOT NULL,
    [User_Id] int  NOT NULL,
    [Event_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Admin_Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([Admin_Id] ASC);
GO

-- Creating primary key on [Event_Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Event_Id] ASC);
GO

-- Creating primary key on [User_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([User_Id] ASC);
GO

-- Creating primary key on [Assign_Id] in table 'UserEvents'
ALTER TABLE [dbo].[UserEvents]
ADD CONSTRAINT [PK_UserEvents]
    PRIMARY KEY CLUSTERED ([Assign_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Admin_Id] in table 'UserEvents'
ALTER TABLE [dbo].[UserEvents]
ADD CONSTRAINT [FK_UserEvents_Admin]
    FOREIGN KEY ([Admin_Id])
    REFERENCES [dbo].[Admins]
        ([Admin_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEvents_Admin'
CREATE INDEX [IX_FK_UserEvents_Admin]
ON [dbo].[UserEvents]
    ([Admin_Id]);
GO

-- Creating foreign key on [Event_Id] in table 'UserEvents'
ALTER TABLE [dbo].[UserEvents]
ADD CONSTRAINT [FK_UserEvents_Event]
    FOREIGN KEY ([Event_Id])
    REFERENCES [dbo].[Events]
        ([Event_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEvents_Event'
CREATE INDEX [IX_FK_UserEvents_Event]
ON [dbo].[UserEvents]
    ([Event_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserEvents'
ALTER TABLE [dbo].[UserEvents]
ADD CONSTRAINT [FK_UserEvents_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([User_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEvents_User'
CREATE INDEX [IX_FK_UserEvents_User]
ON [dbo].[UserEvents]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
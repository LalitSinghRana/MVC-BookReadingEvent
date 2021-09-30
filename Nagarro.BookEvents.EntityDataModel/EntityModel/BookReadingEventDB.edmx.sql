
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2021 18:11:53
-- Generated from EDMX file: C:\Users\lalitrana\Desktop\New folder\BookReadingEvent\Nagarro.BookEvents.EntityDataModel\EntityModel\BookReadingEventDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookReadingEventsEntities];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Comments_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Invite_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invite] DROP CONSTRAINT [FK_Invite_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_Invite_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invite] DROP CONSTRAINT [FK_Invite_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event];
GO
IF OBJECT_ID(N'[dbo].[Invite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invite];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [EventId] int  NOT NULL,
    [Comment1] nvarchar(500)  NOT NULL,
    [Date] datetime  NULL,
    [UserName] nvarchar(50)  NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Location] nvarchar(100)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [DurationInHours] int  NULL,
    [Description] nvarchar(50)  NULL,
    [OtherDetails] nvarchar(500)  NULL,
    [UserId] int  NOT NULL,
    [TotalInvites] int  NULL,
    [Type] nvarchar(50)  NOT NULL,
    [InviteEmails] nvarchar(500)  NULL
);
GO

-- Creating table 'Invites'
CREATE TABLE [dbo].[Invites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Password] nvarchar(100)  NOT NULL,
    [Role] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invites'
ALTER TABLE [dbo].[Invites]
ADD CONSTRAINT [PK_Invites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EventId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_Event]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_Event'
CREATE INDEX [IX_FK_Comments_Event]
ON [dbo].[Comments]
    ([EventId]);
GO

-- Creating foreign key on [UserId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_User'
CREATE INDEX [IX_FK_Comments_User]
ON [dbo].[Comments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_User'
CREATE INDEX [IX_FK_Event_User]
ON [dbo].[Events]
    ([UserId]);
GO

-- Creating foreign key on [EventId] in table 'Invites'
ALTER TABLE [dbo].[Invites]
ADD CONSTRAINT [FK_Invite_Event]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Invite_Event'
CREATE INDEX [IX_FK_Invite_Event]
ON [dbo].[Invites]
    ([EventId]);
GO

-- Creating foreign key on [UserId] in table 'Invites'
ALTER TABLE [dbo].[Invites]
ADD CONSTRAINT [FK_Invite_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Invite_User'
CREATE INDEX [IX_FK_Invite_User]
ON [dbo].[Invites]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
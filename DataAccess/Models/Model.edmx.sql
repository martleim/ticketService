
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/06/2016 17:30:53
-- Generated from EDMX file: C:\Users\MartinL\Documents\Visual Studio 2015\Projects\Tickets\DataAccess\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [tickets];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EventSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionSet] DROP CONSTRAINT [FK_EventSession];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTransactions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionSet] DROP CONSTRAINT [FK_UserTransactions];
GO
IF OBJECT_ID(N'[dbo].[FK_EventTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSet] DROP CONSTRAINT [FK_EventTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_SessionTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSet] DROP CONSTRAINT [FK_SessionTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_SessionTicketSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSaleSet] DROP CONSTRAINT [FK_SessionTicketSale];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketTicketSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSaleSet] DROP CONSTRAINT [FK_TicketTicketSale];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionTicketSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSaleSet] DROP CONSTRAINT [FK_TransactionTicketSale];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[EventSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventSet];
GO
IF OBJECT_ID(N'[dbo].[SessionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SessionSet];
GO
IF OBJECT_ID(N'[dbo].[TicketSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketSet];
GO
IF OBJECT_ID(N'[dbo].[TransactionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionSet];
GO
IF OBJECT_ID(N'[dbo].[TicketSaleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketSaleSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nchar(50)  NOT NULL,
    [Password] binary(64)  NOT NULL
);
GO

-- Creating table 'EventSet'
CREATE TABLE [dbo].[EventSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SessionSet'
CREATE TABLE [dbo].[SessionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [EventId] int  NOT NULL,
    [Price] float  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [SpacesAvailable] smallint  NOT NULL
);
GO

-- Creating table 'TicketSet'
CREATE TABLE [dbo].[TicketSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [EventId] int  NOT NULL,
    [SessionId] int  NOT NULL
);
GO

-- Creating table 'TransactionSet'
CREATE TABLE [dbo].[TransactionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [TimeStamp] datetime  NOT NULL
);
GO

-- Creating table 'TicketSaleSet'
CREATE TABLE [dbo].[TicketSaleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SessionId] int  NOT NULL,
    [TicketId] int  NOT NULL,
    [TransactionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventSet'
ALTER TABLE [dbo].[EventSet]
ADD CONSTRAINT [PK_EventSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [PK_SessionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [PK_TicketSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [PK_TransactionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TicketSaleSet'
ALTER TABLE [dbo].[TicketSaleSet]
ADD CONSTRAINT [PK_TicketSaleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EventId] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [FK_EventSession]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[EventSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventSession'
CREATE INDEX [IX_FK_EventSession]
ON [dbo].[SessionSet]
    ([EventId]);
GO

-- Creating foreign key on [UserId] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [FK_UserTransactions]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTransactions'
CREATE INDEX [IX_FK_UserTransactions]
ON [dbo].[TransactionSet]
    ([UserId]);
GO

-- Creating foreign key on [EventId] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [FK_EventTicket]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[EventSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventTicket'
CREATE INDEX [IX_FK_EventTicket]
ON [dbo].[TicketSet]
    ([EventId]);
GO

-- Creating foreign key on [SessionId] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [FK_SessionTicket]
    FOREIGN KEY ([SessionId])
    REFERENCES [dbo].[SessionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionTicket'
CREATE INDEX [IX_FK_SessionTicket]
ON [dbo].[TicketSet]
    ([SessionId]);
GO

-- Creating foreign key on [SessionId] in table 'TicketSaleSet'
ALTER TABLE [dbo].[TicketSaleSet]
ADD CONSTRAINT [FK_SessionTicketSale]
    FOREIGN KEY ([SessionId])
    REFERENCES [dbo].[SessionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionTicketSale'
CREATE INDEX [IX_FK_SessionTicketSale]
ON [dbo].[TicketSaleSet]
    ([SessionId]);
GO

-- Creating foreign key on [TicketId] in table 'TicketSaleSet'
ALTER TABLE [dbo].[TicketSaleSet]
ADD CONSTRAINT [FK_TicketTicketSale]
    FOREIGN KEY ([TicketId])
    REFERENCES [dbo].[TicketSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketTicketSale'
CREATE INDEX [IX_FK_TicketTicketSale]
ON [dbo].[TicketSaleSet]
    ([TicketId]);
GO

-- Creating foreign key on [TransactionId] in table 'TicketSaleSet'
ALTER TABLE [dbo].[TicketSaleSet]
ADD CONSTRAINT [FK_TransactionTicketSale]
    FOREIGN KEY ([TransactionId])
    REFERENCES [dbo].[TransactionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionTicketSale'
CREATE INDEX [IX_FK_TransactionTicketSale]
ON [dbo].[TicketSaleSet]
    ([TransactionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
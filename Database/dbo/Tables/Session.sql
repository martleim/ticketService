CREATE TABLE [dbo].[Session] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [DateStart]       DATETIME       NOT NULL,
    [DateEnd]         DATETIME       NOT NULL,
    [Name]            NVARCHAR (MAX) NOT NULL,
    [EventId]         INT            NOT NULL,
    [Price]           FLOAT (53)     NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [SpacesAvailable] SMALLINT       NOT NULL,
    CONSTRAINT [PK_SessionSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventSession] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EventSession]
    ON [dbo].[Session]([EventId] ASC);


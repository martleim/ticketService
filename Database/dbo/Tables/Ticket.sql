CREATE TABLE [dbo].[Ticket] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [EventId]     INT            NOT NULL,
    [SessionId]   INT            NULL,
    CONSTRAINT [PK_TicketSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventTicket] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_SessionTicket]
    ON [dbo].[Ticket]([SessionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EventTicket]
    ON [dbo].[Ticket]([EventId] ASC);


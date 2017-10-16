CREATE TABLE [dbo].[TicketSale] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [SessionId]     INT NOT NULL,
    [TicketId]      INT NOT NULL,
    [TransactionId] INT NOT NULL,
    CONSTRAINT [PK_TicketSaleSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SessionTicketSale] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Session] ([Id]),
    CONSTRAINT [FK_TicketTicketSale] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Ticket] ([Id]),
    CONSTRAINT [FK_TransactionTicketSale] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transaction] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_TransactionTicketSale]
    ON [dbo].[TicketSale]([TransactionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_TicketTicketSale]
    ON [dbo].[TicketSale]([TicketId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_SessionTicketSale]
    ON [dbo].[TicketSale]([SessionId] ASC);


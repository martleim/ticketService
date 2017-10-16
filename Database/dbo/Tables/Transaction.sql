CREATE TABLE [dbo].[Transaction] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [UserId]    INT      NOT NULL,
    [TimeStamp] DATETIME NOT NULL,
    CONSTRAINT [PK_TransactionSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserTransactions] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUser] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_UserTransactions]
    ON [dbo].[Transaction]([UserId] ASC);


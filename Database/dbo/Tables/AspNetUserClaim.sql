CREATE TABLE [dbo].[AspNetUserClaim] (
    [Id]         INT NOT NULL IDENTITY,
    [UserId]     INT NOT NULL,
    [ClaimType]  NTEXT          NULL,
    [ClaimValue] NTEXT          NULL,
    CONSTRAINT [PK_ASPNETUSERCLAIM] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AspNetUserClaim_fk0] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUser] ([Id]) ON UPDATE CASCADE
);


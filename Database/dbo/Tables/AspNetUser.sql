﻿CREATE TABLE [dbo].[AspNetUser] (
    [Id]       INT NOT NULL IDENTITY,
    [UserName] NVARCHAR (256) NOT NULL,
	[Password] NVARCHAR (256) NOT NULL,
    [Updated] DATETIME NOT NULL, 
    CONSTRAINT [PK_ASPNETUSER] PRIMARY KEY CLUSTERED ([Id] ASC)
);

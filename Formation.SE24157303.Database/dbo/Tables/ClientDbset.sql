CREATE TABLE [dbo].[ClientDbset] (
    [Id]                       INT            IDENTITY (1, 1) NOT NULL,
    [Age]                      INT            NOT NULL,
    [Nom]                      NVARCHAR (MAX) NOT NULL,
    [Email]                    NVARCHAR (MAX) NOT NULL,
    [DateCreation]             DATETIME2 (7)  NOT NULL,
    [DateDerniereModification] DATETIME2 (7)  NOT NULL,
    [UserCreation]             NVARCHAR (MAX) NOT NULL,
    [UserModification]         NVARCHAR (MAX) NOT NULL,
    [ClientType]               INT            DEFAULT ((0)) NOT NULL,
    [IdentifiantNationale]     INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ClientDbset] PRIMARY KEY CLUSTERED ([Id] ASC)
);


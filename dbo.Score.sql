CREATE TABLE [dbo].[Score] (
    [Id]         INT        NOT NULL IDENTITY,
    [Nick]       NCHAR (50) NOT NULL,
    [Bombs]      INT        NOT NULL,
    [Difficulty] INT        NOT NULL, 
    CONSTRAINT [PK_Score] PRIMARY KEY ([Id])
);


CREATE TABLE [dbo].[Pessoas] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Nome]       NVARCHAR (MAX) NOT NULL,
    [Nascimento] DATETIME       NOT NULL,
    [CPF]        NVARCHAR (MAX) NOT NULL,
    [CEP]        NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Pessoas] PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[Table_fp] (
    [Id]          INT             NOT NULL,
    [fp_template] NVARCHAR (3000) NOT NULL,
    [time_registered] TIMESTAMP NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


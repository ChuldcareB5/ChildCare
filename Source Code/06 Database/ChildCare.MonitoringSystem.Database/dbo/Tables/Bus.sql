CREATE TABLE [dbo].[Bus] (
    [BusId]         INT           IDENTITY (1, 1) NOT NULL,
    [BusName]       VARCHAR (100) NOT NULL,
    [BusDriverName] VARCHAR (100) NOT NULL,
    [CreatedBy]     INT           NOT NULL,
    [CreatedOn]     DATETIME      NOT NULL,
    [UpdatedBy]     INT           NOT NULL,
    [UpdatedOn]     DATETIME      NOT NULL,
    [IsDeleted]     BIT           NOT NULL,
    CONSTRAINT [PK_Bus] PRIMARY KEY CLUSTERED ([BusId] ASC)
);














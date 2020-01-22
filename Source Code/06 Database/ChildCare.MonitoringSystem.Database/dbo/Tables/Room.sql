CREATE TABLE [dbo].[Room] (
    [RoomId]    INT           NOT NULL,
    [RoomName]  VARCHAR (100) NOT NULL,
    [CreatedBy] INT           NOT NULL,
    [CreatedOn] DATETIME      NOT NULL,
    [UpdatedBy] INT           NOT NULL,
    [UpdatedOn] DATETIME      NOT NULL,
    [IsDeleted] BIT           NOT NULL,
    CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED ([RoomId] ASC)
);


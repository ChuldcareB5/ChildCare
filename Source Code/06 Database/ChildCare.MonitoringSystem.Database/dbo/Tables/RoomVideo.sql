CREATE TABLE [dbo].[RoomVideo] (
    [RoomVideoId] INT           NOT NULL,
    [RoomVideo]   VARCHAR (300) NOT NULL,
    [RoomId]      INT           NOT NULL,
    [CreatedBy]   INT           NOT NULL,
    [CreatedOn]   DATETIME      NOT NULL,
    [UpdatedBy]   INT           NOT NULL,
    [UpdatedOn]   DATETIME      NOT NULL,
    [IsDeleted]   BIT           NOT NULL,
    CONSTRAINT [PK_RoomVideo] PRIMARY KEY CLUSTERED ([RoomVideoId] ASC),
    CONSTRAINT [FK_RoomVideo_Room] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([RoomId])
);




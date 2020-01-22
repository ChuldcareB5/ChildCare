CREATE TABLE [dbo].[RoomSchedule] (
    [RoomScheduleId]      INT           IDENTITY (1, 1) NOT NULL,
    [TeacherId]           INT           NOT NULL,
    [RoomScheduleDate]    DATE          NOT NULL,
    [RoomScheduleTime]    TIME (7)      NOT NULL,
    [RoomScheduleSubject] VARCHAR (100) NOT NULL,
    [StudentId]           INT           NOT NULL,
    [RoomId]              INT           NOT NULL,
    [CreatedBy]           INT           NOT NULL,
    [CreatedOn]           DATETIME      NOT NULL,
    [UpdatedBy]           INT           NOT NULL,
    [UpdatedOn]           DATETIME      NOT NULL,
    [IsDeleted]           BIT           NOT NULL,
    CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED ([RoomScheduleId] ASC),
    CONSTRAINT [FK_RoomSchedule_Room] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([RoomId]),
    CONSTRAINT [FK_RoomSchedule_Student] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([StudentId]),
    CONSTRAINT [FK_RoomSchedule_User] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[User] ([UserId])
);


CREATE TABLE [dbo].[StudentBusSchedule] (
    [StudentBusScheduleId] INT      IDENTITY (1, 1) NOT NULL,
    [BusScheduleId]        INT      NOT NULL,
    [StudentId]            INT      NOT NULL,
    [CreatedBy]            INT      NOT NULL,
    [CreatedOn]            DATETIME NOT NULL,
    [UpdatedBy]            INT      NOT NULL,
    [UpdatedOn]            DATETIME NOT NULL,
    [IsDeleted]            BIT      NOT NULL,
    CONSTRAINT [PK_StudentBusSchedule] PRIMARY KEY CLUSTERED ([StudentBusScheduleId] ASC),
    CONSTRAINT [FK_StudentBusSchedule_BusSchedule1] FOREIGN KEY ([BusScheduleId]) REFERENCES [dbo].[BusSchedule] ([BusScheduleId]),
    CONSTRAINT [FK_StudentBusSchedule_Student] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([StudentId])
);












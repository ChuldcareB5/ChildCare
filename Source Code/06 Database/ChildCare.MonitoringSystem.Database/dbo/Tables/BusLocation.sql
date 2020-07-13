CREATE TABLE [dbo].[BusLocation] (
    [BusLocationId] INT        IDENTITY (1, 1) NOT NULL,
    [BusId]         INT        NOT NULL,
    [BusScheduleId] INT        NOT NULL,
    [LocationTime]  DATETIME   NOT NULL,
    [Longitute]     FLOAT (53) NOT NULL,
    [Latitude]      FLOAT (53) NOT NULL,
    [CreatedBy]     INT        NOT NULL,
    [CreatedOn]     DATETIME   NOT NULL,
    [UpdatedBy]     INT        NOT NULL,
    [UpdatedOn]     DATETIME   NOT NULL,
    [IsDeleted]     BIT        NOT NULL,
    CONSTRAINT [PK_BusLocation] PRIMARY KEY CLUSTERED ([BusLocationId] ASC),
    CONSTRAINT [FK_BusLocation_Bus] FOREIGN KEY ([BusId]) REFERENCES [dbo].[Bus] ([BusId]),
    CONSTRAINT [FK_BusLocation_BusSchedule] FOREIGN KEY ([BusScheduleId]) REFERENCES [dbo].[BusSchedule] ([BusScheduleId])
);




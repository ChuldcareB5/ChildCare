CREATE TABLE [dbo].[BusSchedule] (
    [BusScheduleId]         INT           IDENTITY (1, 1) NOT NULL,
    [BusScheduleDriverName] VARCHAR (100) NOT NULL,
    [ToBusSchedule]         VARCHAR (100) NOT NULL,
    [FromBusSchedule]       VARCHAR (100) NOT NULL,
    [BusScheduleTime]       TIME (7)      NOT NULL,
    [BusScheduleDate]       DATE          NOT NULL,
    [BusId]                 INT           NOT NULL,
    [CreatedBy]             INT           NOT NULL,
    [CreatedOn]             DATETIME      NOT NULL,
    [UpdatedBy]             INT           NOT NULL,
    [UpdatedOn]             DATETIME      NOT NULL,
    [IsDeleted]             BIT           NOT NULL,
    CONSTRAINT [PK_BusSchedule] PRIMARY KEY CLUSTERED ([BusScheduleId] ASC),
    CONSTRAINT [FK_BusSchedule_Bus] FOREIGN KEY ([BusId]) REFERENCES [dbo].[Bus] ([BusId])
);


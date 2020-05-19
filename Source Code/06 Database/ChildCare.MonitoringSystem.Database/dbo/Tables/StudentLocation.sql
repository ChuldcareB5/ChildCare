CREATE TABLE [dbo].[StudentLocation] (
    [StudentLocationId] INT        IDENTITY (1, 1) NOT NULL,
    [StudentId]         INT        NOT NULL,
    [LocationTime]      DATETIME   NOT NULL,
    [Longitute]         FLOAT (53) NOT NULL,
    [Latitude]          FLOAT (53) NOT NULL,
    [CreatedBy]         INT        NOT NULL,
    [CreatedOn]         DATETIME   NOT NULL,
    [UpdatedBy]         INT        NOT NULL,
    [UpdatedOn]         DATETIME   NOT NULL,
    [IsDeleted]         BIT        NOT NULL,
    CONSTRAINT [PK_StudentLocation] PRIMARY KEY CLUSTERED ([StudentLocationId] ASC),
    CONSTRAINT [FK_StudentLocation_Student] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([StudentId])
);




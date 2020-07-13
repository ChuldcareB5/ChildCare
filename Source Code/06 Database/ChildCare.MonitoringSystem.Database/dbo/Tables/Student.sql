CREATE TABLE [dbo].[Student] (
    [StudentId]      INT           IDENTITY (1, 1) NOT NULL,
    [StudentName]    VARCHAR (100) NOT NULL,
    [StudentImg]     VARCHAR (200) NOT NULL,
    [StudentAddress] VARCHAR (200) NOT NULL,
    [StudentGender]  VARCHAR (100) NOT NULL,
    [StudentDob]     DATE          NOT NULL,
    [FatherName]     VARCHAR (100) NOT NULL,
    [MotherName]     VARCHAR (100) NOT NULL,
    [ParentId]       INT           NOT NULL,
    [Batch]          VARCHAR (100) NOT NULL,
    [CreatedBy]      INT           NOT NULL,
    [CreatedOn]      DATETIME      NOT NULL,
    [UpdatedBy]      INT           NOT NULL,
    [UpdatedOn]      DATETIME      NOT NULL,
    [IsDeleted]      BIT           NOT NULL,
    CONSTRAINT [PK_Kid] PRIMARY KEY CLUSTERED ([StudentId] ASC),
    CONSTRAINT [FK_Student_User] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[User] ([UserId])
);














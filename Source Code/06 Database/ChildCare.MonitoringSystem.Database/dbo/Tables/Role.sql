CREATE TABLE [dbo].[Role] (
    [RoleId]    INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]  VARCHAR (100) NOT NULL,
    [CreatedBy] INT           NOT NULL,
    [CreatedOn] DATETIME      NOT NULL,
    [UpdatedBy] INT           NOT NULL,
    [UpdatedOn] DATETIME      NOT NULL,
    [IsDeleted] BIT           NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


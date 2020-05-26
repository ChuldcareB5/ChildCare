CREATE TABLE [dbo].[UserRole] (
    [UserRoleId] INT      IDENTITY (1, 1) NOT NULL,
    [UserId]     INT      NOT NULL,
    [RoleId]     INT      NOT NULL,
    [CreatedBy]  INT      NOT NULL,
    [CreatedOn]  DATETIME NOT NULL,
    [UpdatedBy]  INT      NOT NULL,
    [UpdatedOn]  DATETIME NOT NULL,
    [IsDeleted]  BIT      NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);










GO
CREATE NONCLUSTERED INDEX [IX_UserRole]
    ON [dbo].[UserRole]([UserId] ASC);


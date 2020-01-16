CREATE TABLE [dbo].[User] (
    [UserId]       INT           IDENTITY (1, 1) NOT NULL,
    [UserName]     VARCHAR (100) NOT NULL,
    [UserEmail]    VARCHAR (100) NOT NULL,
    [UserPassword] VARCHAR (100) NOT NULL,
    [UserMobileNo] VARCHAR (12)  NOT NULL,
    [CreatedBy]    INT           NOT NULL,
    [CreatedOn]    DATETIME      NOT NULL,
    [UpdatedBy]    INT           NOT NULL,
    [UpdatedOn]    DATETIME      NOT NULL,
    [IsDeleted]    BIT           NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


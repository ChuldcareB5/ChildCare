CREATE TABLE [dbo].[MessageBoard] (
    [MessageBoardId] INT           IDENTITY (1, 1) NOT NULL,
    [ToMsg]          INT           NOT NULL,
    [FromMsg]        INT           NOT NULL,
    [MsgStatus]      INT           NOT NULL,
    [MsgDateTime]    DATETIME      NOT NULL,
    [Msg]            VARCHAR (500) NOT NULL,
    [CreatedBy]      INT           NOT NULL,
    [CreatedOn]      DATETIME      NOT NULL,
    [UpdatedBy]      INT           NOT NULL,
    [UpdatedOn]      DATETIME      NOT NULL,
    [IsDeleted]      BIT           NOT NULL,
    CONSTRAINT [PK_MessageBoard_1] PRIMARY KEY CLUSTERED ([MessageBoardId] ASC),
    CONSTRAINT [FK_MessageBoard_User] FOREIGN KEY ([ToMsg]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_MessageBoard_User1] FOREIGN KEY ([FromMsg]) REFERENCES [dbo].[User] ([UserId])
);
















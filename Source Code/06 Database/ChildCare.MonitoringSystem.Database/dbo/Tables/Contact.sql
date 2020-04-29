CREATE TABLE [dbo].[Contact] (
    [ContactId]       INT           IDENTITY (1, 1) NOT NULL,
    [ContactName]     VARCHAR (100) NOT NULL,
    [ContactEmail]    VARCHAR (100) NOT NULL,
    [ContactMobileNo] VARCHAR (12)  NOT NULL,
    [ContactMsg]      VARCHAR (500) NOT NULL,
    [CreatedBy]       INT           NOT NULL,
    [CreatedOn]       DATETIME      NOT NULL,
    [UpdatedBy]       INT           NOT NULL,
    [UpdatedOn]       DATETIME      NOT NULL,
    [IsDeleted]       BIT           NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([ContactId] ASC)
);




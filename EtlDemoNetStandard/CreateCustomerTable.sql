CREATE TABLE [dbo].[Customer] (
    [Id]                  INT           NOT NULL,
    [FirstName]           VARCHAR (50)  NULL,
    [LastName]            VARCHAR (50)  NULL,
    [Ssn]                 VARCHAR (11)  NULL,
    [DateOfBirth]         DATE		    NULL,
    [Address]             VARCHAR (100) NULL,
    [City]                VARCHAR (50)  NULL,
    [State]               VARCHAR (50)  NULL,
    [Zip]                 VARCHAR (10)  NULL,
    [MobilePhoneAreaCode] VARCHAR (3)   NULL,
    [MobilePhone]         VARCHAR (10)  NULL,
    [HomePhoneAreaCode]   VARCHAR (3)   NULL,
    [HomePhone]           VARCHAR (10)  NULL
);


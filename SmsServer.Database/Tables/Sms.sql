CREATE TABLE [dbo].[Sms]
(
	[Id] INT identity (1,1) NOT NULL PRIMARY KEY, 
    [PhoneNumber] VARCHAR(15) NOT NULL, 
    [Text] NVARCHAR(MAX) NULL, 
    [Status] INT NOT NULL, 
    [CreatedAt] DATETIME2(4) NOT NULL, 
    [SentAt] DATETIME2(4) NULL, 
    [StatusText] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Sms_Status] FOREIGN KEY ([Status]) REFERENCES [Status]([Id])
)

GO

CREATE INDEX [IX_Sms_Status] ON [dbo].[Sms] ([Status])
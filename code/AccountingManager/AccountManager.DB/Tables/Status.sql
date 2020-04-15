CREATE TABLE [dbo].[Status]
(
    [StatusID] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME2 NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [AccountID] INT NOT NULL, 
    CONSTRAINT [FK_Status_ToAccount] FOREIGN KEY ([AccountID]) REFERENCES [Account]([AccountID])
)

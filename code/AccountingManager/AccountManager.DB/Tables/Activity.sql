CREATE TABLE [dbo].[Activity]
(
    [ActivityID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Ourense] BIT NOT NULL DEFAULT 0, 
    [ActivityTypeID] INT NOT NULL,     
    CONSTRAINT [FK_Activity_ToActivityType] FOREIGN KEY ([ActivityTypeID]) REFERENCES [ActivityType]([ActivityTypeID])
)

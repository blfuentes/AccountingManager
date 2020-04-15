CREATE TABLE [dbo].[Activity]
(
    [ActivityID] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [ActivityTypeID] INT NOT NULL, 
    CONSTRAINT [FK_Activity_ToActivityType] FOREIGN KEY ([ActivityTypeID]) REFERENCES [ActivityType]([ActivityTypeID])
)

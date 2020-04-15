CREATE TABLE [dbo].[Movement]
(
    [MovementID] INT NOT NULL PRIMARY KEY, 
    [IsCredit] BIT NOT NULL, 
    [ActivityID] INT NOT NULL, 
    CONSTRAINT [FK_Movement_ToActivity] FOREIGN KEY ([ActivityID]) REFERENCES [Activity]([ActivityID])
)

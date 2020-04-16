CREATE TABLE [dbo].[Present]
(
    [PresentID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [IsReturned] BIT NOT NULL, 
    [MotiveID] INT NOT NULL, 
    [TargetID] INT NOT NULL, 
    CONSTRAINT [FK_Present_ToMotive] FOREIGN KEY ([MotiveID]) REFERENCES [Motive]([MotiveID]), 
    CONSTRAINT [FK_Present_ToTarget] FOREIGN KEY ([TargetID]) REFERENCES [Target]([TargetID])
)

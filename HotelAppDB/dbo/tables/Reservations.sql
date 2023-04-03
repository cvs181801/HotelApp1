CREATE TABLE [dbo].[Reservations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL, 
    [CheckedIn] BIT NOT NULL DEFAULT 0, 
    [GuestId] INT NOT NULL, 
    [ConfimationNumber] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [RoomId] INT NOT NULL, 
    [TotalCost] MONEY NOT NULL,
    CONSTRAINT [FK_Reservations_Rooms] FOREIGN KEY (RoomId) REFERENCES Rooms(Id),
    CONSTRAINT [FK_Reservations_Guests] FOREIGN KEY (GuestId) REFERENCES Guests(Id)
)

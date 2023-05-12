CREATE PROCEDURE [dbo].[sProcReservations_CheckIn]
	--@todayDate Date,
	@confirmationNumber uniqueidentifier
AS
	DECLARE @todayDate Date
	SET @todayDate = CONVERT (Date, GETDATE());
begin
	set nocount on;

	UPDATE Reservations
	SET CheckedIn = 1
	WHERE (ConfimationNumber = @confirmationNumber AND StartDate = @todayDate);

	SELECT g.Id AS GuestId, 
		g.firstName, 
		g.lastName, 
		ro.RoomNumber, 
		rt.Type AS RoomType, 
		r.startDate, 
		r.endDate, 
		r.CheckedIn, 
		r.ConfimationNumber AS ConfirmationNumber
	FROM dbo.Reservations r
	INNER JOIN dbo.Guests g ON g.Id = r.GuestId
	INNER JOIN dbo.Rooms ro ON ro.Id = r.RoomId
	INNER JOIN RoomTypes rt ON ro.RoomTypeId = rt.Id
	WHERE r.ConfimationNumber = @confirmationNumber;
end

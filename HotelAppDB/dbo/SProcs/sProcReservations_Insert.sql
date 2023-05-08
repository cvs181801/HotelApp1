CREATE PROCEDURE [dbo].[sProcReservations_Insert]
	@roomId int,
	@guestId int,
	@startDate date,
	@endDate date,
	@totalCost money 
AS
begin

	set nocount on; 

	INSERT INTO dbo.Reservations(StartDate, EndDate, GuestId, RoomId, TotalCost)
	VALUES (@startDate, @endDate, @guestId, @roomId, @totalCost);

	DECLARE @affectedRowId int = SCOPE_IDENTITY();

	SELECT 
		resv.GuestId, 
		g.FirstName, 
		g.LastName, 
		resv.RoomId AS RoomNumber, 
		resv.CheckedIn, 
		resv.ConfimationNumber AS ConfirmationNumber

	FROM dbo.Reservations resv
	INNER JOIN Guests g ON g.Id = resv.GuestId 
	WHERE resv.Id = @affectedRowId;
end

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
		g.FirstName, 
		g.LastName, 
		rt.Type AS RoomType,
		resv.StartDate,
		resv.EndDate, 
		resv.ConfimationNumber AS ConfirmationNumber

	FROM dbo.Reservations resv
	INNER JOIN Guests g ON g.Id = resv.GuestId 
	INNER JOIN Rooms r ON resv.RoomId = r.Id
	INNER JOIN RoomTypes rt ON r.RoomTypeId = rt.Id
	WHERE resv.Id = @affectedRowId;
end

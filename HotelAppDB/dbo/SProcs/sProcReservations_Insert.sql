CREATE PROCEDURE [dbo].[sProcReservations_Insert]
	@roomId int,
	@guestId int,
	@startDate date,
	@endDate date,
	@totalCost money,
	@affectedRowId int 
AS
begin

	begin tran
	set nocount on; 

	INSERT INTO dbo.Reservations(StartDate, EndDate, GuestId, RoomId, TotalCost)
	VALUES (@startDate, @endDate, @guestId, @roomId, @totalCost);
	SET @affectedRowId = SCOPE_IDENTITY();
	
	commit tran
	
	SELECT resv.GuestId, g.FirstName, g.LastName, resv.RoomId, resv.CheckedIn, resv.ConfimationNumber 
	FROM dbo.Reservations resv
	INNER JOIN Guests g ON g.Id = resv.GuestId 
	WHERE resv.Id = @affectedRowId;
end

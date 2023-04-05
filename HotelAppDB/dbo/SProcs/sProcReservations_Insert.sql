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
end

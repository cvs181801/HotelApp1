CREATE PROCEDURE [dbo].[sProcReservations_Insert]
	@roomId int,
	@guestId int,
	@startDate date,
	@endDate date,
	@confirmationNumber int,
	@totalCost money
AS

	SET @confirmationNumber = NEWID();
begin
	set nocount on;

	INSERT INTO dbo.Reservations(StartDate, EndDate, RoomId, GuestId, ConfimationNumber, RoomId, TotalCost)
	VALUES (@startDate, @endDate, @guestId, @confirmationNumber, @roomId, @totalCost);
end

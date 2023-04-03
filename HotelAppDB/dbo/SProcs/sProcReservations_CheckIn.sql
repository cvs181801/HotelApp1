CREATE PROCEDURE [dbo].[sProcReservations_CheckIn]
	@todayDate Date,
	@guestId int
AS
	set @todayDate = GETDATE();
begin
	set nocount on;

	UPDATE Reservations
	SET CheckedIn = 1
	WHERE (GuestId = @guestId AND StartDate = @todayDate);

end

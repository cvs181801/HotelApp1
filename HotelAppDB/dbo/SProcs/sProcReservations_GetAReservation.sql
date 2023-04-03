CREATE PROCEDURE [dbo].[sProcReservations_GetAReservation]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@todayDate Date
AS
	set @todayDate = GETUTCDATE();

begin
	set nocount on;

	SELECT r.startDate, r.endDate, g.firstName, g.lastName, ro.RoomNumber, r.CheckedIn, r.ConfimationNumber
	FROM dbo.Reservations r
	INNER JOIN dbo.Guests g ON g.Id = r.GuestId
	INNER JOIN dbo.Rooms ro ON ro.Id = r.RoomId
	WHERE r.startDate = @todayDate AND g.Id = r.GuestId;
end

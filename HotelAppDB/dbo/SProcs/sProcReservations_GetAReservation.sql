CREATE PROCEDURE [dbo].[sProcReservations_GetAReservation]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@todayDate Date,
	@searchString nvarchar(100)
AS
	set @todayDate = GETUTCDATE(); 

begin
	set nocount on;

	SELECT r.startDate, r.endDate, g.firstName, g.lastName, ro.RoomNumber, r.CheckedIn, r.ConfimationNumber
	FROM dbo.Reservations r
	INNER JOIN dbo.Guests g ON g.Id = r.GuestId
	INNER JOIN dbo.Rooms ro ON ro.Id = r.RoomId
	WHERE r.startDate = @todayDate AND g.Id = r.GuestId; --WHERE (input) matches something in the Reservation's table first name, last name or confirmation number. 

	--WHERE r.FirstName LIKE @searchString OR r.LastName LIKE @searchString OR r.ConfirmationNumber LIKE  @searchString  
end

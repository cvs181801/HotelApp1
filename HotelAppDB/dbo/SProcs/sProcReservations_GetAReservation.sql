CREATE PROCEDURE [dbo].[sProcReservations_GetAReservation]
	@searchString nvarchar(100)
AS

begin
	set nocount on;

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
	 WHERE g.firstName LIKE '%' + @searchString + '%'
		OR g.lastName LIKE '%' + @searchString + '%'
		OR r.confimationNumber LIKE '%' + @searchString + '%' 
	ORDER BY StartDate;
		--make it so user cannot search an empty string or anything under 2 letters/characters (otherwise they'll see all reservations coming back)
		
end

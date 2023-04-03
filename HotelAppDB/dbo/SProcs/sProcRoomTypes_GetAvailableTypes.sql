
CREATE PROCEDURE [dbo].[sProcRoomTypes_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
begin
	set nocount on;

	SELECT t.Id, t.Type, t.Description, t.Price, COUNT(t.Id) AS NumAvailableOfThisRoomType
	FROM dbo.Rooms r 
	INNER JOIN dbo.RoomTypes t on t.Id = r.RoomTypeId
	WHERE r.Id NOT IN (
		SELECT resv.RoomId
		FROM dbo.Reservations resv
		WHERE (@startDate < resv.StartDate AND @endDate > resv.EndDate)
			OR (resv.StartDate <= @endDate AND @endDate < resv.EndDate)
			OR (resv.StartDate <= @startDate AND @startDate < resv.EndDate)
		)
	GROUP BY t.Id, t.Type, t.Description, t.Price 

end
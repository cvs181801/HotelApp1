
CREATE PROCEDURE [dbo].[sProcRoomTypes_GetRandomAvailableRoom]
	@startDate date,
	@endDate date, 
	@roomTypeId int

AS
begin
	set nocount on;

SELECT TOP 1 r.Id, r.RoomNumber, t.Type, (DATEDIFF(day, @startDate, @endDate)*t.Price) AS TotalCost 
FROM dbo.Rooms r 
INNER JOIN dbo.RoomTypes t on t.Id = r.RoomTypeId
WHERE t.Id = @roomTypeId AND r.Id NOT IN (
SELECT resv.RoomId
FROM dbo.Reservations resv
WHERE (@startDate < resv.StartDate AND @endDate > resv.EndDate)
	OR (resv.StartDate <= @endDate AND @endDate < resv.EndDate)
	OR (resv.StartDate <= @startDate AND @startDate < resv.EndDate)
)
ORDER BY NEWID()

end
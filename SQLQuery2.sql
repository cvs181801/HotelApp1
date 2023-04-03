
declare @startDate date;
declare @endDate date;
declare @roomTypeId int;

set @startDate = '3/31/23'
set @endDate = '4/5/23'
set @roomTypeId = 3

SELECT TOP 1 r.RoomNumber, t.Type, t.Price, (DATEDIFF(day, @startDate, @endDate)*t.Price) AS TotalCost --, COUNT(t.Id) AS NumAvailableOfThisRoomType
FROM dbo.Rooms r 
INNER JOIN dbo.RoomTypes t on t.Id = r.RoomTypeId
WHERE t.Id = @roomTypeId AND r.Id NOT IN (
SELECT resv.RoomId
FROM dbo.Reservations resv
WHERE (@startDate < resv.StartDate AND @endDate > resv.EndDate)
	OR (resv.StartDate <= @endDate AND @endDate < resv.EndDate)
	OR (resv.StartDate <= @startDate AND @startDate < resv.EndDate)
)
--GROUP BY t.Id, t.Type, t.Description, t.Price
ORDER BY NEWID()












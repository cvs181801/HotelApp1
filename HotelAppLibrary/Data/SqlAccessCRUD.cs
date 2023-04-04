using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using Microsoft.VisualBasic;

namespace HotelAppLibrary.Databases
{
    public class SqlAccessCRUD : IDatabaseData
    {
        private const string _connectionStringName = "SqlDb";
        private readonly ISqlDataAccess _db;

        public SqlAccessCRUD(ISqlDataAccess db)
        {
            _db = db;
        }
        public List<RoomTypeModel> GetAllAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {

            return _db.LoadData<RoomTypeModel, dynamic>(//"dbo.sProcRoomTypes_GetAvailableTypes.sql",
                "declare @startDate date;" +
                "declare @endDate date;" +

                $"SET @startDate = { startDate }" +
                $"SET @endDate = { endDate }" +
                "SELECT t.Id, t.Type, t.Description, t.Price, COUNT(t.Id) AS NumAvailableOfThisRoomType " +
                "FROM dbo.Rooms r " +
                "INNER JOIN dbo.RoomTypes t on t.Id = r.RoomTypeId" +
                "WHERE r.Id NOT IN (" +
                "SELECT resv.RoomId" +
                "FROM dbo.Reservations resv" +
                "WHERE (@startDate < resv.StartDate AND @endDate > resv.EndDate)" +
                "OR (resv.StartDate <= @endDate AND @endDate < resv.EndDate)" +
                "OR (resv.StartDate <= @startDate AND @startDate < resv.EndDate) " +
                "GROUP BY t.Id, t.Type, t.Description, t.Price;", //why is this saying the variables have already been declared ? *** just making notes here for tomorrow!!! tbc!! ***
                                                new { startDate, endDate },
                                                _connectionStringName,
                                                false) ;
        }

        public void CreateAReservation(int RoomTypeId, DateTime startDate, DateTime endDate, string firstName, string lastName)
        {
            GuestModel guest = _db.LoadData<GuestModel, dynamic>("dbo.sProcGuests_Insert.sql",
                                                                    /*if NOT EXISTS(SELECT 1 FROM dbo.Guests where FirstName = @firstName AND LastName = @lastName)

                                                        begin
                                                            INSERT INTO dbo.Guests(FirstName, LastName)

                                                            VALUES(@firstName, @lastName)


                                                        end
                                                        SELECT TOP 1[Id], [FirstName], [Lastname]
                                                                FROM dbo.Guests
                                                                WHERE FirstName = @firstName AND lastName = @lastName;

                                                                new { firstName, lastName },*/
                                                                    _connectionStringName,
                                                                    true
                                                                    ).First();

            RandomRoomModel roomAssignment = _db.LoadData<RandomRoomModel, dynamic>("dbo.sProcRoomTypes_GetRandomAvailableRoom.sql",

             /*   @startDate date,
    @endDate date,
    @roomTypeId int

AS
begin

    set nocount on;

            SELECT TOP 1 r.Id, r.RoomNumber, t.Type, (DATEDIFF(day, @startDate, @endDate) * t.Price) AS TotalCost
FROM dbo.Rooms r
INNER JOIN dbo.RoomTypes t on t.Id = r.RoomTypeId
WHERE t.Id = @roomTypeId AND r.Id NOT IN(
SELECT resv.RoomId
FROM dbo.Reservations resv
WHERE(@startDate < resv.StartDate AND @endDate > resv.EndDate)

    OR(resv.StartDate <= @endDate AND @endDate < resv.EndDate)

    OR(resv.StartDate <= @startDate AND @startDate < resv.EndDate)
)
ORDER BY NEWID()*/

                                             new { startDate, endDate, RoomTypeId },
                                             _connectionStringName,
                                             true).First();

            _db.SaveData("dbo.sProcReservations_Insert.sql",

     /*           @roomId int,
    @guestId int,
    @startDate date,
    @endDate date,
    @totalCost money
AS
begin

    set nocount on;

            INSERT INTO dbo.Reservations(StartDate, EndDate, RoomId, GuestId, RoomId, TotalCost)

    VALUES(@startDate, @endDate, @guestId, @roomId, @totalCost);*/

            new { startDate = startDate, endDate = endDate, guestId = guest.Id, roomId = roomAssignment.Id, totalCost = roomAssignment.TotalCost },
                         _connectionStringName,
                         true);
        }

        public ReservationModel GetAReservation(string firstName, string lastName)
        {
            return _db.LoadData<ReservationModel, dynamic>("dbo.sProcReservations_GetAReservation.sql",

            /*    @firstName nvarchar(50),
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

    WHERE r.startDate = @todayDate AND g.Id = r.GuestId;*/

            new { firstName, lastName },
                                                _connectionStringName,
                                                true).First();
        }

        public void CheckInGuest(string confirmationNumber)
        {
            _db.SaveData("dbo.sProcReservations_CheckIn.sql",

               /* set @todayDate = GETDATE();
            begin
            set nocount on;

            UPDATE Reservations

    SET CheckedIn = 1

    WHERE(ConfimationNumber = @confirmationNumber AND StartDate = @todayDate);*/
            new { confirmationNumber },
                         _connectionStringName,
                         true);
        }
    }
}

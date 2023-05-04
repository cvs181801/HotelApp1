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

            return _db.LoadData<RoomTypeModel, dynamic>("dbo.sProcRoomTypes_GetAvailableTypes",
                                                new { startDate, endDate },
                                                _connectionStringName,
                                                true) ;
        }

       /* public RoomTypeModel GetRoomTypeById()
        {

        }*/

        public ReservationModel CreateAReservation(int RoomTypeId, DateTime startDate, DateTime endDate, string firstName, string lastName)
        {
            GuestModel guest = _db.LoadData<GuestModel, dynamic>("dbo.sProcGuests_Insert",
                                                                new { firstName, lastName },
                                                                    _connectionStringName,
                                                                    true
                                                                    ).First();

            RandomRoomModel roomAssignment = _db.LoadData<RandomRoomModel, dynamic>("dbo.sProcRoomTypes_GetRandomAvailableRoom",
                                                                                     new { startDate, endDate, RoomTypeId },
                                                                                     _connectionStringName,
                                                                                     true).First();

           /* string sql = "DECLARE @affectedRow INT" +
                "INSERT INTO dbo.Reservations(StartDate, EndDate, GuestId, RoomId, TotalCost) " +
                "VALUES (@startDate, @endDate, @guestId, @roomId, @totalCost)" +
                "SET @affectedRow = SCOPE_IDENTITY();" +
                "SELECT @affectedRow" +
                "RETURN;";
*/


            ReservationModel newlyAddedResv =  _db.SaveData<ReservationModel>("dbo.sProcReservations_Insert",
                        new { startDate = startDate, endDate = endDate, guestId = guest.Id, roomId = roomAssignment.Id, totalCost = roomAssignment.TotalCost },
                        _connectionStringName,
                        true
                        );

            return newlyAddedResv;

            /*_db.SaveData("INSERT INTO dbo.Reservations(StartDate, EndDate, GuestId, RoomId, TotalCost)\r\n\tVALUES (@startDate, @endDate, @guestId, @roomId, @totalCost)" +
                "SELECT CAST(SCOPE_IDENTITY() as string);"
                new { startDate = startDate, endDate = endDate, guestId = guest.Id, roomId = roomAssignment.Id, totalCost = roomAssignment.TotalCost },
                        _connectionStringName,
                        false)*/

            /*  string query = "INSERT INTO dbo.Reservations(StartDate, EndDate, GuestId, RoomId, TotalCost)\r\n\tVALUES (@startDate, @endDate, @guestId, @roomId, @totalCost)" +
                  "SELECT CAST(SCOPE_IDENTITY() as string);";

              ReservationModel newlyAddedResv = _db.LoadData<string>( )*/

            ///according to documentation the Execute method should return the affected rows, but I can't tell how to view those/grab those from within that method...
        }

       

    public ReservationModel GetAReservation(string firstName, string lastName)
        {
            return _db.LoadData<ReservationModel, dynamic>("dbo.sProcReservations_GetAReservation",
                                                           new { firstName, lastName },
                                                           _connectionStringName,
                                                           true).First();
        }

        public ReservationModel CheckInGuest(string confirmationNumber)
        {
            return _db.SaveData<ReservationModel>("dbo.sProcReservations_CheckIn",
                        new { confirmationNumber },
                         _connectionStringName,
                         false);
        }
    }
}

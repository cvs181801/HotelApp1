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


            ReservationModel newlyAddedResv =  _db.SaveData<ReservationModel>("dbo.sProcReservations_Insert",
                                                new { startDate = startDate, endDate = endDate, guestId = guest.Id, roomId = roomAssignment.Id, totalCost = roomAssignment.TotalCost },
                                                _connectionStringName,
                                                true
                                                );

            return newlyAddedResv;
  
        }

       

    public ReservationModel GetAReservation(string firstName, string lastName)
        {
            return _db.LoadData<ReservationModel, dynamic>("dbo.sProcReservations_GetAReservation",
                                                           new { firstName, lastName },
                                                           _connectionStringName,
                                                           true).First();
        } //need to remove todaydate() from the sproc. need to update this to allow searching for any part of the name or confirmation number - SECURELY

        public ReservationModel CheckInGuest(string confirmationNumber)
        {
            return _db.SaveData<ReservationModel>("dbo.sProcReservations_CheckIn",
                        new { confirmationNumber },
                         _connectionStringName,
                         false);
        }
    }
}

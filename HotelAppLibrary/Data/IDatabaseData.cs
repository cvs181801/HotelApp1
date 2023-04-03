using HotelAppLibrary.Models;

namespace HotelAppLibrary.Databases
{
    public interface IDatabaseData
    {
        void CheckInGuest(string confirmationNumber);
        void CreateAReservation(int RoomTypeId, DateTime startDate, DateTime endDate, string firstName, string lastName);
        List<RoomTypeModel> GetAllAvailableRoomTypes(DateTime startDate, DateTime endDate);
        ReservationModel GetAReservation(string firstName, string lastName);
    }
}
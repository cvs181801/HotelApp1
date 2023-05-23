using HotelAppLibrary.Models;

namespace HotelAppLibrary.Databases
{
    public interface IDatabaseData
    {
        ReservationModel CheckInGuest(string confirmationNumber);
        ReservationModel CreateAReservation(int RoomTypeId, DateTime startDate, DateTime endDate, string firstName, string lastName);
        List<RoomTypeModel> GetAllAvailableRoomTypes(DateTime startDate, DateTime endDate);
        List<ReservationModel> GetAReservation(string searchString);
    }
}

//small change
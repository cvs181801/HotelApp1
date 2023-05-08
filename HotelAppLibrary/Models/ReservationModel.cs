using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Models
{
    public class ReservationModel
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomNumber { get; set; }
        public bool CheckedIn { get; set; }
        public Guid ConfirmationNumber { get; set; }
    }
}

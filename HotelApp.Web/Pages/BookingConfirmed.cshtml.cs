using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace HotelApp.Web.Pages
{
    public class BookingConfirmedModel : PageModel
    {
        private IDatabaseData _db;

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredStartDate { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredEndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool BookingConfirmed { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public Guid ConfirmationNumber { get; set; }

        public ReservationModel Booking { get; set; }

        public BookingConfirmedModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            /*if (BookingConfirmed)
            {*/
                //Booking = _db.GetReservation(Booking.FirstName, Booking.LastName );
            /*}*/

        }

        public IActionResult OnPost()
        {
            Console.WriteLine(FirstName, LastName, Booking.LastName);

            return RedirectToPage(new
            {
                BookingConfirmed = true,
                DesiredStartDate = DesiredStartDate.ToString("yyyy-MM-dd"),
                DesiredEndDate = DesiredEndDate.ToString("yyyy-MM-dd"),
                ConfirmationNumber = Booking.ConfirmationNumber.ToString(), 
                FirstName = Booking.FirstName,
                LastName = Booking.LastName
            }); 
        } 
    }
}

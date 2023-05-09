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
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime ConfirmedStartDate { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime ConfirmedEndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool BookingConfirmed { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public Guid ConfirmationNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoomType { get; set; }

        /*public ReservationModel Booking { get; set; }*/

        public BookingConfirmedModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            RedirectToPage(new
            {
                BookingConfirmed = true,
                ConfirmedStartDate = ConfirmedStartDate.ToString("yyyy-MM-dd"),
                ConfirmedEndDate = ConfirmedEndDate.ToString("yyyy-MM-dd"),
                ConfirmationNumber = ConfirmationNumber.ToString(),
                FirstName = FirstName,
                LastName = LastName
            });
        }
    }
}

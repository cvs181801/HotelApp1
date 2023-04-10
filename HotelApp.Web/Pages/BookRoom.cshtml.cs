using HotelAppLibrary.Databases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Web.Pages
{
    public class BookRoomModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        public bool BookingConfirmed { get; set; } = false;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredStartDate { get; set; } 

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredEndDate { get; set; }

        public IDatabaseData _db { get; }

        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
           if (RoomTypeId > 0)
            {
                _db.CreateAReservation(RoomTypeId, DesiredStartDate, DesiredEndDate, FirstName, LastName);
            }
        }
       
        public IActionResult OnPost() 
        {
            return RedirectToPage("/BookingConfirmed", new {FirstName, LastName, DesiredStartDate, DesiredEndDate});
                
        }


    }
}

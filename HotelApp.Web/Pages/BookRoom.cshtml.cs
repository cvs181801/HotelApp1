using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
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

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredStartDate { get; set; } 

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredEndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public ReservationModel Booking { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool BookingConfirmed { get; set; } = false;
        public IDatabaseData _db { get; }

        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            //if (BookingConfirmed)
           //{
                  //I think this is happening because its a SaveData not just a LoadData..
            
            //}

        }

        public IActionResult OnPost() 
        {
            _db.CreateAReservation(RoomTypeId, DesiredStartDate, DesiredEndDate, FirstName, LastName);
            return RedirectToPage("/BookingConfirmed", new {FirstName, LastName, DesiredStartDate, DesiredEndDate, RoomTypeId});
                
        }


    }
}

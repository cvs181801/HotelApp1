using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class BookRoomModel : PageModel
    {

        [BindProperty]
        public int RoomTypeId { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        public bool BookingConfirmed { get; set; } = false;


        public void OnGet()
        {
            if (BookingConfirmed)
            {

            }
        }
       /* public IActionResult OnPost() { }*/
    }
}

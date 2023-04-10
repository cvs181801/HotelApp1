using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class BookingConfirmedModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        public void OnGet()
        {
        }
    }
}

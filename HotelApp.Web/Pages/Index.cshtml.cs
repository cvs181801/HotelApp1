using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredStartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime DesiredEndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; } = false;

        public List<RoomTypeModel>? AvailableRoomTypes { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDatabaseData db)
        {
            _db = db;
            _logger = logger;
        }  


        public void OnGet()
        {
            if (SearchEnabled) //how does searchenabled get changed to true? I think it's simply that when you click the search button the form submits and the page refreshes causing redirecttopage method to trigger, am I rite ? 
            {
                AvailableRoomTypes = _db.GetAllAvailableRoomTypes(DesiredStartDate, DesiredEndDate);
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new 
            {SearchEnabled = true, 
                DesiredStartDate = DesiredStartDate.ToString("yyyy-MM-dd"), 
                DesiredEndDate = DesiredEndDate.ToString("yyyy-MM-dd"),
            });
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace HotelManagements.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

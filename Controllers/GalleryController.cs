using Microsoft.AspNetCore.Mvc;

namespace HotelManagements.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

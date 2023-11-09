using HotelManagements.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelManagements.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QuanLyKhachSanContext context = new QuanLyKhachSanContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
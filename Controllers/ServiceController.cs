using HotelManagements.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagements.Controllers
{
    public class ServiceController : Controller
    {
        QuanLyKhachSanContext context = new QuanLyKhachSanContext();
        public IActionResult Index()
        {
            ViewBag.LoaiPhongs = context.TLoaiPhongs.ToList();
            return View();
        }
    }
}

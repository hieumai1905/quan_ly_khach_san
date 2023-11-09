using HotelManagements.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace HotelManagements.Controllers
{
    public class TestimonialsController : Controller
    {
        QuanLyKhachSanContext context = new QuanLyKhachSanContext();
        public IActionResult Index()
        {
            string? danhGiumJson = TempData["DanhGium"] as string;
            TDanhGium? danhGium = null;
            if (!string.IsNullOrEmpty(danhGiumJson))
            {
                danhGium = JsonConvert.DeserializeObject<TDanhGium>(danhGiumJson);
                ModelState.AddModelError("Email", "Email Không Hợp Lệ");
            }
            ViewBag.Testimonials = context.TDanhGia
                .OrderByDescending(d => d.MaDg)
                .Take(10)
                .ToList();
            return View(danhGium);
        }

        [HttpPost("/Testimonials/Add")]
        public IActionResult Add(TDanhGium danhGium)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (danhGium.Email == null || 
                    (danhGium.Email != null && Regex.IsMatch(danhGium.Email, pattern)))
            {
                var maxDg = context.TDanhGia.Max(d => d.MaDg);
                if (!string.IsNullOrEmpty(maxDg))
                {
                    int maxDgValue = int.Parse(maxDg);
                    maxDgValue++;
                    string newMaxDg = maxDgValue.ToString("0000");

                    danhGium.MaDg = newMaxDg;
                    context.Add(danhGium);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            string danhGiumJson = JsonConvert.SerializeObject(danhGium);
            TempData["DanhGium"] = danhGiumJson;
            
            return RedirectToAction("Index");
        }
    }
}

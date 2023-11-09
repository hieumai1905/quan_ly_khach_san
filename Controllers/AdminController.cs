using HotelManagements.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace HotelManagements.Controllers
{
    public class AdminController : Controller
    {
        QuanLyKhachSanContext context = new QuanLyKhachSanContext();
        public IActionResult Index()
        {
            ViewBag.Customers = context.TChiTietKhs.Include(x => x.LoaiKhNavigation).ToList();
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.LoaiKh = new SelectList(context.TLoaiKhachHangs.ToList(), "LoaiKh", "DienGiai");
            return View();
        }
        [HttpPost]
        public IActionResult Create(TChiTietKh kh)
        {
            TChiTietKh? chiTietKh = context.TChiTietKhs.FirstOrDefault(x => x.MaKh.Equals(kh.MaKh));
            if(chiTietKh == null)
            {
                context.TChiTietKhs.Add(kh);
                context.SaveChanges();
                return RedirectToAction("Index");   
            }
            else
            {
                ViewBag.LoaiKh = new SelectList(context.TLoaiKhachHangs.ToList(), "LoaiKh", "DienGiai");
                ModelState.AddModelError("MaKh", "Mã khách hàng đã tồn tại");
                return View(kh);
            }
        }
        [HttpGet("/Admin/Update/{MaKh}")]
        public IActionResult Update(string MaKh)
        {
            TChiTietKh? customer = context.TChiTietKhs.FirstOrDefault(x => x.MaKh.Equals(MaKh));
            if(customer != null)
            {
                ViewBag.LoaiKh = new SelectList(context.TLoaiKhachHangs.ToList(), "LoaiKh", "DienGiai");
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(TChiTietKh? customer)
        {
            TChiTietKh? chiTietKh = context.TChiTietKhs.FirstOrDefault(x => x.MaKh.Equals(customer.MaKh));
            if (chiTietKh != null)
            {
                context.TChiTietKhs.Update(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoaiKh = new SelectList(context.TLoaiKhachHangs.ToList(), "LoaiKh", "DienGiai");
                ModelState.AddModelError("MaKh", "Mã khách hàng không tồn tại");
                return View(customer);
            }
        }

        [HttpGet("/Admin/Delete/{MaKh}")]
        public IActionResult Delete(string MaKh)
        {
            TChiTietKh? chiTietKh = context.TChiTietKhs.FirstOrDefault(x => x.MaKh.Equals(MaKh));
            if (chiTietKh != null)
            {
                context.TChiTietKhs.Remove(chiTietKh);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

using HotelManagements.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelManagements.Controllers
{
    public class BookingController : Controller
    {
        QuanLyKhachSanContext context = new QuanLyKhachSanContext();
        public IActionResult Index()
        {
            string? ChiTietKhJson = TempData["ChiTietKh"] as string;
            if (!string.IsNullOrEmpty(ChiTietKhJson))
            {
                ViewBag.ChiTietKH = JsonConvert.DeserializeObject<TChiTietKh>(ChiTietKhJson);
            }
            
            string? ChiTietDPJson = TempData["ChiTietDP"] as string;
            if (!string.IsNullOrEmpty(ChiTietDPJson))
            {
                ViewBag.ChiTietDP = JsonConvert.DeserializeObject<TChiTietDatPhong>(ChiTietDPJson);
            }

            string? DatPhongJson = TempData["DatPhong"] as string;
            if (!string.IsNullOrEmpty(DatPhongJson))
            {
                ViewBag.DatPhong = JsonConvert.DeserializeObject<TDatPhong>(DatPhongJson);
            }

            ViewBag.LayHoaDon = TempData["layHoaDon"] as string;

            return View();
        }

        [HttpPost("/Booking/Add")]
        public IActionResult Add(TChiTietKh chiTietKh, TChiTietDatPhong chiTietDatPhong,
            TDatPhong datPhong, int? SlphongDat, string? layHoaDon)
        {
            bool isUpdate = false;  
            if(datPhong.MaDp != null)
            {
                isUpdate = true;
            }

            if(SlphongDat != null)
            {
                chiTietDatPhong.SlphongDat = (byte)SlphongDat;
            }
            
            var KhachHang = context.TChiTietKhs.FirstOrDefault(x => x.MaKh.Equals(chiTietKh.MaKh));
            if(KhachHang != null || chiTietKh.MaKh == null)
            {
                var dk = context.TChiTietKhs.Max(x => x.MaKh);
                chiTietKh.MaKh = GetNextId(dk);
                datPhong.MaKh = chiTietKh.MaKh;
            }
            
            if(!isUpdate)
            {
                var dp = context.TDatPhongs.Max(x => x.MaDp);
                datPhong.MaDp = GetNextId(dp);
                chiTietDatPhong.MaDp = datPhong.MaDp;
            }

            if(layHoaDon == null || layHoaDon.Equals("khong"))
            {
                datPhong.TenCongTy = null;
                datPhong.DiaChiCty = null;
                datPhong.DiaChiCty = null;
            }

            if (isUpdate == true)
            {
                context.Update(datPhong);
                context.Update(chiTietKh);
                context.Update(chiTietDatPhong);
            }
            else
            {
                context.Add(datPhong);
                context.Add(chiTietKh);
                context.Add(chiTietDatPhong);
            }

            context.SaveChanges();
            
            chiTietKh.TDatPhongs = null;
            chiTietKh.TDangKies = null;
            chiTietKh.LoaiKhNavigation = null;
            string chiTietKhJson = JsonConvert.SerializeObject(chiTietKh);
            TempData["ChiTietKh"] = chiTietKhJson;
            
            chiTietDatPhong.MaDpNavigation = null;
            chiTietDatPhong.LoaiPhongNavigation = null;
            string chiTietDatPhongJson = JsonConvert.SerializeObject(chiTietDatPhong);
            TempData["ChiTietDP"] = chiTietDatPhongJson;

            datPhong.TChiTietDatPhongs = null;
            datPhong.MaKhNavigation = null;
            string datPhongJson = JsonConvert.SerializeObject(datPhong);
            TempData["DatPhong"] = datPhongJson;
            TempData["layHoaDon"] = layHoaDon;

            return RedirectToAction("Index");
        }


        public string GetNextId(string? id)
        {
            if (id == null)
                id = "0";
            int nextId = int.Parse(id);
            nextId++;
            return nextId.ToString("0000");
        }
    }
}

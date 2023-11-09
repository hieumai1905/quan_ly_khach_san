using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagements.Models;

namespace HotelManagements.Controllers
{
    public class RegisterController : Controller
    {
        private readonly QuanLyKhachSanContext _context = new QuanLyKhachSanContext();

        public RegisterController()
        {
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            var quanLyKhachSanContext = _context.TDangKies.Include(t => t.MaKhNavigation).Include(t => t.SoPhongNavigation);
            return View(await quanLyKhachSanContext.ToListAsync());
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TDangKies == null)
            {
                return NotFound();
            }

            var tDangKy = await _context.TDangKies
                .Include(t => t.MaKhNavigation)
                .Include(t => t.SoPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaDk == id);
            if (tDangKy == null)
            {
                return NotFound();
            }

            return View(tDangKy);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            ViewData["MaKh"] = new SelectList(_context.TChiTietKhs, "MaKh", "MaKh");
            ViewData["SoPhong"] = new SelectList(_context.TSoPhongLoaiPhongs, "SoPhong", "SoPhong");
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDk,MaKh,SoPhong,NgayVao,NgayRa")] TDangKy tDangKy)
        {
            var tDk = await _context.TDangKies.FindAsync(tDangKy.MaDk);
            if (tDk == null)
            {
                _context.Add(tDangKy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("MaDk", "Mã Đăng Ký Đã Tồn Tại!");
                ViewData["MaKh"] = new SelectList(_context.TChiTietKhs, "MaKh", "MaKh", tDangKy.MaKh);
                ViewData["SoPhong"] = new SelectList(_context.TSoPhongLoaiPhongs, "SoPhong", "SoPhong", tDangKy.SoPhong);
                return View(tDangKy);
            }
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TDangKies == null)
            {
                return NotFound();
            }

            var tDangKy = await _context.TDangKies.FindAsync(id);
            if (tDangKy == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.TChiTietKhs, "MaKh", "MaKh", tDangKy.MaKh);
            ViewData["SoPhong"] = new SelectList(_context.TSoPhongLoaiPhongs, "SoPhong", "SoPhong", tDangKy.SoPhong);
            return View(tDangKy);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDk,MaKh,SoPhong,NgayVao,NgayRa")] TDangKy tDangKy)
        {
            if (id != tDangKy.MaDk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tDangKy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TDangKyExists(tDangKy.MaDk))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.TChiTietKhs, "MaKh", "MaKh", tDangKy.MaKh);
            ViewData["SoPhong"] = new SelectList(_context.TSoPhongLoaiPhongs, "SoPhong", "SoPhong", tDangKy.SoPhong);
            return View(tDangKy);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TDangKies == null)
            {
                return NotFound();
            }

            var tDangKy = await _context.TDangKies
                .Include(t => t.MaKhNavigation)
                .Include(t => t.SoPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaDk == id);
            if (tDangKy == null)
            {
                return NotFound();
            }

            return View(tDangKy);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TDangKies == null)
            {
                return Problem("Entity set 'QuanLyKhachSanContext.TDangKies'  is null.");
            }
            var tDangKy = await _context.TDangKies.FindAsync(id);
            if (tDangKy != null)
            {
                _context.TDangKies.Remove(tDangKy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TDangKyExists(string id)
        {
          return (_context.TDangKies?.Any(e => e.MaDk == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using Code_First.Models;

namespace Code_First.Areas.Admin.Controllers
{
    [Area("admin")]
    public class QuanTriController : Controller
    {
        private readonly AppDbContext _context;

        public QuanTriController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dsQuanTri = _context.QuanTris.ToList();
            return View(dsQuanTri);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string taiKhoan, string matKhau)
        {
            var admin = _context.QuanTris
                .FirstOrDefault(a => a.TaiKhoan == taiKhoan && a.MatKhau == matKhau && a.TrangThai == 1);

            if (admin != null)
            {
                // Lưu session, chuyển đến trang admin
                return RedirectToAction("Index", "QuanTri", new { area = "Admin" });
            }

            ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
    }
}

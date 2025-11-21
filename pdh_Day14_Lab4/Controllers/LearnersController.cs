using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pdh_Day14_Lab4.Models;

namespace pdh_Day14_Lab4.Controllers
{
    public class LearnersController : Controller
    {
        private readonly SchoolContext _context;
        private int pageSize = 3;

        public LearnersController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Learners
        //public async Task<IActionResult> Index()
        //{
        //    var schoolContext = _context.Learners.Include(l => l.Major);
        //    return View(await schoolContext.ToListAsync());
        //}

        public IActionResult Index(int? majorId)
        {
            var learners = _context.Learners.Include(l => l.Major);

            if (majorId != null)
            {
                learners = _context.Learners
                    .Where(l => l.MajorID == majorId)
                    .Include(l => l.Major);
            }

            // Tính toán số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            // Truyền dữ liệu vào ViewBag
            ViewBag.PageNum = pageNum;

            // lay du lieu trang dau tien
            var result = learners.Take(pageSize).ToList();
            return View(result);
        }

        // Phan trang ket hop loc va tim kiem du lieu
        public IActionResult LearnerFilter(int? majorId, string keyword, int? pageIndex)
        {
            // Lay toan bo learner trong dbset
            var learners = _context.Learners.AsQueryable();

            // lay chi so trang, neu khong co thi mac dinh la trang 1
            int page = (int)(pageIndex == null || pageIndex < 1 ? 1 : pageIndex);

            // Loc du lieu theo majorId neu co
            if (majorId != null)
            {
                // Loc du lieu theo majorId
                learners = learners.Where(l => l.MajorID == majorId);
                ViewBag.MajorId = majorId;
            }

            // Tim kiem theo keyword neu co
            if (keyword != null)
            {
                // tim kiem 
                learners = learners.Where(l => l.FirstMidName.ToLower().Contains(keyword.ToLower()));

                // Truyen keyword ve view de hien thi lai
                ViewBag.Keyword = keyword;
            }

            // Tinh toan so trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);

            // Truyen du lieu vao ViewBag
            ViewBag.pageNum = pageNum;

            // Lay du lieu theo trang
            var result = learners.Skip(pageSize * (page - 1)).Take(pageSize).Include(m => m.Major).ToList();
            return PartialView("LearnerTable", result);
        }

        public IActionResult LearnerByMajorId(int majorId)
        {
            var learners = _context.Learners
                .Where(l => l.MajorID == majorId)
                .Include(l => l.Major)
                .ToList();
            return PartialView("LearnerTable", learners);
        }

        // GET: Learners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Major)
                .FirstOrDefaultAsync(m => m.LearnerID == id);
            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // GET: Learners/Create
        public IActionResult Create()
        {
            ViewData["MajorID"] = new SelectList(_context.Majors, "MajorID", "MajorID");
            return View();
        }

        // POST: Learners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearnerID,LastName,FirstMidName,EnrollmentDate,MajorID")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MajorID"] = new SelectList(_context.Majors, "MajorID", "MajorID", learner.MajorID);
            return View(learner);
        }

        // GET: Learners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewData["MajorID"] = new SelectList(_context.Majors, "MajorID", "MajorID", learner.MajorID);
            return View(learner);
        }

        // POST: Learners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LearnerID,LastName,FirstMidName,EnrollmentDate,MajorID")] Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerID))
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
            ViewData["MajorID"] = new SelectList(_context.Majors, "MajorID", "MajorID", learner.MajorID);
            return View(learner);
        }

        // GET: Learners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var learner = await _context.Learners
                .Include(l => l.Major)
                .Include(l => l.Enrollments) // Kiểm tra Enrollment
                .FirstOrDefaultAsync(m => m.LearnerID == id);

            if (learner == null)
                return NotFound();

            // Nếu còn Enrollment → không cho xóa
            if (learner.Enrollments != null && learner.Enrollments.Any())
            {
                TempData["ErrorMessage"] = "Không thể xóa học viên này vì vẫn còn đăng ký học trong bảng Enrollment.";
                return RedirectToAction(nameof(Index));
            }

            return View(learner);
        }


        // POST: Learners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learner = await _context.Learners.FindAsync(id);
            if (learner != null)
            {
                _context.Learners.Remove(learner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnerExists(int id)
        {
            return _context.Learners.Any(e => e.LearnerID == id);
        }
    }
}

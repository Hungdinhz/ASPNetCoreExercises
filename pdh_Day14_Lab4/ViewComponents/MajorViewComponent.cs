using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pdh_Day14_Lab4.Models;

namespace pdh_Day14_Lab4.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        // Chỉ cần giữ SchoolContext
        private readonly SchoolContext db;

        public MajorViewComponent(SchoolContext context)
        {
            db = context;
            // Không lấy dữ liệu ở đây
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Chỉ lấy dữ liệu khi View Component được gọi
            var list = await db.Majors.ToListAsync();
            return View("RenderMajor", list);
        }
    }
}
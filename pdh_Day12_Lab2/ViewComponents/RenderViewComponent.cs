using Microsoft.AspNetCore.Mvc;
using pdh_Day12_Lab2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pdh_Day12_Lab2.ViewComponents
{
    // ✅ Phải kế thừa ViewComponent
    public class RenderViewComponent : ViewComponent
    {
        private readonly List<MenuItem> menuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            menuItems.Add(new MenuItem { Id = 1, Name = "Home", Link = "/Home/Index" });
            menuItems.Add(new MenuItem { Id = 2, Name = "Student List", Link = "/Student/Index" });
            menuItems.Add(new MenuItem { Id = 3, Name = "Create New Student", Link = "/Student/Create" });
            menuItems.Add(new MenuItem { Id = 4, Name = "About Me", Link = "/Student/AboutMe" });
        }

        // ✅ Chỉ cần 1 trong 2 hàm Invoke hoặc InvokeAsync (nên dùng InvokeAsync)
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Có thể bỏ async nếu không cần await
            return View("RenderLeftMenu", menuItems);
        }
    }
}

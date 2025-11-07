using pdh_Day12_Lab2.Models;

namespace pdh_Day12_Lab2.ViewComponents
{
    public class RenderViewComponent
    {
        private List<MenuItem> menuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            menuItems.Add(new MenuItem { Id = 1, Name = "Home", Link = "/Home/Index" });
            menuItems.Add(new MenuItem { Id = 2, Name = "Student List", Link = "/Student/Index" });
            menuItems.Add(new MenuItem { Id = 3, Name = "Create New Student", Link = "/Student/Create" });
            menuItems.Add(new MenuItem { Id = 4, Name = "About Me", Link = "/Student/AboutMe" });
        }


    }
}

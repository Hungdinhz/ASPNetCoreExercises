using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using thuchanh1_231230796.Models;

namespace thuchanh1_231230796.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        protected Product prd = new Product();
        public IViewComponentResult Invoke()
        {
            var hotProducts = prd.GetProductList();

            return View(hotProducts);
        }
    }
}

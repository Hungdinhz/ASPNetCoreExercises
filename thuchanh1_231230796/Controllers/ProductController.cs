using Microsoft.AspNetCore.Mvc;
using thuchanh1_231230796.Models;

namespace thuchanh1_231230796.Controllers
{
    public class ProductController : Controller
    {
        protected Product prd = new Product();
        public IActionResult Index()
        {
            var products = prd.GetProductList();
            return View(products);
        }
    }
}

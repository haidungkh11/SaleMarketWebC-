using Microsoft.AspNetCore.Mvc;

namespace SaleShop.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

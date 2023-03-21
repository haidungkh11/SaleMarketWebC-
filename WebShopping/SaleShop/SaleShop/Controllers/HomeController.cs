using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleShop.Models;
using SaleShop.ModelViews;
using System.Diagnostics;

namespace SaleShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbMarketsContext _context;
        public HomeController(ILogger<HomeController> logger, dbMarketsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewVM model = new HomeViewVM();
            var lsProducts = _context.Products.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(4)
                .ToList();
            List<ProductHomeVM> lsProductViews = new List<ProductHomeVM>();
            var lsCats = _context.Categories
                .AsNoTracking()
                .Where(x => x.Published == true)
                .OrderByDescending(x => x.Ordering)
                .ToList();
            foreach(var item in lsCats)
            {
                ProductHomeVM productHome = new ProductHomeVM();
                productHome.category = item;
                productHome.lsProducts = lsProducts.Where(x => x.CatID == item.CatId).Take(5).ToList();
               
                lsProductViews.Add(productHome);
                var quangcao = _context.Advertisements
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Active == true);

                var TinTuc = _context.News
                    .AsNoTracking()
                    .Where(x => x.Published == true && x.IsNewfeed == true)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(3)
                    .ToList();
                model.Products = lsProductViews;
                model.advertisements = quangcao;
                model.TinTucs = TinTuc;
                ViewBag.AllProducts = lsProducts;
            }
            return View(model);

        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("lien-he.html", Name = "Contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("gioi-thieu.html", Name = "About")]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using SaleShop.Models;
using System.Runtime.CompilerServices;

namespace SaleShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly dbMarketsContext _context;
        public ProductController(dbMarketsContext context)
        {
            _context = context;
        }
        [Route("shop.html", Name = ("ShopProduct"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var danhmuc = _context.Categories.AsNoTracking().ToList();
                
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsTinDangs = _context.Products
                    .AsNoTracking()
                    .OrderBy(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(lsTinDangs, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
        [Route("danhmuc/{Alias}", Name = ("ListProduct"))]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                
                var pageSize = 10;
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
                var danhmuc2 = _context.Categories.AsNoTracking().Where(x => x.Alias != Alias).ToList();
                var lsTinDangs = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatID == danhmuc.CatId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(lsTinDangs, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                ViewBag.CurrentAlias = danhmuc2;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
        [Route("/{Alias}-{id}.html", Name = ("ProductDetails"))]
        public IActionResult Detail(int id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductID == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                var lsProduct = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatID == product.CatID && x.ProductID != id && x.Active == true)
                    .Take(4)
                    .OrderByDescending(x => x.DateCreated)
                    .ToList();
                
                ViewBag.SanPham = lsProduct;
               
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

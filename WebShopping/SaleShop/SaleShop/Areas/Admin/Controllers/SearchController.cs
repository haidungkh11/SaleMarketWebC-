using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using SaleShop.Models;
using System.Security.Policy;

namespace SaleShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly dbMarketsContext _context;

        public SearchController(dbMarketsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            List<Product> ls = new List<Product>();
            int CatID = 0;
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                ls = _context.Products.AsNoTracking()
                                      .Include(a => a.Category)
                                      .OrderByDescending(x => x.ProductID)
                                      .ToList();
            }
            else
            {
                ls = _context.Products.AsNoTracking()
                                      .Include(a => a.Category)
                                      .Where(x => x.ProductName.Contains(keyword))
                                      .OrderByDescending(x => x.ProductName)
                                      .Take(10)
                                      .ToList();
            }
            
             return PartialView("ListProductsSearchPartial", ls);
            
        }
        

    }
}

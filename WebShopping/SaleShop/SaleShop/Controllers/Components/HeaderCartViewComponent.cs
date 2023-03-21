using Microsoft.AspNetCore.Mvc;
using SaleShop.Extension;
using SaleShop.ModelViews;

namespace SaleShop.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}

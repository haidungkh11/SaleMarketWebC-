using SaleShop.Models;

namespace SaleShop.ModelViews
{
    public class HomeViewVM
    {
        public List<News> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
        public Advertisement advertisements { get; set; }
    }
}

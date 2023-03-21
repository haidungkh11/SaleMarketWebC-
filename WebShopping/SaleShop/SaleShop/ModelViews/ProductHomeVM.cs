using SaleShop.Models;

namespace SaleShop.ModelViews
{
    public class ProductHomeVM
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
      
    }
}

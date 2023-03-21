using SaleShop.Models;
using System.ComponentModel.DataAnnotations;

namespace SaleShop.ModelViews
{
    public class CartItem
    {
        [Key]
        public int cartItemId { get; set; }
        public Product product { get; set; }
        public int amount { get; set; }
        public double TotalMoney => amount * product.Price.Value;
    }
}

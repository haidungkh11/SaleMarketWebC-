
using SaleShop.Models;
using System.ComponentModel.DataAnnotations;

namespace SaleShop.ModelViews
{
    public class XemDonHang
    {
        [Key]
        public int Donhang { get; set; }
        public Order DonHang { get; set; }
        public List<OrderDetail> ChiTietDonHang { get; set; }
    }
}

#nullable disable
namespace SaleShop.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailID { set; get; }
        public int? OrderID { set; get; }
        public int? ProductID { set; get; }
        public int? OrderNumber { get; set; }
        public int? Amount { get; set; }
        public int? Discount { get; set; }
        public int? TotalMoney { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

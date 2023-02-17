#nullable disable
namespace SaleShop.Models
{
    public partial class Product
    {
        public Product()
        {
            AttributesPrices = new HashSet<AttributesPrice>();
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int ProductID { set; get; }
        public string ProductName { set; get; }
        public string ShortDescription { set; get; }
        public int? CatID { set; get; }
        public int? Price { set; get; }
        public int? Discount { set; get; }
        public string? Thumb { set; get; }
        public string Video { set; get; }
        public DateTime? DateCreated { set; get; }
        public DateTime? DateModified { set; get; }
        public bool BestSellers { set; get; }
        public bool HomeFlag { set; get; }
        public bool Active { set; get; }
        public string Tags { set; get; }
        public string? Title { set; get; }
        public string? Alias { set; get; }
        public string? MetaDescription { set; get; }
        public string? MetaKey { set; get; }
        public int? UnitsInStock { set; get; }
        public virtual Category Category { set; get; }
        public virtual ICollection<AttributesPrice> AttributesPrices { set; get; }
        public virtual ICollection<OrderDetail> OrderDetails { set; get; }
    }
}

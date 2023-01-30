using System.Transactions;
#nullable disable
namespace SaleShop.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int OrderID { set; get; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int TransactStatusId { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int TotalMoney { get; set; }
        public int? PaymentId { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public int? LocationId { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }
        public virtual Customer Customer { set; get; }
        public virtual TransactStatus TransactStatus { set; get; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

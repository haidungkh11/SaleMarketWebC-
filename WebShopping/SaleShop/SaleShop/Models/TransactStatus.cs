#nullable disable
namespace SaleShop.Models
{
    public partial class TransactStatus
    {
        public TransactStatus()
        {
            Orders = new HashSet<Order>();
        }
        public int TransactStatusID { set; get; }
        public string Status { set; get; }
        public string Description { set; get; }
        public virtual ICollection<Order> Orders { set; get; }
    }
}

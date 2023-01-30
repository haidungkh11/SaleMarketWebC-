#nullable disable
namespace SaleShop.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}

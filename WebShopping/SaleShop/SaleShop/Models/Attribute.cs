﻿#nullable disable
namespace SaleShop.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            AttributesPrices = new HashSet<AttributesPrice>();
        }
        public int AttributeID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AttributesPrice> AttributesPrices { get; set; }
    }
}

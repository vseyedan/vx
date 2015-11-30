using System.ComponentModel;

namespace Anbar.Models
{
    public class ProductInventory
    {
        public int ID { get; set; }
        [DisplayName("محصول")]
        public int ProductID { get; set; }
        [DisplayName("انبار")]
        public int InventoryID { get; set; }
        [DisplayName("موجودی انبار")]
        public int InventoryQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Inventory Inventory { get; set; }

    }
}
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models
{
    public class Inventory
    {
        public int ID { get; set; }


        [DisplayName("نام انبار")]
        [Required]
        [StringLength(50)]
        public string InventoryName { get; set; }

        [DisplayName("شرح انبار")]
        [StringLength(100)]
        public string Description { get; set; }

        public virtual  ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual  ICollection<TransactionDetail>  TransactionDetails { get; set; }

    }
}
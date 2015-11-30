using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        [DisplayName("نام فروشنده")]
        public string SupplierName { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }
        public virtual ICollection<Transaction>  Transactions { get; set; }


    }
}
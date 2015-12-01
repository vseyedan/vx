using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models
{
    
    [DisplayName("فروشنده")]
    public class Supplier
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        [DisplayName("نام فروشنده")]
        public string SupplierName { get; set; }

        [StringLength(20)]
        [DisplayName("تلفن")]
        public string Phone { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        [DisplayName("آدرس")]
        public string Address { get; set; }

       
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        public virtual ICollection<Transaction>  Transactions { get; set; }


    }
}
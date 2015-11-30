using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("نام گروه محصول")]
        [StringLength(50,MinimumLength =1)]
        public string CategoryName { get; set; }

        public virtual  ICollection<Product> Products { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        [DisplayName("نام مرکز هزینه")]
        public string DepartmentName { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        public virtual      ICollection<Transaction> Transactions { get; set; }


    }
}
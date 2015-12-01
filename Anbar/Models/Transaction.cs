using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anbar.Models

{
    public  enum TransactionType
        {
        //ورود, خروج, انتقال
        
        ورود = 0,
        مصرف = 1,
        خروج = 2,
        انتقال = 3,
        ضایعات  =4,
        افتتاحیه =5,
        اختتامیه =6      
    }

    public class Transaction
    {
        public int ID { get; set; }

        [DisplayName("نوع تراکنش")]
        [Required]
        public TransactionType TransactionType { get; set; }

        [DisplayName("شماره برگه")]
        [Required]
        public string TransactionNo { get; set; }

        [UIHint("ShamsiDate")]
        [DisplayName("تاریخ سند")]
        [Required]
        public DateTime TransactionDate { get; set; }

        //[DisplayName("تاریخ")]
        //[Range(13000101,14991230)]
        //[DisplayFormat(ApplyFormatInEditMode =false,DataFormatString ="{0:####/##/##}")]
        //[Required]
        //public int TransactionDate { get; set; }

        [DisplayName("توضیحات")]
        [DataType(DataType.MultilineText)]
        [UIHint("TextArea")]
        [StringLength(200)]
        public string Description { get; set; }


        [DisplayName("فروشنده")]   
        public int? Entry_SupplierID { get; set; }

        [DisplayName("دایره مصرف کننده")]
        public int? Exit_DepartmentID { get; set; }



        public virtual ICollection<TransactionDetail>  TransactionDetails { get; set; } 
        public virtual  Supplier Entry_Supplier { get; set; }
        public virtual Department Exit_Department { get; set; }

    }
}
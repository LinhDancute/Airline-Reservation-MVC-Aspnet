using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Statistical
{

    public class Invoice
    {
        [Key]
        public string InvoiceId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(12)]
        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "CMND")]
        public string CMND { get; set; }

        [Required]
        [Display(Name = "Nhân viên")]
        public string StaffId { set; get; }
        [ForeignKey("StaffId")]
        [Display(Name = "Nhân viên")]
        public AppUser Staff { set; get; }

        public int MonthlyRevenueId { get; set; }

        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }


        [Required(ErrorMessage = "{0} không được trống")]
        [Display(Name = "Thành tiền")]
        public decimal TotalAmount { get; set; }


    }
}
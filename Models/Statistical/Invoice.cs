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

        public int MonthlyRevenueId { get; set; }

        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }
        public string StaffId { get; set; }

        [Required(ErrorMessage = "{0} không được trống")]
        [Display(Name = "Thành tiền")]
        public decimal TotalAmount { get; set; }
        
        public MonthlyRevenue MonthlyRevenue { get; set; }
        public Models.Staff.Staff Staff { get; set; }

        [Required]
        [Display(Name = "Khách hàng")]
        public string? PassengerId { set; get; }

        [Display(Name = "Khách hàng")]
        public AppUser? Passenger { set; get; }
    }
}
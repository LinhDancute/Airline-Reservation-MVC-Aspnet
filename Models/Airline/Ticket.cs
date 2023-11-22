using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models.Statistical;

namespace App.Models.Airline
{
    public class Ticket{
        [Key]
        public string TicketId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(12)]
        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "CMND")]
        public string CMND { get; set; }

        [Required(ErrorMessage = "Phải nhập chuyến bay")]
        [Display(Name = "Chuyến bay")]
        public string FlightId { get; set; }
        public int PriceId { get; set; }

        [Display(Name = "Phát hành")]
        public bool Published { get; set; }

        public Flight Flight { get; set; }
        public UnitPrice UnitPrice { get; set; }

        [Required]
        [Display(Name = "Khách hàng")]
        public string? PassengerId { set; get; }

        [Display(Name = "Khách hàng")]
        public AppUser? Passenger { set; get; }
    }

}
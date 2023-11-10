using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{
    public class Ticket{
        [Key]
        public int TicketId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(12)]
        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "CMND")]
        public String CMND { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập chuyến bay")]
        [Display(Name = "Chuyến bay")]
        public String FlightId { get; set; }
        public int PriceId { get; set; }

        [Display(Name = "Phát hành")]
        public bool Published { get; set; }


    }

}
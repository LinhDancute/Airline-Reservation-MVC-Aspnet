using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        public int AirlineId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Phải nhập giờ bay")]
        [Display(Name = "Giờ bay")]
        public float FlightTime { get; set; }
        public int? EcoSeat { get; set; }
        public int? DeluxeSeat { get; set; }
        public int? SkyBossSeat { get; set; }
        public int? SkyBossBusinessSeat { get; set; }

        public Airline Airline { get; set; }

        // ChuyenBay - PhieuDatCho : n-1
        // ChuyenBay - VeMayBay : n-1
        public ICollection<BoardingPass>? BoardingPasses { get; } = new List<BoardingPass>();
        public ICollection<Ticket>? Tickets { get; } = new List<Ticket>();

    }
}
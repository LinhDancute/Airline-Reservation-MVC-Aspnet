using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class Flight
    {
        [Key]
        public string FlightId { get; set; }

        public string AirlineId { get; set; }
        public string FlightDetailId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Phải nhập giờ bay")]
        [Display(Name = "Giờ bay")]
        public float FlightTime { get; set; }
        public int? EcoSeat { get; set; }
        public int? DeluxeSeat { get; set; }
        public int? SkyBossSeat { get; set; }
        public int? SkyBossBusinessSeat { get; set; }
    }
}
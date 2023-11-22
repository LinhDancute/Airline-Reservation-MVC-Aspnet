using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class BoardingPass
    {
        [Key]
        [StringLength(6)]
        public string BoardingPassId { get; set; }
        public string FlightId { get; set; }
        public string CMND { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        public int Seat { get; set; }

        [Required]
        [Display(Name = "Khách hàng")]
        public string? PassengerId { set; get; }
        
        [Display(Name = "Khách hàng")]
        public AppUser? Passenger { set; get; }

        public Flight Flight { get; set; }


    }

}
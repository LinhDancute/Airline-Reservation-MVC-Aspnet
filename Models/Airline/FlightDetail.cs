using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class FlightDetail
    {
        [Key]
        public string FlightDetailId { get; set; }

        public string FlightId { get; set; }

        [Display(Name = "Sân bay trung gian")]
        public string? IntermediateAirport { get; set; }

        [Display(Name = "Thời gian dừng")]
        public float? LayoverTime { get; set; }

        [Display(Name = "Ghi chú")]
        public string? Description { set; get; }

        public Flight Flight { get; set; }
    }
}
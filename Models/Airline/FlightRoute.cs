using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class FlightRoute
    {
        [Key]
        public string FlightRouteId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập điểm đi")]
        [Display(Name = "Điểm đi")]
        public string DepartureAddress { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập điểm đến")]
        [Display(Name = "Điểm đến")]
        public string ArrivalAddress { get; set; }

        [Display(Name = "Cổng quốc tế/nội địa")]
        public GateType Gate { get; set; }
    }

    public enum GateType
    {
        DomesticGate,
        InternationalGate
    }

}
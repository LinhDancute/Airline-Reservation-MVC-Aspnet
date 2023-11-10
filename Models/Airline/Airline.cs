using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class Airline
    {
        [Key]
        public string AirlineId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập tên máy bay")]
        [Display(Name = "Tên máy bay")]
        public AirlineType AirlineName { get; set; }

        public enum AirlineType
        {
            SkybossBusiness,
            Skyboss,
            Deluxe,
            Eco
        }
    }
}
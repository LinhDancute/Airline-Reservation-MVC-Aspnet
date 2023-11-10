using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Statistical
{

    public class UnitPrice
    {
        [Key]
        public int PriceId { get; set; }
        public decimal USD { get; set; }
        public decimal VND { get; set; }

    }
}
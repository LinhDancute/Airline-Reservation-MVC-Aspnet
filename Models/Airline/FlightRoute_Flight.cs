using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    [Table("FlightRoute_Flight")]
    public class FlightRoute_Flight
    {
        public String FlightRouteID { set; get; }
        public String FlightID { set; get; }


        [ForeignKey("FlightRouteID")]
        public FlightRoute FlightRoute { set; get; }

        [ForeignKey("FlightID")]
        public Flight Flight { set; get; }
    }

}
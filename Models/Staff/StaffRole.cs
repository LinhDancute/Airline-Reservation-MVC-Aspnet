using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models.Airline;
using App.Models.Statistical;
using Bogus.DataSets;
using Microsoft.AspNetCore.Identity;

namespace App.Models.Staff
{
    public class StaffRole
    {
        public string StaffId { set; get; }
        public string RoleId { set; get; }


        [ForeignKey("StaffId")]
        public Staff Staff { set; get; }

        [ForeignKey("RoleId")]
        public IdentityRole Role { set; get; }
    }
}
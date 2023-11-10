using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bogus.DataSets;
using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class AppUser : IdentityUser {
        [Column(TypeName ="nvarchar")]
        [StringLength(400)]
        public string? HomeAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(12)]
        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "CMND")]
        public string CMND { get; set; }
        
    }
}
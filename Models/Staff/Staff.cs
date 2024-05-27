using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models.Airline;
using App.Models.Statistical;
using Bogus.DataSets;
using Microsoft.AspNetCore.Identity;

namespace App.Models.Staff
{
    public class Staff
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Sai định dạng mail")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^[0-9]{10,11}$", ErrorMessage = "Sai định dạng số điện thoại")]
        public string PhoneNumber { get; set; }

        public ICollection<StaffRole> StaffRoles { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
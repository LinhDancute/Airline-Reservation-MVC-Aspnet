using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class TicketClass
    {
        [Key]
        public string TicketId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập hạng vé")]
        [Display(Name = "Tên hạng vé")]
        public string TicketName { get; set; }

    }
}
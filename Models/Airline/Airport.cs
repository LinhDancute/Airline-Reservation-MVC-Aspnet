using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{

    public class Airport
    {
        [Key]
        public int AirportId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập  {0}")]
        [Display(Name = "Tên sân bay")]
        public string AirportName { get; set; }

        // Nội dung, thông tin chi tiết về sân bay
        [DataType(DataType.Text)]
        [Display(Name = "Nội dung mô tả sân bay")]
        public string? Description { set; get; }

        [Display(Name = "Phân loại sân bay")]
        public AirportClassification Classification { get; set; }
        public enum AirportClassification
        {
            Domestic,
            International
        }

        // N-N relationship with TuyenBay
        public ICollection<FlightRoute_Airport>? FlightRoute_Airports { get; set; }
    }
}
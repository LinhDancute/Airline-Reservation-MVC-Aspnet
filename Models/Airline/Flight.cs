using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Airline
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        public int? AirlineId { get; set; }

        [Display(Name = "Máy bay")]
        public string? Aircraft { set; get; }

        // số hiệu chuyến bay
        [Required(ErrorMessage = "Phải nhập số hiệu chuyến bay")]
        [Display(Name = "Số hiệu chuyến bay")]
        public string? FlightNumber { get; set; }

        [Display(Name = "Chặng bay")]
        public string? FlightSector { get; set; }

        [Required(ErrorMessage = "Phải nhập giờ bay")]
        [Display(Name = "Giờ bay")]
        public float? FlightTime { get; set; }

        [Required(ErrorMessage = "Phải chọn giờ khởi hành")]
        [Display(Name = "Giờ khởi hành")]
        public TimeSpan? DepartureTime { get; set; }

        [Required(ErrorMessage = "Phải chọn giờ đến")]
        [Display(Name = "Giờ đến")]
        public TimeSpan? ArrivalTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày/giờ ")]
        public DateTime Date { get; set; }

        [Display(Name = "Số ghế hạng tiêu chuẩn")]
        public int? EcoSeat { get; set; }

        [Display(Name = "Số ghế hạng phổ thông đặc biệt")]
        public int? DeluxeSeat { get; set; }

        [Display(Name = "Số ghế hạng cao cấp")]
        public int? SkyBossSeat { get; set; }

        [Display(Name = "Số ghế hạng thương gia")]
        public int? SkyBossBusinessSeat { get; set; }
        
        [Column("Status")]
        [Display(Name = "Trạng thái hoạt động")]
        public StatusType Status { get; set; }

        public enum StatusType
        {
            Active,
            Inactive
        }

        public Airline? Airline { get; set; }

        // ChuyenBay - PhieuDatCho : n-1
        // ChuyenBay - VeMayBay : n-1
        public ICollection<BoardingPass>? BoardingPasses { get; } = new List<BoardingPass>();
        public ICollection<Ticket>? Tickets { get; } = new List<Ticket>();
        public ICollection<FlightRoute_Flight>? FlightRoute_Flights { get; set; } = new List<FlightRoute_Flight>();
    }
}
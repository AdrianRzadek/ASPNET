using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class ReservationViewModel
    {
        [Required]
        public int ID { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
       
        public int Phone { get; set; }
        public int VehicleId { get; set; }

        public DateTime? ReservationDate { get; set; }
        public DateTime ?ReservationDateEnd { get; set; }
        public string? Status { get; set; }
    }
}

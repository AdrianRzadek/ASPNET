using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class ReservationViewModel
    {
        [Required]
        public int ID { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [Phone]
        public int Phone { get; set; }

        [DateValidation]
        public DateTime? ReservationDate { get; set; }

        [DateValidation(ErrorMessage = "Data końca rezerwacji nie może być wcześniejsza niż data rozpoczęcia rezerwacji.")]
        public DateTime? ReservationDateEnd { get; set; }
    }
}

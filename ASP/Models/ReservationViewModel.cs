namespace ASP.Models
{
    public class ReservationViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DateValidation]
        public DateTime? ReservationDate { get; set; }

        [DateValidation(ErrorMessage = "Data końca rezerwacji nie może być wcześniejsza niż data rozpoczęcia rezerwacji.")]
        public DateTime? ReservationDateEnd { get; set; }
    }
}

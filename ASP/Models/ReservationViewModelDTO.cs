namespace ASP.Models
{
    public class ReservationViewModelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

      
        public DateTime? ReservationDate { get; set; }

       
        public DateTime? ReservationDateEnd { get; set; }
    }
}

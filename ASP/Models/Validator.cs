using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public bool IsValid(ReservationViewModel reservation)
        {
            if (reservation.ReservationDate > reservation.ReservationDateEnd)
            {
                return false;
            }

            return true;
        }



    }

}

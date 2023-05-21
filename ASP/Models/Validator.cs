using System.ComponentModel.DataAnnotations;
using ASP.Areas.Users.Models;

namespace ASP.Models
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public bool IsValid(ReservationViewModel reservationViewModel)
        {
            if (reservationViewModel.ReservationDate > reservationViewModel.ReservationDateEnd)
            {
                return false;
            }

            return true;
        }

       

    }

}

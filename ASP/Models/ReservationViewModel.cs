using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class ReservationViewModel
    {
        //public PageContext PageContext;
        //public TempDataDictionary TempData;
        //public UrlHelper Url;
        //public object ModelState;

        [Required]
        public int ID { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
       
        public int Phone { get; set; }
        public int? VehicleId { get; set; }

        public DateTime? ReservationDate { get; set; }
        public DateTime ?ReservationDateEnd { get; set; }
        public string? Status { get; set; }
    

       
    }
}

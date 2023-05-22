using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Models
{
    public class VehicleViewModel
    {
        [Required]
        [Key]
        public int VehicleId { get; set; }
        [StringLength(10)]
        public string VehicleName { get; set; }
        [StringLength(30)]
        public string VehicleMark { get; set; }
         public string VehicleColor {get; set; }
         public string VehiclePrice {  get; set; }


    }
}

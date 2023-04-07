using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Models
{
    public class VehicleViewModelDTO
    {
        [Required]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
      // [ForeignKey("VehicleDetailViewModel")]
     //  public virtual int VehicleId { get; set; }

      //  public virtual VehicleDetailViewModel VehicleDetailViewModel { get; set; }

    }
}

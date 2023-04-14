using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Models
{
    public class VehicleViewModel
    {
        [Required]
        public int ID { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Description { get; set; }


    }
}

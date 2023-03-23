using Microsoft.AspNetCore.Mvc;


namespace ASP.Controllers
{
    public class VehiclesController : Controller
    {


        List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle(){ VehicleId = 1, VehicleName = "Rower1", VehicleMark = "Ghost", VehicleColor = "Green", VehiclePrice = 50},
            new Vehicle(){ VehicleId = 2, VehicleName = "Rower2", VehicleMark = "Merida", VehicleColor = "Black", VehiclePrice = 60},
            new Vehicle(){ VehicleId = 3, VehicleName = "Rower3", VehicleMark = "KTM", VehicleColor = "Silver", VehiclePrice = 70},
            new Vehicle(){ VehicleId = 4, VehicleName = "Rower4", VehicleMark = "Canyon", VehicleColor = "Blue", VehiclePrice = 80}
        };
        public IActionResult Index()
        {
            return View(vehicles);
        }
        public IActionResult VehicleDetails(int vehicleId)
        {
            var result = vehicles.FirstOrDefault(r => r.VehicleId == vehicleId);
            return View(result);
        }
        public IActionResult VehicleList(int vehicleId)
        {
            var result = vehicles.FirstOrDefault(r => r.VehicleId == vehicleId);
            return View(result);
        }
    }

    class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleMark { get; set; }
        public string VehicleColor { get; set; }
        public int VehiclePrice { get; set; }
    }
}

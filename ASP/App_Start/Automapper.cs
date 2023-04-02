using ASP.Controllers;
using ASP.Models;
using AutoMapper;
using ASP.Data;

namespace ASP.App_Start
{
    public class Automapper:Profile
    {
        public MapperConfiguration Configure()
        {

            var config = new MapperConfiguration(cfg =>

                {
                    cfg.CreateMap<VehicleDetailViewModel, VehicleViewModel>();
                    cfg.CreateMap<VehicleViewModel, VehicleDetailViewModel>();
                  
                  // cfg.CreateMap<RentalPoint, RentalPoints>();
                   // cfg.CreateMap<RentalPoints, RentalPoint>();
                });
            return config;
            
        }
    }
}

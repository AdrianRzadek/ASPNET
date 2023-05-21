using ASP.Areas.Users.Models;
using ASP.Data;
using ASP.Models;
using AutoMapper;
using System.Configuration;

namespace ASP.App_Start
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            CreateMap<VehicleViewModelDTO, VehicleViewModel>().ReverseMap();
           
           CreateMap<ReservationViewModelDTO, ReservationViewModel>().ReverseMap();

        }

    }
}

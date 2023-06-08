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

           

            CreateMap<VehicleViewModel, ReservationViewModel>().ReverseMap();

        }

    }
}

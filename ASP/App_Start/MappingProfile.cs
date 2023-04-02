using ASP.Models;
using AutoMapper;

namespace ASP.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleDetailViewModel,VehicleViewModel>().ReverseMap();
            CreateMap<VehicleViewModel, VehicleDetailViewModel>().ReverseMap();
        }
    }
}

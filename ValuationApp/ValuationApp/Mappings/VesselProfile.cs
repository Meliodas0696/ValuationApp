using AutoMapper;
using ValuationApp.Entities;
using ValuationApp.ValuationDto;

namespace ValuationApp.Mappings
{
    public class VesselProfile : Profile
    {
        public VesselProfile()
        {
            CreateMap<Vessel, VesselDto>().ReverseMap();
            CreateMap<Vessel, CreateVesselDto>().ReverseMap();
        }
    }
}

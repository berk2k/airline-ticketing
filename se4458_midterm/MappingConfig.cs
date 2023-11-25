using AutoMapper;
using se4458_midterm.Models;
using se4458_midterm.Models.Dto;

namespace se4458_midterm
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<Flight,FlightDTO>();
            CreateMap<FlightDTO, Flight>();
        }
    }
}

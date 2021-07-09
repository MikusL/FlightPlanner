using AutoMapper;
using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Models;

namespace FlightPlanner.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirportDto, Airport>()
                    .ForMember(d => d.AirportName, s => s.MapFrom(p => p.Airport))
                    .ForMember(d => d.Id, s => s.Ignore());
                cfg.CreateMap<Airport, AirportDto>()
                    .ForMember(d => d.Airport, s => s.MapFrom(p => p.AirportName));
                cfg.CreateMap<Flight, AddFlightRequest>();
                cfg.CreateMap<AddFlightRequest, Flight>()
                    .ForMember(d => d.Id, s => s.Ignore());
                cfg.CreateMap<FlightDto, Flight>()
                    .ForMember(d => d.FromId, s => s.Ignore())
                    .ForMember(d => d.ToId, s => s.Ignore());
                cfg.CreateMap<Flight, FlightDto>();
            });

            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
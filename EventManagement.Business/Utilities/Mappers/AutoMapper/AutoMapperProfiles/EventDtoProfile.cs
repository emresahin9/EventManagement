using AutoMapper;
using EventManagement.Entity.Concrete;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class EventDtoProfile : Profile
    {
        public EventDtoProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
        }
    }
}

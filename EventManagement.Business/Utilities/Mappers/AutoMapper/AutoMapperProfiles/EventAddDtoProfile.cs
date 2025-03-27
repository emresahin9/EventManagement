using AutoMapper;
using EventManagement.Entity.Concrete;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class EventAddDtoProfile : Profile
    {
        public EventAddDtoProfile()
        {
            CreateMap<EventAddDto, Event>();
        }
    }
}

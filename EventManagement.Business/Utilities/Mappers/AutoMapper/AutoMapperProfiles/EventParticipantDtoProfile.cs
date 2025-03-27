using AutoMapper;
using EventManagement.Entity.Concrete;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class EventParticipantDtoProfile : Profile
    {
        public EventParticipantDtoProfile()
        {
            CreateMap<EventParticipant, EventParticipantDto>().PreserveReferences();
        }
    }
}

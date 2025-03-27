using AutoMapper;
using EventManagement.Entity.Concrete;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class EventParticipationStatusDtoProfile : Profile
    {
        public EventParticipationStatusDtoProfile()
        {
            CreateMap<EventParticipationStatus, EventParticipationStatusDto>();
        }
    }
}

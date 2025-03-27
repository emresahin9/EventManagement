using AutoMapper;
using EventManagement.Entity.Concrete;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class ParticipantDtoProfile : Profile
    {
        public ParticipantDtoProfile()
        {
            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantDto, Participant>();
        }
    }
}

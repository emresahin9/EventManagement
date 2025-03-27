using AutoMapper;
using EventManagement.Entity.Concrete;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class ParticipantOnlyNameDtoProfile : Profile
    {
        public ParticipantOnlyNameDtoProfile()
        {
            CreateMap<Participant, ParticipantOnlyNameDto>()
                .ForMember(x => x.Name, i => i.MapFrom(x => $"{x.FirstName} {x.LastName}"));
        }
    }
}

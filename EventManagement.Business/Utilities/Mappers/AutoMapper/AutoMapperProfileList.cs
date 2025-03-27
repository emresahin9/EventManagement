using AutoMapper;
using EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapperProfiles;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper
{
    internal static class AutoMapperProfileList
    {
        internal static List<Profile> GetAllProfile()
        {

            return new List<Profile>() {
                new EventDtoProfile(),
                new EventAddDtoProfile(),
                new ParticipantDtoProfile(),
                new ParticipantOnlyNameDtoProfile(),
                new EventParticipationStatusDtoProfile(),
                new EventParticipantDtoProfile()
            };

        }
    }
}


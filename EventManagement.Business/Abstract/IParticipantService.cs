using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Abstract
{
    public interface IParticipantService
    {
        ParticipantDto GetById(int id);
        List<ParticipantDto> GetAll();
        void Add(ParticipantDto model);
        List<ParticipantOnlyNameDto> GetAllAvailable();

        void Update(ParticipantDto model);
        void DeleteById(int id);
    }
}

using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Abstract
{
    public interface IEventParticipationStatusService
    {
        EventParticipationStatusDto GetById(int id);
        List<EventParticipationStatusDto> GetAll();
    }
}

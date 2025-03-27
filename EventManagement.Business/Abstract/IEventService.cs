using EventManagement.Model.Concrete.Dto;
using EventManagement.Model.Concrete.Vm;

namespace EventManagement.Business.Abstract
{
    public interface IEventService
    {
        EventDto GetById(int id);
        List<EventDto> GetAll();
        void Add(EventAddDto model);
        EditParticipantsViewModel GetEditParticipants(int eventId);
        void UpdateEventParticipants(EditParticipantsViewModel model);
        void Update(EventDto model);
        void DeleteById(int id);
    }
}

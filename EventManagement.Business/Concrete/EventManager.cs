using EventManagement.Business.Abstract;
using EventManagement.Business.Utilities.Aspects.Autofac.Validation;
using EventManagement.Business.Utilities.Mappers;
using EventManagement.Business.Utilities.Validation.FluentValidation.Rules;
using EventManagement.DataAccess.Abstract;
using EventManagement.Entity.Concrete;
using EventManagement.Model.Concrete.Dto;
using EventManagement.Model.Concrete.Vm;
using Microsoft.EntityFrameworkCore;
using MapperType = EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapper;

namespace EventManagement.Business.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventDal _eventDal;
        private readonly IEventParticipantDal _eventParticipantDal;
        private readonly IParticipantDal _participantDal;
        public EventManager(IEventDal eventDal, IEventParticipantDal eventParticipantDal, IParticipantDal participantDal)
        {
            _eventDal = eventDal;
            _eventParticipantDal = eventParticipantDal;
            _participantDal = participantDal;
        }

        public EventDto GetById(int id)
        {
            var entity = _eventDal.Get(x => x.Id == id, i => i.Include(x => x.EventParticipants).ThenInclude(x => x.Participant));
            var model = MapperTool<MapperType>.Map<Event, EventDto>(entity);
            return model;
        }

        public List<EventDto> GetAll()
        {
            var entities = _eventDal.GetAll();
            return MapperTool<MapperType>.Map<List<Event>, List<EventDto>>(entities);
        }

        [ValidationAspect(typeof(EventAddDtoValidator))]
        public void Add(EventAddDto model)
        {
            var entity = MapperTool<MapperType>.Map<EventAddDto, Event>(model);
            _eventDal.Add(entity);

            _eventParticipantDal.DeleteRange(x => x.EventId == entity.Id);

            if (model.SelectedParticipantIds != null)
            {
                foreach (var participantId in model.SelectedParticipantIds)
                {
                    _eventParticipantDal.Add(new EventParticipant { EventId = entity.Id, ParticipantId = participantId });
                }
            }
        }

        public EditParticipantsViewModel GetEditParticipants(int eventId)
        {
            var participants = MapperTool<MapperType>.Map<List<Participant>, List<ParticipantOnlyNameDto>>(_participantDal.GetAll(x => x.EventParticipationStatusId == 1));
            var selectedParticipantIds = _eventParticipantDal.GetAll(x => x.EventId == eventId).Select(x => x.ParticipantId).ToList();
            var model = new EditParticipantsViewModel
            {
                EventId = eventId,
                Participants = participants,
                SelectedParticipantIds = selectedParticipantIds
            };

            return model;
        }

        public void UpdateEventParticipants(EditParticipantsViewModel model)
        {
            _eventParticipantDal.DeleteRange(x => x.EventId == model.EventId);

            if (model.SelectedParticipantIds != null)
            {
                foreach (var participantId in model.SelectedParticipantIds)
                {
                    _eventParticipantDal.Add(new EventParticipant { EventId = model.EventId, ParticipantId = participantId });
                }
            }
        }

        [ValidationAspect(typeof(EventDtoValidator))]
        public void Update(EventDto model)
        {
            var entity = MapperTool<MapperType>.Map<EventDto, Event>(model);
            _eventDal.Update(entity);
        }

        public void DeleteById(int id)
        {
            _eventDal.Delete(x => x.Id == id);
        }
    }
}

using EventManagement.Entity.Concrete;
using EventManagement.DataAccess.Abstract;
using EventManagement.Business.Abstract;
using EventManagement.Business.Utilities.Mappers;
using MapperType = EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapper;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Business.Concrete
{
    public class EventParticipationStatusManager : IEventParticipationStatusService
    {
        private readonly IEventParticipationStatusDal _eventParticipationStatusDal;
        public EventParticipationStatusManager(IEventParticipationStatusDal eventParticipationStatusDal)
        {
            _eventParticipationStatusDal = eventParticipationStatusDal;
        }

        public EventParticipationStatusDto GetById(int id)
        {
            var entity = _eventParticipationStatusDal.Get(x => x.Id == id);
            return MapperTool<MapperType>.Map<EventParticipationStatus, EventParticipationStatusDto>(entity);
        }

        public List<EventParticipationStatusDto> GetAll()
        {
            var entities = _eventParticipationStatusDal.GetAll();
            return MapperTool<MapperType>.Map<List<EventParticipationStatus>, List<EventParticipationStatusDto>>(entities);
        }

    }
}

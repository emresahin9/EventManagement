using EventManagement.Entity.Concrete;
using EventManagement.DataAccess.Abstract;
using EventManagement.Business.Utilities.Aspects.Autofac.Validation;
using EventManagement.Business.Abstract;
using EventManagement.Business.Utilities.Mappers;
using MapperType = EventManagement.Business.Utilities.Mappers.AutoMapper.AutoMapper;
using EventManagement.Model.Concrete.Dto;
using Microsoft.EntityFrameworkCore;
using EventManagement.Business.Utilities.Validation.FluentValidation.Rules;

namespace EventManagement.Business.Concrete
{
    public class ParticipantManager : IParticipantService
    {
        private readonly IParticipantDal _participantDal;
        private readonly IEventParticipantDal _eventParticipantDal;
        public ParticipantManager(IParticipantDal eventDal, IEventParticipantDal eventParticipantDal)
        {
            _participantDal = eventDal;
            _eventParticipantDal = eventParticipantDal;
        }

        public ParticipantDto GetById(int id)
        {
            var entity = _participantDal.Get(x => x.Id == id);
            return MapperTool<MapperType>.Map<Participant, ParticipantDto>(entity);
        }

        public List<ParticipantDto> GetAll()
        {
            var entities = _participantDal.GetAll(null, x => x.Include(i => i.EventParticipationStatus));
            return MapperTool<MapperType>.Map<List<Participant>, List<ParticipantDto>>(entities);
        }

        [ValidationAspect(typeof(ParticipantDtoValidator))]
        public void Add(ParticipantDto model)
        {
            var entity = MapperTool<MapperType>.Map<ParticipantDto, Participant>(model);
            _participantDal.Add(entity);
        }
        public List<ParticipantOnlyNameDto> GetAllAvailable()
        {
            var entities = _participantDal.GetAll(x => x.EventParticipationStatusId == 1);
            return MapperTool<MapperType>.Map<List<Participant>, List<ParticipantOnlyNameDto>>(entities);
        }

        [ValidationAspect(typeof(ParticipantDtoValidator))]
        public void Update(ParticipantDto model)
        {
            var entity = MapperTool<MapperType>.Map<ParticipantDto, Participant>(model);
            if(entity.EventParticipationStatusId == 2)
            { 
                _eventParticipantDal.DeleteRange(x => x.ParticipantId == model.Id);
            }
            _participantDal.Update(entity);
        }

        public void DeleteById(int id)
        {
            _participantDal.Delete(x => x.Id == id);
        }

    }
}

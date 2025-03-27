using EventManagement.Entity.Concrete;

namespace EventManagement.DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
    }
}

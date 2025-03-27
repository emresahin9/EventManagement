using EventManagement.DataAccess.Abstract;
using EventManagement.DataAccess.Concrete.EntityFramework.Contexts;
using EventManagement.Entity.Concrete;

namespace EventManagement.DataAccess.Concrete.EntityFramework.EfDals
{
    public class EfParticipantDal : EfEntityRepositoryBase<Participant, EventManagementContext>, IParticipantDal
    {
    }
}

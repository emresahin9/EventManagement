using Autofac;
using EventManagement.DataAccess.Abstract;
using EventManagement.DataAccess.Concrete.EntityFramework.EfDals;

namespace EventManagement.DataAccess.DependencyResolvers.Autofac
{
    public class AutofacDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfEventDal>().As<IEventDal>().SingleInstance();
            builder.RegisterType<EfParticipantDal>().As<IParticipantDal>().SingleInstance();
            builder.RegisterType<EfEventParticipantDal>().As<IEventParticipantDal>().SingleInstance();
            builder.RegisterType<EfEventParticipationStatusDal>().As<IEventParticipationStatusDal>().SingleInstance();
        }
    }
}

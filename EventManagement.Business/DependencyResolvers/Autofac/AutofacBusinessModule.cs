using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EventManagement.Business.Abstract;
using EventManagement.Business.Concrete;
using EventManagement.Business.Utilities.Interceptors;

namespace EventManagement.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventManager>().As<IEventService>();
            builder.RegisterType<ParticipantManager>().As<IParticipantService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

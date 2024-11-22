
using Autofac;
using TaskExaminantionSystem.Data;
using TaskExaminantionSystem.Data.Repository;

namespace TaskExaminantionSystem.Config
{
    public class AutoFacService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GRepository<>)).As(typeof(IGRepository<>)).InstancePerLifetimeScope();
        }
    }
}

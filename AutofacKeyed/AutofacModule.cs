using Autofac;
using AutofacKeyed.Wrappers;

namespace AutofacKeyed
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<RemoteClient>().As<IRemoteClient>().SingleInstance();

            builder.RegisterGeneric(typeof(DbCommandWrapper<,>))
                .AsImplementedInterfaces()
                .Keyed(WrapperTypes.DbWrapper, typeof(ICommandWrapper<,>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RemoveServiceCommandWrapper<,>))
                .AsImplementedInterfaces()
                .Keyed(WrapperTypes.RemoteService, typeof(ICommandWrapper<,>))
                .InstancePerLifetimeScope();
        }
    }
}

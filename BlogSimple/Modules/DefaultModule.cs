using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlogSimple.Model;
using BlogSimple.Repository;
using BlogSimple.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module = Autofac.Module;

namespace BlogSimple.Modules
{
    public class DefaultModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("BlogSimple.Repository"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("BlogSimple.Service")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType(typeof(BlogSimpleContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
        }
    }

    public class RegisterModules
    {
        public static IContainer RegisterModule(IServiceCollection services)
        {
            var container = new ContainerBuilder();
            container.RegisterModule<DefaultModule>();
            container.Populate(services);
            return container.Build();
        }
    }
}

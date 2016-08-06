using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Data;
using Data.Interfaces;

namespace Infrastructure.IOC
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityBaseRepo<>)).As(typeof(IEntityBaseRepo<>)).InstancePerRequest();

        }
    }
}

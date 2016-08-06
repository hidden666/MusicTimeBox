using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Membership;
using Membership.Interfaces;

namespace Membership.IOC
{
    public class MembershipModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerRequest();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerRequest();
        }
    }
}
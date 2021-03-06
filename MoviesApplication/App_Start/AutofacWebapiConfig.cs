﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using Autofac;
using Autofac.Integration.WebApi;
using Infrastructure.IOC;
using Membership.IOC;
using Microsoft.Ajax.Utilities;

namespace MoviesApplication.App_Start
{
    public static class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        private static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterModule<DataModule>();
            containerBuilder.RegisterModule<MembershipModule>();

            Container = containerBuilder.Build();

            return Container;

        }

    }
}
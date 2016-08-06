using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MoviesApplication.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //// configure IOC autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);

            /// configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
    }
}
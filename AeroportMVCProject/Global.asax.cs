﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AeroportBusinessLogic;
using AeroportBusinessLogic.AccountMethods;
using AeroportBusinessLogic.FlightMethods;
using AeroportBusinessLogic.Models;
using AeroportBusinessLogic.PassMethods;
using AeroportBusinessLogic.ValidationMethods;
using AeroportMVCProject.Models;
using AeroportWeb.Controllers;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;

namespace AeroportMVCProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new FlightDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<AccountManager>().As<IAccount>();

            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<FlightsController>().InstancePerRequest();
            builder.RegisterType<AccountController>().InstancePerRequest();

            builder.RegisterType<FlightCrud>().As<IFlightCrud>().InstancePerRequest();
            builder.RegisterType<FlightView>().As<IFlightView>().InstancePerRequest();
            builder.RegisterType<PassCrud>().As<IPassCrud>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
        
    }
}

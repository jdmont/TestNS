using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace test_api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;        

        protected void Application_Start()
        {
            ConfigureWindsor(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, _container));
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;
        }

        protected void Application_End()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}

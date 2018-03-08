using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Domain.Interfaces.Service;
using Odonto.Repository.Repositories;
using Odonto.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Reflection;

namespace Odonto.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork)).InSingletonScope();

            kernel.Bind(typeof(IEmpresaService)).To(typeof(EmpresaService)).InSingletonScope();

            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

        }
    }
}
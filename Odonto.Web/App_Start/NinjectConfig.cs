using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Odonto.Web
{
    public class NinjectConfig
    {
        public static void ConfigurarDependencias()
        {
            //Cria o Container 
            IKernel kernel = new StandardKernel();

            kernel.Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork)).InRequestScope();
            
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);

            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
 
    }
}
using Ninject;
using Ninject.Syntax;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Domain.Interfaces.Service;
using Odonto.Repository.Repositories;
using Odonto.Service;
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

            kernel.Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork)).InSingletonScope();

            kernel.Bind(typeof(IEmpresaService)).To(typeof(EmpresaService)).InSingletonScope();
            kernel.Bind(typeof(IFuncionarioService)).To(typeof(FuncionarioService)).InSingletonScope();

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
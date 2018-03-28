//using Ninject;
//using Ninject.Syntax;
//using Ninject.Web.Common;
//using Odonto.Domain.Interfaces.Repository;
//using Odonto.Repository.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;

namespace Odonto.Mvc
{
    public class NinjectConfig
    {
        //public static void ConfigurarDependencias()
        //{
        //    //Cria o Container 
        //    IKernel kernel = new StandardKernel();

        //    kernel.Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork)).InRequestScope();
        //    kernel.Unbind<ModelValidatorProvider>();
        //    //Registra o container no ASP.NET
        //    DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        //}
    }

    //public class NinjectDependencyResolver : IDependencyResolver
    //{
        //private readonly IResolutionRoot _resolutionRoot;

        //public NinjectDependencyResolver(IResolutionRoot kernel)
        //{
        //    _resolutionRoot = kernel;
        //}

        //public object GetService(Type serviceType)
        //{
        //    return _resolutionRoot.TryGet(serviceType);
        //}

        //public IEnumerable<object> GetServices(Type serviceType)
        //{
        //    return _resolutionRoot.GetAll(serviceType);
        //}
 
    //}
}
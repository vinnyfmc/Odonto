using Odonto.Domain.Entities;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using Odonto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Odonto.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //NinjectConfig.ConfigurarDependencias();
            AutoMapperConfig.RegisterMappings();
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[".ASPXFORMSAUTH"];
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                GenericIdentity identity = new GenericIdentity(ticket.Name);
                UsuarioPrincipal usuarioPrincipal = new UsuarioPrincipal(identity);

                UnitOfWork unit = new UnitOfWork();
                usuarioPrincipal.Funcionario = unit.FuncionarioRepository.GetById(Convert.ToInt64(ticket.UserData));
                
                Context.User = usuarioPrincipal;

            }
        }

    }

}

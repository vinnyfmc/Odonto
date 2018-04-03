using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using Odonto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Odonto.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        private readonly IMapper mapper;
        private Funcionario usuarioLogado = new Funcionario();

        public HomeController()
        {
            mapper = AutoMapperConfig.Mapper;

            UsuarioPrincipal uPrincipal = System.Web.HttpContext.Current.User as UsuarioPrincipal;
            if (uPrincipal != null)
                usuarioLogado = uPrincipal.Funcionario;

            if (usuarioLogado == null)
                throw new Exception("Usuário não encontrado!");
        }

        public ActionResult Index()
        {
            if (usuarioLogado.PrimeiroAcesso)
                return RedirectToAction("frmAlterarSenha", "Funcionario");
            else
                return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}
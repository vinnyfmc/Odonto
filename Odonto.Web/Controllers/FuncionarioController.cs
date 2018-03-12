using Odonto.Domain.Entities;
using Odonto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        EmpresaService empresaService = null;
        public FuncionarioController(EmpresaService _empresaService)
        {
            this.empresaService = _empresaService;
        }

        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Empresa> empresas = empresaService.GetAll();
                return Json(new
                {
                    sucesso = true,
                    retorno = empresas
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    sucesso = false,
                    retorno = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
           
        }
    }
}
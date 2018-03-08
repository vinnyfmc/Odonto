using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Web.Controllers
{
    public class HomeController : Controller
    {
        IEmpresaService empresaService = null;
        public HomeController(IEmpresaService _empresaService)
        {
            this.empresaService = _empresaService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmpresas()
        {
            try
            {
                List<Empresa> empresas = new List<Empresa>();
                empresas = empresaService.GetAll().ToList();
                return Json(empresas, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
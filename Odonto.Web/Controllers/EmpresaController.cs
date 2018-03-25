using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Web.Controllers
{
    public class EmpresaController : Controller
    {
        IUnitOfWork ctx;

        public EmpresaController(IUnitOfWork ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Empresa> empresas = ctx.EmpresaRepository.GetAll();

                return Json(new
                {
                    data = empresas,
                    sucesso = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    sucesso = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }

    }
}
using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        IUnitOfWork ctx;

        public FuncionarioController(IUnitOfWork ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Funcionario> funcionarios = ctx.FuncionarioRepository.GetAll();
                
                return Json(new {
                    data = funcionarios,
                    sucesso = true
                },JsonRequestBehavior.AllowGet);
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


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(long id)
        {
            Funcionario funcionario = new Funcionario();
            
            try
            {
                funcionario.Id = id;
            }
            catch (Exception ex)
            {
                ;
            }

            return View("Details", funcionario);

        }
    }
}
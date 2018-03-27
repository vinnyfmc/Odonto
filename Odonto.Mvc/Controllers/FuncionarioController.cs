using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Mvc.Controllers
{
    public class FuncionarioController : Controller
    {
        IUnitOfWork ctx;
        private readonly IMapper mapper;

        public FuncionarioController(IUnitOfWork ctx)
        {
            this.ctx = ctx;
            mapper = AutoMapperConfig.Mapper;
        }

        // GET: Funcionario
        public ActionResult Index(FuncionarioViewModel model)
        {
            return View();
        }

        public ActionResult Lista()
        {
            return View("Lista", new FuncionarioViewModel { Id = 0 });
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<FuncionarioViewModel> funcionariosViewModel;
            try
            {
                IEnumerable<Funcionario> funcionarios = ctx.FuncionarioRepository.GetAll();

                funcionariosViewModel = mapper.Map<IEnumerable<FuncionarioViewModel>>(funcionarios);

                return Json(new
                {
                    data = funcionariosViewModel,
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

        [HttpPost]
        public JsonResult Salvar(FuncionarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return new JsonResult()
                    {
                        Data = new { sucesso = true, mensagem = "Salvo com sucesso!" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                      
                }
                else
                {
                    StringBuilder errorList = new StringBuilder();
                    foreach (ModelState modelState in ViewData.ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            errorList.Append(string.Format("{0} <br/>", error.ErrorMessage));
                        }
                    }

                    return new JsonResult()
                    {
                        Data = new { sucesso = false, mensagem = errorList.ToString() },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = new { sucesso = false, mensagem = ex.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            
        }

    }
}
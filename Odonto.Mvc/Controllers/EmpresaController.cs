using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Mvc.Controllers
{
    public class EmpresaController : Controller
    {
        IUnitOfWork ctx;
        private readonly IMapper mapper;

        public EmpresaController(IUnitOfWork ctx)
        {
            this.ctx = ctx;
            mapper = AutoMapperConfig.Mapper;
        }

        // GET: Empresa
        public ActionResult Index(EmpresaViewModel model)
        {
            return View();
        }

        public ActionResult Lista()
        {
            return View("Lista", new EmpresaViewModel { Id = 0 });
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<EmpresaViewModel> empresasViewModel;
            try
            {
                IEnumerable<Empresa> empresas = ctx.EmpresaRepository.GetAll();

                empresasViewModel = mapper.Map<IEnumerable<EmpresaViewModel>>(empresas);

                return Json(new
                {
                    data = empresasViewModel,
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

    }
}
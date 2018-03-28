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

namespace Odonto.Mvc.Controllers
{
    public class PacienteController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        private readonly IMapper mapper;

        public PacienteController()
        {
            mapper = AutoMapperConfig.Mapper;
        }

        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            return View("Lista", new PacienteViewModel { Id = 0 });
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<PacienteViewModel> pacientesViewModel;
            try
            {
                IEnumerable<Paciente> pacientes = unit.PacienteRepository.GetAll();

                pacientesViewModel = mapper.Map<IEnumerable<PacienteViewModel>>(pacientes);

                return Json(new
                {
                    data = pacientes,
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
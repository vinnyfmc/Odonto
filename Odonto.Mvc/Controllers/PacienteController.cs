using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using Odonto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Mvc.Controllers
{
    public class PacienteController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        private readonly IMapper mapper;
        private Funcionario usuarioLogado = new Funcionario();

        public PacienteController()
        {
            mapper = AutoMapperConfig.Mapper;

            UsuarioPrincipal uPrincipal = System.Web.HttpContext.Current.User as UsuarioPrincipal;
            if (uPrincipal != null)
                usuarioLogado = uPrincipal.Funcionario;

            if (usuarioLogado == null)
                throw new Exception("Usuário não encontrado!");
        }

        // GET: Paciente
        public ActionResult Index(PacienteViewModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    Paciente paciente = unit.PacienteRepository.GetById((long)model.Id);
                    model = mapper.Map<PacienteViewModel>(paciente);
                }
                else
                {
                    model.IdEmpresa = usuarioLogado.IdEmpresa;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);
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

        [HttpPost]
        public JsonResult Salvar(PacienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Paciente paciente = mapper.Map<Paciente>(model);

                    if (paciente.Id > 0)
                    {
                        Paciente pacienteOriginal = unit.PacienteRepository.GetById(paciente.Id);

                        pacienteOriginal.Nome = paciente.Nome;
                        pacienteOriginal.CPF = paciente.CPF;
                        pacienteOriginal.RG = paciente.RG;
                        pacienteOriginal.DataNascimento = paciente.DataNascimento;
                        pacienteOriginal.CEP = paciente.CEP;
                        pacienteOriginal.UF = paciente.UF;
                        pacienteOriginal.Cidade = paciente.Cidade;
                        pacienteOriginal.Bairro = paciente.Bairro;
                        pacienteOriginal.Numero = paciente.Numero;
                        pacienteOriginal.Complemento = paciente.Complemento;
                        pacienteOriginal.Telefone = paciente.Telefone;
                        pacienteOriginal.Celular = paciente.Celular;
                        pacienteOriginal.Profissao = paciente.Profissao;
                        pacienteOriginal.Email = paciente.Email;
                        pacienteOriginal.Observacao = paciente.Observacao;
                        pacienteOriginal.Status = paciente.Status;
                        pacienteOriginal.IdEmpresa = paciente.IdEmpresa;
                        unit.PacienteRepository.Update(pacienteOriginal);
                    }
                    else
                    {
                        paciente.DataCadastro = DateTime.Now;
                        unit.PacienteRepository.Add(paciente);
                    }

                    unit.Commit();

                    return new JsonResult()
                    {
                        Data = new { sucesso = true, result = paciente, mensagem = "Salvo com sucesso!" },
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
                unit.Dispose();
                return new JsonResult()
                {
                    Data = new { sucesso = false, mensagem = ex.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

        }


    }
}
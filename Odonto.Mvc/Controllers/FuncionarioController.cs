using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using Odonto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Odonto.Mvc.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        private readonly IMapper mapper;

        private Funcionario usuarioLogado = new Funcionario();

        public FuncionarioController()
        {
            mapper = AutoMapperConfig.Mapper;

            UsuarioPrincipal uPrincipal = System.Web.HttpContext.Current.User as UsuarioPrincipal;
            if (uPrincipal != null)
                usuarioLogado = uPrincipal.Funcionario;

            if (usuarioLogado == null)
                throw new Exception("Usuário não encontrado!");
        }

        // GET: Funcionario
        public ActionResult Index(FuncionarioViewModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    Funcionario funcionario = unit.FuncionarioRepository.GetById((long)model.Id);
                    model = mapper.Map<FuncionarioViewModel>(funcionario);
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

        public ActionResult MeuCadastro()
        {
            FuncionarioViewModel funcionarioViewModel = mapper.Map<FuncionarioViewModel>(usuarioLogado);

            return RedirectToAction("Index", funcionarioViewModel);
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
                IEnumerable<Funcionario> funcionarios = unit.FuncionarioRepository.GetAll();

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
                    Funcionario funcionario = mapper.Map<Funcionario>(model);

                    if (funcionario.Id > 0)
                    {
                        Funcionario funcionarioOriginal = unit.FuncionarioRepository.GetById(funcionario.Id);
                        funcionarioOriginal.Nome = funcionario.Nome;
                        funcionarioOriginal.ResponsavelTecnico = funcionario.ResponsavelTecnico;
                        funcionarioOriginal.Status = funcionario.Status;
                        funcionarioOriginal.CPF = funcionario.CPF;
                        funcionarioOriginal.CRO = funcionario.CRO;
                        funcionarioOriginal.Email = funcionario.Email;
                        unit.FuncionarioRepository.Update(funcionarioOriginal);
                    }
                    else
                    {
                        using (var sha256 = new SHA256Managed())
                        {
                            var senhaNova = funcionario.Email;
                            senhaNova = senhaNova.Remove(senhaNova.IndexOf("@"));
                            var varhashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaNova));
                            var hash = BitConverter.ToString(varhashedBytes).Replace("-", "").ToLower();
                            funcionario.Senha = hash;
                        }
                        funcionario.PrimeiroAcesso = true;
                        unit.FuncionarioRepository.Add(funcionario);
                    }

                    unit.Commit();

                    return new JsonResult()
                    {
                        Data = new { sucesso = true, result = funcionario, mensagem = "Salvo com sucesso!" },
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

        public ActionResult frmAlterarSenha()
        {
            return View("AlterarSenha", new FuncionarioViewModel());
        }

        public JsonResult AlterarSenha(FuncionarioViewModel model)
        {
            try
            {
                if((!string.IsNullOrEmpty(model.Senha)) && (model.Senha.Equals(model.SenhaConfirm)))
                {

                    Funcionario funcionario = unit.FuncionarioRepository.GetById(usuarioLogado.Id);
                    using (var sha256 = new SHA256Managed())
                    {
                        var senhaNova = model.Senha;
                        var varhashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaNova));
                        var hash = BitConverter.ToString(varhashedBytes).Replace("-", "").ToLower();
                        funcionario.Senha = hash;
                    }

                    funcionario.PrimeiroAcesso = false;
                    unit.FuncionarioRepository.Update(funcionario);
                    unit.Commit();

                    return new JsonResult()
                    {
                        Data = new { sucesso = true, mensagem = "Senha alterada com sucesso!" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    return new JsonResult()
                    {
                        Data = new { sucesso = false, mensagem = "Senha não confere com a confirmação ou está vazia!" },
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
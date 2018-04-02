using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using Odonto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Odonto.Mvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        private readonly IMapper mapper;

        public LoginController()
        {
            mapper = AutoMapperConfig.Mapper;
        }

        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            //using (var sha256 = new SHA256Managed())
            //{
            //    var senhaNova = "andrezza_albanese@hotmail.com";
            //    senhaNova = senhaNova.Remove(senhaNova.IndexOf("@"));
            //    var varhashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaNova));
            //    var hash = BitConverter.ToString(varhashedBytes).Replace("-", "").ToLower();
            //}

            ViewBag.ReturnUrl = String.IsNullOrEmpty(returnUrl) ? Url.Action("Index", "Home") : returnUrl;
            return View();
        }

        [HttpPost]
        public JsonResult Autenticar(FuncionarioViewModel model)
        {
            try
            {
                Funcionario funcionario = unit.FuncionarioRepository.FindBy(x => x.Email == model.Email).FirstOrDefault();
                if (funcionario == null)
                    throw new Exception("Este e-mail não possui acesso ao sistema!");

                if (AutenticarFuncionario(model.Email, model.Senha, funcionario))
                {
                    FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel();

                    funcionarioViewModel.Id = funcionario.Id;
                    funcionarioViewModel.Email = funcionario.Email;

                    CriarCookie(funcionarioViewModel);
                }
                else
                {
                    throw new Exception("Usuário ou senha inválidos!");
                }

                return Json(new { Ok = true, Mensagem = "" });
            }
            catch (Exception ex)
            {
                return Json(new { Ok = false, Mensagem = ex.Message });
            }
        }

        public ActionResult Logout()
        {
            RemoverCookie();
            return RedirectToAction("Index", "Login");
        }


        public void RemoverCookie()
        {
            System.Web.HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void CriarCookie(FuncionarioViewModel funcionarioViewModel)
        {
            if (funcionarioViewModel == null)
                throw new ArgumentNullException("Usuário não pode ser nulo!");

            string usuarioData = funcionarioViewModel.Id.ToString();

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                funcionarioViewModel.Email,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1),
                false,
                usuarioData,
                FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);
            System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            if (ticket.IsPersistent)
            {
                authCookie.Expires = ticket.Expiration;
            }

            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

            Funcionario funcionario = mapper.Map<Funcionario>(funcionarioViewModel);

            GenericIdentity identity = new GenericIdentity(ticket.Name);
            UsuarioPrincipal principal = new UsuarioPrincipal(identity);
            principal.Funcionario = funcionario;
            System.Web.HttpContext.Current.User = principal;
        }

        private bool AutenticarFuncionario(string email, string senha, Funcionario funcionario)
        {
            using (var sha256 = new SHA256Managed())
            {
                var varhashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                var hash = BitConverter.ToString(varhashedBytes).Replace("-", "").ToLower();
                if (funcionario.Senha != hash)
                {
                    return false;
                }
            }
            
            return true;
        }

    }
}
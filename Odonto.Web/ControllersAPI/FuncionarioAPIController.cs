using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Odonto.Web.ControllersAPI
{
    public class FuncionarioAPIController : ApiController
    {
        IEmpresaService empresaService = null;
        public FuncionarioAPIController(IEmpresaService _empresaService)
        {
            this.empresaService = _empresaService;
        }

        public IEnumerable<Empresa> GetAll()
        {
            try
            {
                IEnumerable<Empresa> empresas = empresaService.GetAll();
                return empresas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

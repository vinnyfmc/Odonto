using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace Odonto.Service
{
    public class EmpresaService : IEmpresaService
    {
        IUnitOfWork ctx = null;
        public EmpresaService(IUnitOfWork ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Empresa> GetAll()
        {
            return ctx.EmpresaRepository.GetAll();
        }
    }
}

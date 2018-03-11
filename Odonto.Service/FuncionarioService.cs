using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace Odonto.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        IUnitOfWork ctx = null;

        public FuncionarioService(IUnitOfWork _ctx)
        {
            this.ctx = _ctx;
        }

        public IEnumerable<Funcionario> GetAll()
        {
            return ctx.FuncionarioRepository.GetAll();
        }
    }
}

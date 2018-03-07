using Odonto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Odonto.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<Empresa> EmpresaRepository { get; }
        IRepositoryBase<Funcionario> FuncionarioRepository { get; }

        int Commit();
    }
}


using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Repository.Context;
using System;

namespace Odonto.Repository.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private OdontoContext context = new OdontoContext();
        private RepositoryBase<Empresa> empresaRepository;
        private RepositoryBase<Funcionario> funcionarioRepository;
        
        public IRepositoryBase<Empresa> EmpresaRepository
        {
            get
            {
                if (empresaRepository == null)
                {
                    empresaRepository = new RepositoryBase<Empresa>(context);
                }
                return empresaRepository;
            }
        }

        public IRepositoryBase<Funcionario> FuncionarioRepository
        {
            get
            {
                if (funcionarioRepository == null)
                {
                    funcionarioRepository = new RepositoryBase<Funcionario>(context);
                }
                return funcionarioRepository;
            }
        }
        
        public int Commit()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

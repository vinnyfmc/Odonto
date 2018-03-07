
using Odonto.Domain.Entities;
using Odonto.Domain.Interfaces.Repository;
using Odonto.Repository.Context;

namespace Odonto.Repository.Repositories
{
    public class UnitOfWork : OdontoContext, IUnitOfWork
    {
        private readonly RepositoryBase<Empresa> empresaRepository;
        private readonly RepositoryBase<Funcionario> funcionarioRepository;
        
        public UnitOfWork()
        {
            empresaRepository = new RepositoryBase<Empresa>(Empresa);
            funcionarioRepository = new RepositoryBase<Funcionario>(Funcionario);
        }

        public IRepositoryBase<Empresa> EmpresaRepository
        {
            get { return empresaRepository; }
        }

        public IRepositoryBase<Funcionario> FuncionarioRepository
        {
            get { return funcionarioRepository; }
        }
        
        public int Commit()
        {
            return this.SaveChanges();
        }
        
    }
}

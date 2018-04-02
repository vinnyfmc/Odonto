using Odonto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Odonto.Repository.EntityConfig
{
    public class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfig()
        {
            HasKey(p => p.Id);
            Property(p => p.CPF).HasMaxLength(11);
            Property(p => p.Nome).IsRequired().HasMaxLength(255);
            Property(p => p.Email).IsRequired().HasMaxLength(100);
            Property(p => p.Senha).IsRequired().HasMaxLength(100);
            Property(p => p.CRO).HasMaxLength(100);
            Property(p => p.ResponsavelTecnico).IsRequired();
            Property(p => p.Status).IsRequired();
            Property(p => p.PrimeiroAcesso).IsRequired();

            HasRequired(p => p.Empresa).WithMany().HasForeignKey(p => p.IdEmpresa);
        }
    }
}

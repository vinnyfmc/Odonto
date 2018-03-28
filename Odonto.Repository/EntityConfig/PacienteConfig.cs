using Odonto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Odonto.Repository.EntityConfig
{
    public class PacienteConfig : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfig()
        {
            HasKey(p => p.Id);
            Property(p => p.Nome).IsRequired().HasMaxLength(255);
            Property(p => p.RG).HasMaxLength(20);
            Property(p => p.DataNascimento).IsRequired();
            Property(p => p.CPF).HasMaxLength(11);
            Property(p => p.CEP).HasMaxLength(10);
            Property(p => p.UF).HasMaxLength(10);
            Property(p => p.Cidade).HasMaxLength(100);
            Property(p => p.Bairro).HasMaxLength(100);
            Property(p => p.Numero).HasMaxLength(30);
            Property(p => p.Complemento).HasMaxLength(100);
            Property(p => p.Telefone).HasMaxLength(20);
            Property(p => p.Celular).HasMaxLength(20);
            Property(p => p.Profissao);
            Property(p => p.Email).HasMaxLength(100);
            Property(p => p.Observacao).HasMaxLength(8000);
            Property(p => p.Status).IsRequired();
            Property(p => p.DataCadastro).IsRequired();

            HasRequired(p => p.Empresa).WithMany().HasForeignKey(p => p.IdEmpresa);
        }
    }
}

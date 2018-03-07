using Odonto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Odonto.Repository.EntityConfig
{
    public class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            HasKey(c => c.Id);
            Property(c => c.RazaoSocial).IsRequired().HasMaxLength(255);
            Property(c => c.CNPJ).HasMaxLength(14);
            Property(c => c.Status).IsRequired();
        }
    }
}

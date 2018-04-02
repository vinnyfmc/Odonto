namespace Odonto.Domain.Entities
{
    public class Funcionario
    {
        public long Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CRO { get; set; }
        public bool ResponsavelTecnico { get; set; }
        public int Status { get; set; }
        public bool PrimeiroAcesso { get; set; }

        public long IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}

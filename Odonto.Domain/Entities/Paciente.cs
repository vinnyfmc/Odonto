using System;
using System.Collections.Generic;

namespace Odonto.Domain.Entities
{
    public class Paciente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Profissao { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public int Status { get; set; }
        public DateTime DataCadastro { get; set; }

        public long IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}

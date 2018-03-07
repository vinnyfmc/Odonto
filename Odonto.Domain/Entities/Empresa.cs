using System;
using System.Collections.Generic;

namespace Odonto.Domain.Entities
{
    public class Empresa
    {
        public Empresa()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public long Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public int Status { get; set; }

        public virtual IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}

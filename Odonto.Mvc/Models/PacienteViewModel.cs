using System;
using System.ComponentModel.DataAnnotations;

namespace Odonto.Mvc.Models
{
    public class PacienteViewModel
    {
        [Required(ErrorMessage = "Identificador do paciente é obrigatório.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome do paciente é obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(11, ErrorMessage = "CPF - Máximo de 11 caratéres!")]
        [MinLength(11, ErrorMessage = "CPF - Mínimo de 11 caratéres!")]
        public string CPF { get; set; }

        public string RG { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data de nascimento em formato inválido.")]
        [Required(ErrorMessage = "Data de nascimento do paciente é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        public string CEP { get; set; }

        [MaxLength(2, ErrorMessage = "UF - Máximo de 2 caratéres!")]
        [MinLength(2, ErrorMessage = "UF - Mínimo de 2 caratéres!")]
        public string UF { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Profissao { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo de 100 caratéres!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public string Observacao { get; set; }

        [Required(ErrorMessage = "Status é obrigatório.")]
        public int Status { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data de Cadastro em formato inválido.")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Empresa do paciente é obrigatório.")]
        public long IdEmpresa { get; set; }
    }
}
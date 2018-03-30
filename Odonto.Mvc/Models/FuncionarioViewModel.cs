using System.ComponentModel.DataAnnotations;

namespace Odonto.Mvc.Models
{
    public class FuncionarioViewModel 
    {
        [Required(ErrorMessage = "Identificador do funcionário é obrigatório.")]
        public long? Id { get; set; }

        [MaxLength(11, ErrorMessage = "CPF - Máximo de 11 caratéres!")]
        [MinLength(11, ErrorMessage = "CPF - Mínimo de 11 caratéres!")]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(255, ErrorMessage = "Nome - Máximo de 255 caratéres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [MaxLength(255, ErrorMessage = "E-mail - Máximo de 100 caratéres!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public string Senha { get; set; }

        [MaxLength(100, ErrorMessage = "CRO - Máximo de 100 caratéres!")]
        public string CRO { get; set; }

        public bool ResponsavelTecnico { get; set; }

        [Required(ErrorMessage = "Status é obrigatório.")]
        public int? Status { get; set; }

        [Required(ErrorMessage = "Empresa do funcionário é obrigatório.")]
        public long? IdEmpresa { get; set; }
        
    }

    
}
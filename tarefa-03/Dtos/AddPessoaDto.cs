using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_03.Dtos
{
    public class AddPessoaDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório")]
        [MaxLength(160)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Cpf é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Informe uma cidade")]
        public Guid IdCidade { get; set; }
        [Required(ErrorMessage = "Informe um estado")]
        public Guid IdEstado { get; set; }
    }
}
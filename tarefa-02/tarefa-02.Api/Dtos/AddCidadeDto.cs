using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_02.Dtos
{
    public class AddCidadeDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Código ibge inválido")]
        public int CodigoIbge { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome da cidade não informado")]
        [MaxLength(100)]
        public string NomeCidade { get; set; }
        [Required]
        public Guid IdEstado { get; set; }
    }
}
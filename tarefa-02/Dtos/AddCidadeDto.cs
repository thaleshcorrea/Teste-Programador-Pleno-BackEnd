using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_02.Dtos
{
    public class AddCidadeDto
    {
        [Required]
        public int CodigoIbge { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string NomeCidade { get; set; }
        [Required]
        public Guid IdEstado { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_04.Models
{
    public class Log
    {
        private Log() { }
        public Log(string funcao, string descricaoAcao)
        {
            IdLog = Guid.NewGuid();
            Funcao = funcao;
            DescricaoAcao = descricaoAcao;
            Data = DateTime.UtcNow;
        }

        [Key]
        public Guid IdLog { get; private set; }
        [Required]
        public string Funcao { get; private set; }
        [Required]
        public string DescricaoAcao { get; private set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; private set; }
    }
}

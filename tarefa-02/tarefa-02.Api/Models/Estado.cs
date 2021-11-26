using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_02.Models
{
    public class Estado
    {
        private Estado() { }
        public Estado(int codigoIbge, string nomeEstado, string ufEstado)
        {
            IdEstado = Guid.NewGuid();
            CodigoIbge = codigoIbge;
            NomeEstado = nomeEstado;
            UfEstado = ufEstado;
        }

        [Key]
        public Guid IdEstado { get; private set; }
        public int CodigoIbge { get; private set; }
        [MaxLength(50)]
        public string NomeEstado { get; private set; }
        [MaxLength(2)]
        public string UfEstado { get; private set; }
    }
}
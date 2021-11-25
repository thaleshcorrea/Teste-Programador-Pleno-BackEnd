using System;

namespace tarefa_02.Models
{
    public class Estado
    {
        private Estado() { }
        public Estado(int codigoIbge, string nomeEstado)
        {
            IdEstado = Guid.NewGuid();
            CodigoIbge = codigoIbge;
            NomeEstado = nomeEstado;
        }

        public Guid IdEstado { get; private set; }
        public int CodigoIbge { get; private set; }
        public string NomeEstado { get; private set; }
    }
}
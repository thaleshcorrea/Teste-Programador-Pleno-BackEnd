using System;

namespace tarefa_02.Models
{
    public class Cidade
    {
        private Cidade() { }
        public Cidade(int codigoIbge, string nomeCidade, Guid idEstado)
        {
            CodigoIbge = codigoIbge;
            NomeCidade = nomeCidade;
            IdEstado = idEstado;
        }

        public Guid IdCidade { get; private set; }
        public int CodigoIbge { get; private set; }
        public string NomeCidade { get; private set; }
        public Guid IdEstado { get; private set; }

        public Estado Estado { get; private set; }

        public void UpdateInfo(int codigoIbge, string nomeCidade, Guid idEstado)
        {
            CodigoIbge = codigoIbge;
            NomeCidade = nomeCidade;
            IdEstado = idEstado;
        }
    }
}
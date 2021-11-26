using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_02.Models
{
    public class Cidade
    {
        private Cidade() { }
        public Cidade(int codigoIbge, string nomeCidade, Guid idEstado)
        {
            IdCidade = Guid.NewGuid();
            CodigoIbge = codigoIbge;
            NomeCidade = nomeCidade;
            IdEstado = idEstado;
        }

        public Cidade(Guid idCidade, int codigoIbge, string nomeCidade, Guid idEstado)
        {
            IdCidade = idCidade;
            CodigoIbge = codigoIbge;
            NomeCidade = nomeCidade;
            IdEstado = idEstado;
        }

        [Key]
        public Guid IdCidade { get; private set; }
        [Required]
        public int CodigoIbge { get; private set; }
        [Required]
        [MaxLength(100)]
        public string NomeCidade { get; private set; }
        [Required]
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
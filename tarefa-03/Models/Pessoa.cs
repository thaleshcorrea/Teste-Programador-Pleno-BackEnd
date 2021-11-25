using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_03.Models
{
    public class Pessoa
    {
        private Pessoa() { }

        public Pessoa(string nome, string cpf, Guid idCidade, Guid idEstado)
        {
            Nome = nome;
            Cpf = cpf;
            IdCidade = idCidade;
            IdEstado = idEstado;
        }

        [Key]
        public Guid IdPessoa { get; private set; }
        [MaxLength(160)]
        public string Nome { get; private set; }
        [MaxLength(11)]
        [Required]
        public string Cpf { get; private set; }
        public Guid IdCidade { get; private set; }
        public Guid IdEstado { get; private set; }

        public void UpdateInfo(string nome, string cpf, Guid idCidade, Guid idEstado){
            Nome = nome;
            Cpf = cpf;
            IdCidade = idCidade;
            IdEstado = idEstado;
        }
    }
}
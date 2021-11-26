using System;

namespace tarefa_02.Dtos
{
    public class GetCidadeDto
    {
        public Guid IdCidade { get; set; }
        public int CodigoIbge { get; set; }
        public string NomeCidade { get; set; }
    }
}
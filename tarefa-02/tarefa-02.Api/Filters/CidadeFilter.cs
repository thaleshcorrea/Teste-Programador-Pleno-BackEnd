using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_02.Filters
{
    public class CidadeFilter : PaginationFilter
    {
        public CidadeFilter() { }
        public CidadeFilter(Guid idEstado, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            IdEstado = idEstado;
        }

        [Required]
        public Guid IdEstado { get; private set; }
    }
}
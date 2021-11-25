using System;
using System.ComponentModel.DataAnnotations;

namespace tarefa_02.Filters
{
    public class CidadeFilter : PaginationFilter
    {
        [Required]
        public Guid IdEstado { get; private set; }
    }
}
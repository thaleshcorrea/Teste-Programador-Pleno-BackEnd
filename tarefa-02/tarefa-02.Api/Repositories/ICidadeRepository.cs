using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tarefa_02.Dtos;
using tarefa_02.Filters;
using tarefa_02.Models;

namespace tarefa_02.Repositories
{
    public interface ICidadeRepository
    {
        Task<List<GetCidadeDto>> GetByEstado(Guid idEstado);
        Task<List<GetCidadeDto>> Get(PaginationFilter filter);
        Task<int> GetTotalRecords(Guid idEstado);
        Task<bool> Exists(Guid idCidade);
        Task<Cidade> GetById(Guid idCidade);
        void Add(Cidade cidade);
        void Update(Cidade cidade);
        Task Save();
    }
}
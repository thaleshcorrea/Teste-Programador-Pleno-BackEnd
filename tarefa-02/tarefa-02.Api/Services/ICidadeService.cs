using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tarefa_02.Dtos;
using tarefa_02.Filters;
using tarefa_02.HttpResponses;

namespace tarefa_02.Services
{
    public interface ICidadeService
    {
        Task<Response<Guid>> Add(AddCidadeDto addCidadeDto);
        Task<Response<bool>> Update(UpdateCidadeDto updateCidadeDto);
        Task<Response<bool>> Exists(Guid idCidade);
        Task<PagedResponse<List<GetCidadeDto>>> Get(CidadeFilter filter);
        Task<Response<List<GetCidadeDto>>> GetByEstado(Guid idEstado);
    }
}

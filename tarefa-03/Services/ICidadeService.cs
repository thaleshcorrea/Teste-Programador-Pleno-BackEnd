using System;
using System.Threading.Tasks;

namespace tarefa_03.Services
{
    public interface ICidadeService
    {
        Task<bool> Exists(Guid idCidade);
    }
}
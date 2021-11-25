using System.Threading.Tasks;
using tarefa_03.Models;

namespace tarefa_03.Repositories
{
    public interface IPessoaRepository
    {
        void Add(Pessoa pessoa);
        Task Save();
    }
}
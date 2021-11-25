using System.Threading.Tasks;
using tarefa_04.Models;

namespace tarefa_04.Repositories
{
    public interface ILogRepository
    {
        void Add(Log log);
        Task Save();
    }
}

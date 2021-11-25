using System.Threading.Tasks;
using tarefa_04.Data;
using tarefa_04.Models;

namespace tarefa_04.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly DataContext _context;
        public LogRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Log log)
        {
            _context.Log.Add(log);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

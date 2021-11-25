using System.Threading.Tasks;
using tarefa_03.Data;
using tarefa_03.Models;

namespace tarefa_03.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DataContext _context;
        public PessoaRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
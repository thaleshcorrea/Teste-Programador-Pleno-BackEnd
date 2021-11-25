using tarefa_03.Models;
using Microsoft.EntityFrameworkCore;

namespace tarefa_03.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
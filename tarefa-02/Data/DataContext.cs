using Microsoft.EntityFrameworkCore;
using tarefa_02.Models;

namespace tarefa_02.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
    }
}
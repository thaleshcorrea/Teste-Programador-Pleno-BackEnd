using Microsoft.EntityFrameworkCore;
using tarefa_04.Models;

namespace tarefa_04.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Log> Log { get; set; }
    }
}

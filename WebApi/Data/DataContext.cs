using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options) {}

        public DbSet<Aluno> Aluno { get; set; }        
                
    }
}
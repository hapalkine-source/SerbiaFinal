using Microsoft.EntityFrameworkCore;
namespace SerbiaFinal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){ }
        public DbSet<Goals> Goals { get; set; }  
    }
}

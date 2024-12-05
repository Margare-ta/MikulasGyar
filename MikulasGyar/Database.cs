using Microsoft.EntityFrameworkCore;

namespace MikulasGyar;

public class DatabaseContext : DbContext
{
    public DbSet<Toy> Toys { get; set; }
    public DbSet<Kid> Kids { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=mikulasgyar;user=root;");
    }
}

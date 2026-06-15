using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Funcionario> funcionarios => Set<Funcionario>();
    public DbSet<Tickets> tickets => Set<Tickets>();

    protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            Environment.GetEnvironmentVariable(
                "POSTGRES_CONNECTION_STRING");

        optionsBuilder.UseNpgsql(connectionString);
    }
}
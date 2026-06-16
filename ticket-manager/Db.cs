using Microsoft.EntityFrameworkCore;
using DotNetEnv;

public class AppDbContext : DbContext
{
    public DbSet<Funcionario> funcionarios => Set<Funcionario>();
    public DbSet<Tickets> tickets => Set<Tickets>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("POSTGRES_CONNECTION_STRING não foi configurada no arquivo .env");
        }

        optionsBuilder.UseNpgsql(connectionString);
    }
}
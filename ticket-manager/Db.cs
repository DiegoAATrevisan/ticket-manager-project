using Microsoft.EntityFrameworkCore;
using DotNetEnv;

public class AppDbContext : DbContext
{
    public DbSet<Funcionario> funcionarios => Set<Funcionario>();
    public DbSet<Ticket> tickets => Set<Ticket>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("POSTGRES_CONNECTION_STRING não foi configurada no arquivo .env");
        }

        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.ToTable("funcionarios");

            entity.HasKey(f => f.Id);

            entity.Property(f => f.Id)
                .HasColumnName("id");

            entity.Property(f => f.Nome)
                .HasColumnName("nome")
                .HasMaxLength(100);

            entity.Property(f => f.Cpf)
                .HasColumnName("cpf")
                .HasMaxLength(11);

            entity.Property(f => f.Situacao)
                .HasColumnName("situacao")
                .HasDefaultValueSql("'A'")
                .ValueGeneratedOnAdd();

            entity.Property(f => f.DataCadastro)
                .HasColumnName("data_cadastro")
                .ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("tickets");

            entity.HasKey(t => t.Id);

            entity.Property(t => t.Id)
                .HasColumnName("id");
            entity.Property(t => t.IdFuncionario)
                .HasColumnName("id_funcionario");

            entity.Property(t => t.Quantidade)
                .HasColumnName("quantidade");

            entity.Property(t => t.Situacao)
                .HasColumnName("situacao")
                .HasDefaultValueSql("'A'")
                .ValueGeneratedOnAdd();

            entity.Property(t => t.DataCadastro)
                .HasColumnName("data_cadastro")
                .ValueGeneratedOnAdd();
        });
    }
}
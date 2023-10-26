using gamelib.Domain.Consoles;
using Microsoft.EntityFrameworkCore;

namespace gamelib.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Platform> Consoles { get; set; }
    public DbSet<Game> Games { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Platform>().Property(p => p.Name).HasMaxLength(255);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(500);
    }
}

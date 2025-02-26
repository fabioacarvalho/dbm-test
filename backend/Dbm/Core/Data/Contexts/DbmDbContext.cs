using Dbm.Core.Data.EntityConfigs;
using Dbm.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dbm.Core.Data.Contexts;

public class DbmDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {   
        // Se for usar o SQL Server no Docker
        // builder.UseSqlServer("Server=sqlserver;Database=Dbm;User Id=sa;Password=YourStrong!Passw0rd;Trusted_Connection=True;");
        
        builder.UseSqlServer("Server=sqlserver;Database=Dbm;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProductEntityConfig());


        builder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();
    }
}
using GeliGiderAnaliziClassLib;
using GelirGiderAnalizi.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

public class GelirGiderAnaliziContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(CustomConfigurationManager.ConnectionString);
    }

    public DbSet<GiderIslModel> GiderIslModels { get; set; }
    public DbSet<GiderModel> GiderModels { get; set; }
    public DbSet<LoginModel> LoginModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LoginModel>().HasNoKey();
    }
}

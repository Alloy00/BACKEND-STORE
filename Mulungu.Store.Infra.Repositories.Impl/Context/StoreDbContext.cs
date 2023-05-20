using Microsoft.EntityFrameworkCore;
using Mulungu.Loja.Domain.Entities;

namespace Mulungu.Loja.Infra.Repositories.Impl.Context;

public class StoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            var connectionString = "Server=127.0.0.1; Database=dbtest; Uid=root; Pwd=root;";
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
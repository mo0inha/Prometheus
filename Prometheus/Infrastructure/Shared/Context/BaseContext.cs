using Domain.Entities;
using Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("O DbContextOptions deve ser configurado externamente.");
            }
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Unity> Unities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantConfig());
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new UnityConfig());
        }
    }
}

using CompaniesAPI.Entities;
using Microsoft.EntityFrameworkCore;

public class CompaniesDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public CompaniesDbContext(DbContextOptions<CompaniesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .Property(a => a.AddressType)
            .HasConversion<string>();
    }
}

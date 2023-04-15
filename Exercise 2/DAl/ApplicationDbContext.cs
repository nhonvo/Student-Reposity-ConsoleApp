// See https://aka.ms/new-console-template for more information
using Exercise_2.DAl.FluentAPIConfig;
using Exercise_2.DAl.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ShippingCompany> ShippingCompanies { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=TRUONGNHON; Initial Catalog=exercise2; TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true; User Id = TRUONGNHON; Password = 123");
                    // .UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new ShippingCompanyConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderDetailsConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
    }
}

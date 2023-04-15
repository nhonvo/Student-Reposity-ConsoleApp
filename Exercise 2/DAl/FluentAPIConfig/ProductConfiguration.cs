using Exercise_2.DAl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Exercise_2.DAl.FluentAPIConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2"
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3"
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4"
                }
            );
        }
    }
}
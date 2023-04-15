using Exercise_2.DAl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Exercise_2.DAl.FluentAPIConfig
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);
            builder.HasData(
                new OrderDetails
                {
                    ProductId = 1,
                    OrderId = 1
                },
                new OrderDetails
                {

                    ProductId = 2,
                    OrderId = 5
                },
                new OrderDetails
                {
                    ProductId = 3,
                    OrderId = 1
                },
                new OrderDetails
                {
                    ProductId = 4,
                    OrderId = 2
                },
                new OrderDetails
                {
                    ProductId = 4,
                    OrderId = 4
                }
            );
        }
    }
}
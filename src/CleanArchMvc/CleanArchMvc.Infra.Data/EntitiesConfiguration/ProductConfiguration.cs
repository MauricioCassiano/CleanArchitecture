using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasOne(h => h.Category).WithMany(h => h.Products).HasForeignKey(h => h.CategoryId);

        }
    }
}

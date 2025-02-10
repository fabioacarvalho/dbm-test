using Dbm.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dbm.Core.Data.EntityConfigs;

class ProductEntityConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(p => p.Name).IsUnique(); 
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("datetime");

        builder.ToTable(tb => tb.HasCheckConstraint("CK_Product_Price", "Price > 0"));
    }
}
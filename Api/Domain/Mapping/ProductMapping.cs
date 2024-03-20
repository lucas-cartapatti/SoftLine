using Microsoft.EntityFrameworkCore;

namespace Api.Domain;

public class ProductMapping : Product
{
    public ProductMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07126C5A6F");

            entity.Property(e => e.Description)
                .HasColumnName(nameof(Description))
                .HasColumnType("varchar");

            entity.Property(e => e.Code)
                .HasColumnName(nameof(Code))
                .HasColumnType("varchar");

            entity.Property(e => e.Price)
                .HasColumnName(nameof(Price))
                .HasColumnType("decimal")
                .HasPrecision(18,2);
            
            entity.Property(e => e.GrossWeight)
                .HasColumnName(nameof(GrossWeight))
                .HasColumnType("decimal")
                .HasPrecision(18,3);

            entity.Property(e => e.NetWeight)
                .HasColumnName(nameof(NetWeight))
                .HasColumnType("decimal")
                .HasPrecision(18,3);
        });
    }
}
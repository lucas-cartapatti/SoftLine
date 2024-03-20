using Microsoft.EntityFrameworkCore;

namespace Api.Domain;

public class CustomerMapping : Customer
{
    public CustomerMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>{

            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0762DE43F7");

            entity.Property(e => e.CompanyName)
                .HasColumnName(nameof(CompanyName))
                .HasColumnType("varchar");

            entity.Property(e => e.TradeName)
                .HasColumnName(nameof(TradeName))
                .HasColumnType("varchar");

            entity.Property(e => e.Document)
                .HasColumnName(nameof(Document))
                .HasColumnType("varchar");

            entity.Property(e => e.Location)
                .HasColumnName(nameof(Location))
                .HasColumnType("varchar");

            entity.Property(e => e.Active)
                .HasColumnName(nameof(TradeName))
                .HasColumnType("bit");

        });

    }
}
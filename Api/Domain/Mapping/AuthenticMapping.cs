using Microsoft.EntityFrameworkCore;

namespace Api.Domain;

public class AuthenticMapping : Authentic
{
    public AuthenticMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authentic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authenti__3214EC07EFA7D8E7");
            
            entity.Property(e => e.Username)
                .HasColumnName(nameof(Username))
                .HasColumnType("varchar");
                
            entity.Property(e => e.Password)
                .HasColumnName(nameof(Password))
                .HasColumnType("varchar");

            entity.Property(e => e.Email)
                .HasColumnName(nameof(Email))
                .HasColumnType("varchar");

            entity.Property(e => e.Active)
                .HasColumnName(nameof(Active))
                .HasColumnType("bit");

            entity.Property(e => e.DateCreation)
                .HasColumnName(nameof(DateCreation))
                .HasColumnType("datetime2");
        
        });
    }
}
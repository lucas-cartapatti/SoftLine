using Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class SoftLineDbContext : DbContext
{
    public SoftLineDbContext(DbContextOptions dbContext): base(dbContext)
    {
        
    }

    public DbSet<Authentic> Authentic { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Customer> Customer { get; set; }
}
using Microsoft.EntityFrameworkCore;

namespace GalaxusWebApi.Models;

public class GalaxusDbContext : DbContext
{
    public GalaxusDbContext(DbContextOptions<GalaxusDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
}
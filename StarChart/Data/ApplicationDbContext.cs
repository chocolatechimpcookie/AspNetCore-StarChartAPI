using Microsoft.EntityFrameworkCore;
using StarChart.Models;

namespace StarChart.Data
{
    public class ApplicationDbContext : DbContext
    {
      public DbSet<CelestialObject> CelestialObject;

      public ApplicationDbContext(DbContextOptions options) : base(options)
      {
      }
    }
}

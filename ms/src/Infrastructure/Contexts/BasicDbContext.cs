using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class BasicDbContext : DbContext
    {
        public DbSet<GeoRequest> GeoRequests { get; set; }

        public BasicDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

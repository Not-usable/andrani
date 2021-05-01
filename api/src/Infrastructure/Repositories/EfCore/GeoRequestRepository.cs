using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repository.EfCore
{
    public class GeoRequestRepository : GenericEFRepository<GeoRequest>, IGeoRequestRepository
    {
        public GeoRequestRepository(BasicDbContext sampleDbContext) : base(sampleDbContext)
        {
        }
    }
}

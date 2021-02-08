using GlueHome.Application.Deliveries.Queries.GetDeliveryById;
using GlueHome.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GlueHome.Persistence.Repositories.Deliveries
{
    public class GetDeliveryByIdRepository : IGetDeliveryByIdRepository
    {
        private readonly GlueHomeDbContext _dbContext;

        public GetDeliveryByIdRepository(GlueHomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _dbContext.Deliveries.FirstOrDefaultAsync(d => d.Id == id, token);
        }
    }
}

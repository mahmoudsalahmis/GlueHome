using GlueHome.Application.Deliveries.Commands.CreateDelivery;
using GlueHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Persistence.Repositories.Deliveries
{
    public class CreateDeliveryRepository : ICreateDeliveryRepository
    {
        private readonly GlueHomeDbContext _dbContext;

        public CreateDeliveryRepository(GlueHomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeliveryDoesNotExistAsync(Guid id, CancellationToken token)
        {
            return !await _dbContext.Deliveries.AsNoTracking().AnyAsync(d => d.Id == id, token);
        }

        public async Task CreateDeliveryAsync(Delivery entity, CancellationToken token)
        {
            await _dbContext.Deliveries.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}

using GlueHome.Application.Deliveries.Commands.UpdateDelivery;
using GlueHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Persistence.Repositories.Deliveries
{
    public class UpdateDeliveryRepository : IUpdateDeliveryRepository
    {
        private readonly GlueHomeDbContext _dbContext;

        public UpdateDeliveryRepository(GlueHomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _dbContext.Deliveries.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id, token);
        }

        public async Task UpdateDeliveryAsync(Delivery delivery, CancellationToken token = default)
        {
            _dbContext.Deliveries.Update(delivery);

           await _dbContext.SaveChangesAsync(token);
        }
    }
}

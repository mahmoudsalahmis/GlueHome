using GlueHome.Application.Deliveries.Commands.UpdateDeliveryStatus;
using GlueHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Persistence.Repositories.Deliveries
{
    public class UpdateDeliveryStatusRepository : IUpdateDeliveryStatusRepository
    {
        private readonly GlueHomeDbContext _dbContext;

        public UpdateDeliveryStatusRepository(GlueHomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveDeliveryAsync(Delivery delivery, CancellationToken token)
        {
            _dbContext.Deliveries.Update(delivery);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _dbContext.Deliveries
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id, token);
        }
    }
}

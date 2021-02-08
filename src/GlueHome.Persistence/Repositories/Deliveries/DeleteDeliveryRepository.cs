using GlueHome.Application.Deliveries.Commands.DeleteDelivery;
using GlueHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Persistence.Repositories.Deliveries
{
    public class DeleteDeliveryRepository : IDeleteDeliveryRepository
    {
        private readonly GlueHomeDbContext _dbContext;

        public DeleteDeliveryRepository(GlueHomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteDeliveryAsync(Delivery delivery, CancellationToken token = default)
        { 
            _dbContext.Deliveries.Remove(delivery);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _dbContext.Deliveries
                .AsNoTracking()
                .Select(d => new Delivery { Id = d.Id })
                .FirstOrDefaultAsync(d => d.Id == id, token);
        }
    }
}

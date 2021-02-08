using GlueHome.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Queries.GetDeliveryById
{
    public interface IGetDeliveryByIdRepository
    {
        Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default);
    }
}

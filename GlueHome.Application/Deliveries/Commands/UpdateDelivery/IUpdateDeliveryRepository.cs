using GlueHome.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Commands.UpdateDelivery
{
    public interface IUpdateDeliveryRepository
    {
        Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default);

        Task UpdateDeliveryAsync(Delivery model, CancellationToken token = default);
    }
}

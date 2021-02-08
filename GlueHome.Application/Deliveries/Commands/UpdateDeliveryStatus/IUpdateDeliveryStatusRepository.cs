using GlueHome.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Commands.UpdateDeliveryStatus
{
    public interface IUpdateDeliveryStatusRepository
    {
        Task SaveDeliveryAsync(Delivery delivery, CancellationToken token);

        Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default);
    }
}

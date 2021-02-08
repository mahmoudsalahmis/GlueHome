using System;
using System.Threading;
using System.Threading.Tasks;
using GlueHome.Domain.Entities;

namespace GlueHome.Application.Deliveries.Commands.CreateDelivery
{
    public interface ICreateDeliveryRepository
    {
        Task<bool> DeliveryDoesNotExistAsync(Guid id, CancellationToken token);

        Task CreateDeliveryAsync(Delivery model, CancellationToken token);
    }
}

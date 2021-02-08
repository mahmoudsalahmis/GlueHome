using System;
using GlueHome.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Commands.DeleteDelivery
{
    public interface IDeleteDeliveryRepository
    {
        Task DeleteDeliveryAsync(Delivery delivery, CancellationToken token = default);

        Task<Delivery> GetDeliveryByIdAsync(Guid id, CancellationToken token = default);
    }
}

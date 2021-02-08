using GlueHome.Application.Deliveries.Models;
using MediatR;

namespace GlueHome.Application.Deliveries.Commands.CreateDelivery
{
    public record CreateDeliveryCommand : DeliveryModel, IRequest<CreateDeliveryResponse>
    {
    }
}

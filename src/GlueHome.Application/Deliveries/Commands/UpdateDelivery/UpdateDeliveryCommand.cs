using GlueHome.Application.Deliveries.Models;
using MediatR;

namespace GlueHome.Application.Deliveries.Commands.UpdateDelivery
{
    public record UpdateDeliveryCommand : DeliveryModel, IRequest { }
}

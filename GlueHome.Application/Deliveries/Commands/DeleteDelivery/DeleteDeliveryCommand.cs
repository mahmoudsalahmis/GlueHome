using MediatR;
using System;

namespace GlueHome.Application.Deliveries.Commands.DeleteDelivery
{
    public record DeleteDeliveryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

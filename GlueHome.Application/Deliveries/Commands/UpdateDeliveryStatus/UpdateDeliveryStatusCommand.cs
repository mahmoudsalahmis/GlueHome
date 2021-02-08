using MediatR;
using System;
using GlueHome.Domain.Enums;

namespace GlueHome.Application.Deliveries.Commands.UpdateDeliveryStatus
{
    public record UpdateDeliveryStatusCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeliveryStatus  Status { get; set; }
    }
}

using GlueHome.Domain.ValueObjects;
using System;

namespace GlueHome.Application.Deliveries.Models
{
    public record DeliveryModel
    {
        public Guid Id { get; init; }

        public AccessWindow AccessWindow { get; init; }

        public Recipient Recipient { get; init; }

        public Order Order { get; init; }
    }
}

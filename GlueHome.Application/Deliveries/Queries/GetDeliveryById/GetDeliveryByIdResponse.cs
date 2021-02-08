using GlueHome.Domain.ValueObjects;
using System;

namespace GlueHome.Application.Deliveries.Queries.GetDeliveryById
{
    public record GetDeliveryByIdResponse
    {
        public Guid Id { get; init; }

        public string Status { get; set; }

        public AccessWindow AccessWindow { get; init; }

        public Recipient Recipient { get; init; }

        public Order Order { get; init; }
    }
}

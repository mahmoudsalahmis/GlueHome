using System;
using MediatR;

namespace GlueHome.Application.Deliveries.Queries.GetDeliveryById
{
    public record GetDeliveryByIdQuery : IRequest<GetDeliveryByIdResponse>
    {
        public Guid Id { get; set; }
    }
}

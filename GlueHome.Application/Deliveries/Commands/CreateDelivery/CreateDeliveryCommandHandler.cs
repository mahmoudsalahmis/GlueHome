using AutoMapper;
using GlueHome.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, CreateDeliveryResponse>
    {
        private readonly ICreateDeliveryRepository _repository;

        private readonly IMapper _mapper;

        public CreateDeliveryCommandHandler(ICreateDeliveryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateDeliveryResponse> Handle(CreateDeliveryCommand command, CancellationToken cancellationToken)
        {
            var delivery = _mapper.Map<Delivery>(command);

            await _repository.CreateDeliveryAsync(delivery, cancellationToken);

            return new CreateDeliveryResponse { DeliveryId = command.Id };
        }
    }
}

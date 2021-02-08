using GlueHome.Application.Exceptions;
using GlueHome.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommandHandler : IRequestHandler<UpdateDeliveryCommand>
    {
        private readonly IUpdateDeliveryRepository _repository;

        public UpdateDeliveryCommandHandler(IUpdateDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDeliveryCommand request, CancellationToken token)
        {
            var delivery = await _repository.GetDeliveryByIdAsync(request.Id, token);

            if (delivery == null)
            {
                throw new NotFoundException(nameof(Delivery), request.Id);
            }

            delivery.AccessWindow = request.AccessWindow;
            delivery.Order = request.Order;
            delivery.Recipient = request.Recipient;

            await _repository.UpdateDeliveryAsync(delivery, token);

            return Unit.Value;
        }
    }
}

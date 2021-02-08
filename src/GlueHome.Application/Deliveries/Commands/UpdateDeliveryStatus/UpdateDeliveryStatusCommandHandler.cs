using GlueHome.Application.Exceptions;
using GlueHome.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Commands.UpdateDeliveryStatus
{
    public class UpdateDeliveryStatusCommandHandler : IRequestHandler<UpdateDeliveryStatusCommand>
    {
        private readonly IUpdateDeliveryStatusRepository _repository;

        public UpdateDeliveryStatusCommandHandler(IUpdateDeliveryStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDeliveryStatusCommand request, CancellationToken token)
        {
            var delivery = await _repository.GetDeliveryByIdAsync(request.Id, token);

            if (delivery == null)
            {
                throw new NotFoundException(nameof(Delivery), request.Id);
            }

            try
            {
                delivery.UpdateDeliveryStatus(request.Status);
            }
            catch (ArgumentException ex) //Argument exception raised mean an invalid newStatus received.
            {
                throw new ValidationException(ex);
            }

            await _repository.SaveDeliveryAsync(delivery, token);

            return Unit.Value;
        }
    }
}
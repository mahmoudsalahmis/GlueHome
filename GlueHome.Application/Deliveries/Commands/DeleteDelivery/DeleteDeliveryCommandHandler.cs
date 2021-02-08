using GlueHome.Application.Exceptions;
using GlueHome.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommandHandler : IRequestHandler<DeleteDeliveryCommand>
    {
        private readonly IDeleteDeliveryRepository _repository;

        public DeleteDeliveryCommandHandler(IDeleteDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(DeleteDeliveryCommand request, CancellationToken token)
        {
            var delivery = await _repository.GetDeliveryByIdAsync(request.Id, token);

            if (delivery == null)
            {
                throw new NotFoundException(nameof(Delivery), request.Id);
            }

            await _repository.DeleteDeliveryAsync(delivery, token);

            return Unit.Value;
        }
    }
}

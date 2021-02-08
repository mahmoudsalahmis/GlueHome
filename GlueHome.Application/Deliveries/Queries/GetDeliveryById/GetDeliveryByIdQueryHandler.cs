using AutoMapper;
using GlueHome.Application.Exceptions;
using GlueHome.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GlueHome.Application.Deliveries.Queries.GetDeliveryById
{
    public class GetDeliveryByIdQueryHandler : IRequestHandler<GetDeliveryByIdQuery, GetDeliveryByIdResponse>
    {
        private readonly IGetDeliveryByIdRepository _repository;
        private readonly IMapper _mapper;

        public GetDeliveryByIdQueryHandler(IGetDeliveryByIdRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetDeliveryByIdResponse> Handle(GetDeliveryByIdQuery request, CancellationToken token)
        {
            var delivery = await _repository.GetDeliveryByIdAsync(request.Id, token);

            if (delivery == null)
            {
                throw new NotFoundException(nameof(Delivery), request.Id);
            }

            return _mapper.Map<GetDeliveryByIdResponse>(delivery);
        }
    }
}

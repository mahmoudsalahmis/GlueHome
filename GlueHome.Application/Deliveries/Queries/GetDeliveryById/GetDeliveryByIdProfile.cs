using AutoMapper;
using GlueHome.Domain.Entities;


namespace GlueHome.Application.Deliveries.Queries.GetDeliveryById
{
    public class GetDeliveryByIdProfile : Profile
    {
        public GetDeliveryByIdProfile()
        {
            CreateMap<Delivery, GetDeliveryByIdResponse>();
        }
    }
}

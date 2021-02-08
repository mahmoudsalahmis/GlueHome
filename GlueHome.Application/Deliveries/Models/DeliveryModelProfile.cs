using AutoMapper;
using GlueHome.Application.Deliveries.Commands.CreateDelivery;
using GlueHome.Domain.Entities;

namespace GlueHome.Application.Deliveries.Models
{
    public class DeliveryModelProfile : Profile
    {
        public DeliveryModelProfile()
        {
            CreateMap<Delivery, DeliveryModel>().ReverseMap();
        }
    }
}

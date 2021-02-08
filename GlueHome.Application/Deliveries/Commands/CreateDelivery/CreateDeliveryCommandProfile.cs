using AutoMapper;
using GlueHome.Domain.Entities;

namespace GlueHome.Application.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommandProfile: Profile
    {
        public CreateDeliveryCommandProfile()
        {
            CreateMap<CreateDeliveryCommand, Delivery>();
        }
    }
}

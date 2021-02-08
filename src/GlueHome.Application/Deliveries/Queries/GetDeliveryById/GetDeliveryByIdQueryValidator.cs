using System;
using FluentValidation;

namespace GlueHome.Application.Deliveries.Queries.GetDeliveryById
{
    public class GetDeliveryByIdQueryValidator : AbstractValidator<GetDeliveryByIdQuery>
    {
        public GetDeliveryByIdQueryValidator()
        {
            PerformValidation();
        }

        private void PerformValidation()
        {
            RuleFor(c => c.Id).Must(id => Guid.Empty != id);
        }
    }
}

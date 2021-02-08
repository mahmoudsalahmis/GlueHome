using FluentValidation;
using GlueHome.Application.Deliveries.Models;
using System;

namespace GlueHome.Application.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommandValidator : AbstractValidator<UpdateDeliveryCommand>
    {
        public UpdateDeliveryCommandValidator()
        {
            PerformValidation();
        }

        private void PerformValidation()
        {
            RuleFor(c => c.Id).Must(id => Guid.Empty != id);

            RuleFor(c => c).SetValidator(new DeliveryModelValidator());
        }
    }
}

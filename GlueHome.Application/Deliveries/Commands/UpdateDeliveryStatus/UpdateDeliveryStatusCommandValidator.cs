using FluentValidation;
using System;

namespace GlueHome.Application.Deliveries.Commands.UpdateDeliveryStatus
{
    public class UpdateDeliveryStatusCommandValidator : AbstractValidator<UpdateDeliveryStatusCommand>
    {
        public UpdateDeliveryStatusCommandValidator()
        {
            PerformValidation();
        }

        private void PerformValidation()
        {
            RuleFor(c => c.Id).Must(id => Guid.Empty != id);
        }
    }
}

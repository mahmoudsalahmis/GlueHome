using FluentValidation;
using System;

namespace GlueHome.Application.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommandValidator : AbstractValidator<DeleteDeliveryCommand>
    {
        public DeleteDeliveryCommandValidator()
        {
            PerformValidation();
        }

        private void PerformValidation()
        {
            RuleFor(c => c.Id).Must(id => Guid.Empty != id);
        }
    }
}

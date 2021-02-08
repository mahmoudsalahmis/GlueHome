using FluentValidation;
using System;
using GlueHome.Application.Deliveries.Models;

namespace GlueHome.Application.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommandValidator : AbstractValidator<CreateDeliveryCommand>
    {
        private readonly ICreateDeliveryRepository _repository;

        public CreateDeliveryCommandValidator(ICreateDeliveryRepository repository)
        {
            _repository = repository;

            PerformValidation();
        }

        private void PerformValidation()
        {
            RuleFor(c => c).SetValidator(new DeliveryModelValidator());

            RuleFor(c => c.Id).Must(id => Guid.Empty != id)
                .DependentRules(() =>
                        RuleFor(c => c.Id)
                        .MustAsync(_repository.DeliveryDoesNotExistAsync)
                        .WithMessage("The delivery already exists.")
                    );
        }
    }
}

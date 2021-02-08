using System;
using FluentValidation;

namespace GlueHome.Application.Deliveries.Models
{
    public class DeliveryModelValidator : AbstractValidator<DeliveryModel>
    {
        public DeliveryModelValidator()
        {
            PerformValidation();
        }
        
        private void PerformValidation()
        {
            RuleFor(c => c.AccessWindow.StartTime).GreaterThan(DateTime.UtcNow.Date.AddDays(1));

            RuleFor(c => c.AccessWindow.EndTime).GreaterThan(c => c.AccessWindow.StartTime);

            RuleFor(c => c.Recipient.Name).NotEmpty();

            RuleFor(c => c.Recipient.Address).NotEmpty();

            RuleFor(c => c.Recipient.Email).EmailAddress();

            RuleFor(c => c.Recipient.PhoneNumber).MinimumLength(10);

            RuleFor(c => c.Order.OrderNumber).NotEmpty();

            RuleFor(c => c.Order.Sender).NotEmpty();
        }
    }
}

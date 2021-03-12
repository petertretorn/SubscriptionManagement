using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.AddSubscription
{
    public class AddSubscriptionCommandValidator : AbstractValidator<AddSubscriptionCommand>
    {
        public AddSubscriptionCommandValidator()
        {
            RuleFor(c => c.Start)
                .Must(d => d >= DateTime.Now)
                .WithMessage("Cannot create new subscription with start date in the past");

            // etc - TODO
        }
    }
}

using SubscriptionManagement.Domain.Entities;
using SubscriptionManagement.Domain.ValueObjects;
using System;

namespace SubscriptionManagement.Application.Features.AddSubscription
{

    public static class SubscriptionMapper
    {
        public static Subscription Map(AddSubscriptionCommand command)
        {
            var pricingPlan = new PricingPlan
            {
                CurrencyCode = command.CurrencyCode,
                FlatFee = command.FlatFee,
                MonthlyRate = command.MonthlyRate
            };

            var type = new SubscriptionType
            {
                Description = command.Description,
                Level = (Level)Enum.Parse(typeof(Level), command.Level),
                PeriodInDays = command.SubscriptionPeriodInDays,
                ProductId = command.ProductId
            };

            return new Subscription(command.CustomerId, command.Start, type, pricingPlan);
        }
    }
}

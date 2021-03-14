using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    public static class SubscriptionMapper
    {
        public static SubscriptionDto Map(Subscription subscription)
        {
            return new SubscriptionDto
            {
                Id = subscription.Id,
                Start = subscription.Start,
                Level = subscription.Type.Level.ToString(),
                Category = subscription.Type.Category.ToString(),
                PeriodInDays = subscription.Type.PeriodInDays,
                ProductId = subscription.Type.ProductId
            };
        }
    }
}

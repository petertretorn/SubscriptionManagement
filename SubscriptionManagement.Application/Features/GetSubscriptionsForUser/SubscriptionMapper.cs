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
                Start = subscription.Start,
                Description = subscription.Type.Description,
                Level = subscription.Type.Level.ToString(),
                PeriodInDays = subscription.Type.PeriodInDays,
                ProductId = subscription.Type.ProductId
            };
        }
    }
}

using System;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    
    public class SubscriptionDto
    {
        public DateTime SubscriptionStart { get; set; }
        public int SubscriptionPeriodInDays { get; set; }
        public Guid SubscriptionProductId { get; set; }

        public string SubscriptionLevel { get; set; }
        public string SubscriptionDescription { get; set; }
    }
}
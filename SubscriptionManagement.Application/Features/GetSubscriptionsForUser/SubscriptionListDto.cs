using System;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    
    public class SubscriptionDto
    {
        public DateTime Start { get; set; }
        public int PeriodInDays { get; set; }
        public Guid ProductId { get; set; }

        public string Level { get; set; }
        public string Description { get; set; }
    }
}
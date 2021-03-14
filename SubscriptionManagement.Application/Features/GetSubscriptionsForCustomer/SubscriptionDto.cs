using System;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public int PeriodInDays { get; set; }
        public Guid ProductId { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
    }
}
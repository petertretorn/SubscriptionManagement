using SubscriptionManagement.Domain.Common;
using System;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class PricingPlan : ValueObject
    {
        public decimal FlatFee { get; set; }
        public decimal MonthlyRate { get; set; }
        public String CurrencyCode { get; set; }
    }
}

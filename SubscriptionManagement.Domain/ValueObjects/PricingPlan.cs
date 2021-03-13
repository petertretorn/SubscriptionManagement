using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class PricingPlan
    {
        public decimal FlatFee { get; set; }
        public decimal MonthlyRate { get; set; }
        public String CurrencyCode { get; set; }
    }
}

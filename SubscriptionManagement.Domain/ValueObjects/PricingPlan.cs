using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class PricingPlan
    {
        public Money FlatFee { get; set; }
        public Money MonthlyRate { get; set; }
    }
}

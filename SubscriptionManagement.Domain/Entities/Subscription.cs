using SubscriptionManagement.Domain.Contracts;
using SubscriptionManagement.Domain.Util;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.Entities
{
    public class Subscription : Entity
    {
        private Subscription() { }
        public Subscription(Guid customerId, DateTime start, SubscriptionType type, PricingPlan pricingPlan)
        {
            CustomerId = customerId;
            Start = start;
            Type = type;
            PricingPlan = pricingPlan;
        }
        public Guid CustomerId { get; private set; }
        public DateTime Start { get; private set; }

        public DateTime? End { get; private set; }

        public SubscriptionType Type { get; private set; }
        public PricingPlan PricingPlan { get; private set; }
        
        public bool HasDefaulted { get; private set; }

        //this method could be invoked in response to event received from a possible Billing context/service
        public void MarkSubscriptionAsDefaulted()
        {
            HasDefaulted = true;
        }

        public void Cancel()
        {
            var isRenewedToday = RemainingDays() == 0;

            if (isRenewedToday)
            {
                End = DateTime.Now;
                return;
            }

            var remainingDays = Type.PeriodInDays - RemainingDays();

            End = DateTime.Now + TimeSpan.FromDays(remainingDays);

            int RemainingDays()
            {
                return ((DateTime.Now - Start).Days % Type.PeriodInDays);
            }
        }

        public bool IsActive()
        {
            return DateTime.Now <= End;
        }


    }
}

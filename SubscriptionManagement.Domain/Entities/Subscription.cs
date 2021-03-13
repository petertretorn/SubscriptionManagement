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
        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public SubscriptionType SubscriptionType { get; private set; }
        public PricingPlan PricingPlan { get; private set; }


        public bool AutomaticallyReneweble { get; private set; }
        
        public bool HasDefaulted { get; private set; }

        //this method could be invoked in response to event received from a possible Billing context/service
        public void MarkSubscriptionAsDefaulted()
        {
            HasDefaulted = true;
        }

        public void Cancel()
        {
            AutomaticallyReneweble = false;

            var isRenewedToday = RemainingDays() == 0;

            if (isRenewedToday)
            {
                End = DateTime.Now;
                return;
            }

            var remainingDays = SubscriptionType.SubscriptionPeriodInDays - RemainingDays();

            End = DateTime.Now + TimeSpan.FromDays(remainingDays);

            int RemainingDays()
            {
                return ((DateTime.Now - Start).Days % SubscriptionType.SubscriptionPeriodInDays);
            }
        }

        public bool IsActive()
        {
            return DateTime.Now <= End;
        }


    }
}

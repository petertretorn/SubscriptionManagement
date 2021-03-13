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
        public Guid CustomerId { get; set; }
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public SubscriptionType SubscriptionType { get; set; }
        public PricingPlan PricingPlan { get; set; }


        public bool AutomaticallyReneweble { get; set; }
        
        public bool HasDefaulted { get; set; }

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

            var remainingDays = SubscriptionType.PeriodInDays - RemainingDays();

            End = DateTime.Now + TimeSpan.FromDays(remainingDays);

            int RemainingDays()
            {
                return ((DateTime.Now - Start).Days % SubscriptionType.PeriodInDays);
            }
        }

        public bool IsActive()
        {
            return DateTime.Now <= End;
        }


    }
}

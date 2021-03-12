using SubscriptionManagement.Domain.Contracts;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.Entities
{
    public class Subscription
    {
        public DateTime Start { get; }

        private DateTime _end;
        public DateTime End
        {
            get
            {
                return _end;
            }
        }

        public SubscriptionType SubscriptionType { get; }
        public PricingPlan PricingPlan { get; }


        private bool _automaticallyReneweble;
        public bool AutomaticallyReneweble
        {
            get
            {
                return _automaticallyReneweble;
            }
        }

        //this field could be updated from event received from a Billing context/service
        public bool _hasDefaulted;
        public bool HasDefaulted { get; }
        public void MarkSubscriptionAsDefaulted()
        {
            _hasDefaulted = true;
        }

        public void Cancel()
        {
            _automaticallyReneweble = false;

            var isRenewedToday = RemainingDays() == 0;

            if (isRenewedToday)
            {
                _end = DateTime.Now;
                return;
            }

            var remainingDays = SubscriptionType.Duration.Days - RemainingDays();

            _end = DateTime.Now + TimeSpan.FromDays(remainingDays);

            int RemainingDays()
            {
                return ((DateTime.Now - Start).Days % SubscriptionType.Duration.Days);
            }
        }

        public bool IsActive()
        {
            return DateTime.Now <= End;
        }


    }
}

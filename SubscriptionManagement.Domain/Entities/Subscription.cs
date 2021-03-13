using SubscriptionManagement.Domain.Contracts;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.Entities
{
    public class Subscription
    {
        public DateTime Start { get; private set; }

        private DateTime _end;
        public DateTime End
        {
            get
            {
                return _end;
            }
        }

        public SubscriptionType SubscriptionType { get; private set; }
        public PricingPlan PricingPlan { get; private set; }


        private bool _automaticallyReneweble;
        public bool AutomaticallyReneweble
        {
            get
            {
                return _automaticallyReneweble;
            }
        }

        
        public bool _hasDefaulted;
        public bool HasDefaulted { get; }

        //this method could be invoked in response to event received from a possible Billing context/service
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

            var remainingDays = SubscriptionType.SubscriptionPeriodInDays - RemainingDays();

            _end = DateTime.Now + TimeSpan.FromDays(remainingDays);

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

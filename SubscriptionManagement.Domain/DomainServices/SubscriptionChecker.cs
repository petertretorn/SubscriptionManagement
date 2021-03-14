using SubscriptionManagement.Domain.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.DomainServices
{
    public class SubscriptionChecker
    {
        public SubscriptionChecker(IEnumerable<ISubscriptionRule> rules)
        {
            this._subscriptionRules = rules;
        }

        // TODO - register with DI container to inject rules
        public SubscriptionChecker()
        {
            this._subscriptionRules = new List<ISubscriptionRule> { new NoOverDuePaymentRule(), new ResidenceRule() };
        }

        private IEnumerable<ISubscriptionRule> _subscriptionRules;

        public bool CheckEligibility(Customer customer)
        {
            foreach (var subscription in customer.Subscriptions)
            {
                foreach (var rule in this._subscriptionRules)
                {
                    var isRuleFulfilled = rule.Evaluate(subscription);

                    if (!isRuleFulfilled) return false;
                }
            }

            return true;
        }
    }


    public class NoOverDuePaymentRule : ISubscriptionRule
    {
        public string Description
        {
            get
            {
                return "No Overdue Payments of Existing Subscriptions";
            }
        }

        public bool Evaluate(Subscription subscription)
        {
            return !subscription.HasDefaulted;
        }
    }

    public class ResidenceRule : ISubscriptionRule
    {
        public string Description
        {
            get
            {
                return "Only EU residents";
            }
        }

        public bool Evaluate(Subscription subscription)
        {
            return true;
        }
    }
}

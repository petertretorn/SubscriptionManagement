using SubscriptionManagement.Domain.Contracts;
using SubscriptionManagement.Domain.Util;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubscriptionManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public String Email { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

        public void AddSubscription(Subscription newSubscription)
        {
            Subscriptions = new List<Subscription>(Subscriptions)
            {
                newSubscription
            };
        }
    }
}

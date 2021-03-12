using SubscriptionManagement.Domain.Contracts;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubscriptionManagement.Domain.Entities
{
    public class User
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Email Email { get; set; }

        private List<Subscription> _subscriptions = new List<Subscription>();

        public IReadOnlyCollection<Subscription> Subscriptions
        {
            get
            {
                return _subscriptions;
            }
        }


        public void AddSubscription(Subscription newSubscription)
        {
            this._subscriptions.Add(newSubscription);
        }
    }
}

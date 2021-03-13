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
        public String Email { get; set; }

        public List<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

        //public IReadOnlyCollection<Subscription> Subscriptions
        //{
        //    get
        //    {
        //        return _subscriptions;
        //    }
        //    private set
        //    {
        //        _subscriptions = value;
        //    }
        //}


        public void AddSubscription(Subscription newSubscription)
        {
            Subscriptions.Add(newSubscription);
        }
    }
}

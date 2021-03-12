using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.Contracts
{
    public interface ISubscriptionRule
    {
        public bool Evaluate(Subscription subscription);
        public String Description { get; }

    }
}

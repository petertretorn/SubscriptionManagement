using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Contracts
{
    public interface ISubscriptionRepository : IAsyncRepository<Subscription>
    {
        // specific methods related to Subscription persistence here
    }
}

using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.Application.Contracts
{
    public interface ISubscriptionRepository : IAsyncRepository<Subscription>
    {
        public Task<IEnumerable<Subscription>> GetSubscriptionsForCustomer(Guid customerId);
    }
}

using Microsoft.EntityFrameworkCore;
using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManagement.Infrastructure
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository 
    {
        public SubscriptionRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Subscription>> GetSubscriptionsForCustomer(Guid customerId)
        {
            return await _dbContext.Subscriptions.Where(s => s.CustomerId == customerId).ToListAsync();
        }

    }
}

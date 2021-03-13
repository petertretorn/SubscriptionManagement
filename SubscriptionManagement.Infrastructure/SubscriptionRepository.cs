using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Infrastructure
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository 
    {
        public SubscriptionRepository(DataContext context) : base(context)
        {
        }

        // TODO
    }
}

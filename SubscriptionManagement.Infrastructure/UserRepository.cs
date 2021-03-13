using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Infrastructure
{
    class UserRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        // TODO
    }
}

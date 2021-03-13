using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Infrastructure
{
    class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        // TODO
    }
}

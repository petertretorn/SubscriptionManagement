using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Contracts
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        // specific methods related to User persistence here
    }
}

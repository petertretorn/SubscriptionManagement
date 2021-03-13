using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Contracts
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        // specific methods related to User persistence here
    }
}

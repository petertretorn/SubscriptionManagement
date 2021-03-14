using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Domain.Entities;

namespace SubscriptionManagement.Infrastructure
{
    class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }

        // TODO
    }
}

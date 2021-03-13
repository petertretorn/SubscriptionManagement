using SubscriptionManagement.Domain.Entities;

namespace SubscriptionManagement.Domain.Contracts
{
    public interface ISubscriptionChecker
    {
        bool CheckEligibility(Customer user);
    }
}
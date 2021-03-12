using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Exceptions
{
    public class NotEligibleException : ApplicationException
    {
        public NotEligibleException(Guid userId) : base($"User with Id {userId} not Eligible for Subscription")
        {

        }
    }
}

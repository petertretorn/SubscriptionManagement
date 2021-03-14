using SubscriptionManagement.Domain.Common;
using System;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public String Street { get; set; }

        public String City { get; set; }
        public String PostalCode { get; set; }
    }
}

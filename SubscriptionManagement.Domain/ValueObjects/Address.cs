using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class Address
    {
        public String Street { get; set; }

        public String City { get; set; }
        public String PostalCode { get; set; }
    }
}

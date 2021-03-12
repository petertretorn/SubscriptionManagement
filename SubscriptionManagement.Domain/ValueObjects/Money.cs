using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class Money
    {
        public Money(decimal ammount, string currencyCode)
        {
            Ammount = ammount;
            CurrencyCode = currencyCode;
        }

        public decimal Ammount { get; }
        public string CurrencyCode { get;}
    }

}

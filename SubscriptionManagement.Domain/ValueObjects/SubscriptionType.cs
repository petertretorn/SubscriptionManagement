using SubscriptionManagement.Domain.Common;
using System;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class SubscriptionType : ValueObject
    {
        public Guid ProductId { get; set; }
        public Level Level { get; set; }
        public Category Category { get; set; }
        public int PeriodInDays { get; set; }
    }

    public enum Level
    {
        Basic = 1,
        Standard = 2,
        Premium = 4
    }

    public enum Category
    {
        TV = 1,
        Broadband = 2,
        BlockBuster = 4
    }
}

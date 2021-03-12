using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Domain.Entities
{
    public class SubscriptionType
    {
        public Guid ProductId { get; set; }

        public Level Level { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }

    }

    public enum Level
    {
        Basic = 1,
        Standard = 2,
        Premium = 4
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.AddSubscription
{
    public class AddSubscriptionCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid ProductId { get; set; }
        public String Level { get; set; }
        public string Description { get; set; }
        public decimal FlatFee { get; set; }
        public decimal MonthlyRate { get; set; }
        public string CurrencyCode { get; set; }
        public int SubscriptionPeriodInDays { get; set; }
        public bool AutomaticallyReneweble { get; set; }
    }
}

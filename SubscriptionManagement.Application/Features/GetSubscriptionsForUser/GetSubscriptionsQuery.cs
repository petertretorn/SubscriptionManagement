using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    public class GetSubscriptionsQuery : IRequest<SubscriptionListDto>
    {
        public Guid MyProperty { get; set; }
    }
}

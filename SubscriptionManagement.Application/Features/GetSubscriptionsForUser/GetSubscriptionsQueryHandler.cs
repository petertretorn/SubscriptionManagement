using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, SubscriptionListDto>
    {
        public Task<SubscriptionListDto> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

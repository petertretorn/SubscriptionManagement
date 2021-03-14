using AutoMapper;
using MediatR;
using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, IEnumerable<SubscriptionDto>>
    {
        private ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptionsQueryHandler(
            ISubscriptionRepository subscriptionRepository)
        {
            this._subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetSubscriptionsForCustomer(request.CustomerId);

            var subscriptionDtos = subscriptions.Select(SubscriptionMapper.Map);

            return subscriptionDtos;
        }
    }
}

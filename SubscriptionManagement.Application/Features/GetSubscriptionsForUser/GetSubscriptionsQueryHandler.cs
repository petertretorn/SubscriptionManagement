using AutoMapper;
using MediatR;
using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubscriptionManagement.Application.Features.GetSubscriptionsForUser
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, IEnumerable<SubscriptionDto>>
    {
        private ISubscriptionRepository _subscriptionRepository;
        private IMapper _mapper;

        public GetSubscriptionsQueryHandler(
            ISubscriptionRepository subscriptionRepository,
            IMapper mapper)
        {
            this._subscriptionRepository = subscriptionRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetSubscriptionsForCustomer(request.CustomerId);

            var subscriptionDtos = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);

            return subscriptionDtos;
        }
    }
}

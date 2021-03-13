using MediatR;
using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Application.Exceptions;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubscriptionManagement.Application.Features.DeleteSubscription
{
    class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand>
    {
        private ISubscriptionRepository _subscriptionRepository;

        public DeleteSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            this._subscriptionRepository = subscriptionRepository;
        }
        public async Task<Unit> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscriptionToDelete = await _subscriptionRepository.GetByIdAsync(request.SubscriptionId);

            if (subscriptionToDelete == null)
            {
                throw new NotFoundException(nameof(Subscription), request.SubscriptionId);
            }

            await _subscriptionRepository.DeleteAsync(subscriptionToDelete);

            return Unit.Value;
        }
    }
}

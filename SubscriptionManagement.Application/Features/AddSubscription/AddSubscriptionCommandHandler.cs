using MediatR;
using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Application.Exceptions;
using SubscriptionManagement.Domain.DomainServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SubscriptionManagement.Application.Features.AddSubscription
{
    public class AddSubscriptionCommandHandler : IRequestHandler<AddSubscriptionCommand, Guid>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ICustomerRepository _customerRepository;

        public AddSubscriptionCommandHandler(
            ISubscriptionRepository subscriptionRepository, 
            ICustomerRepository customerRepository)
        {
            this._subscriptionRepository = subscriptionRepository;
            this._customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(AddSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddSubscriptionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var subscription = SubscriptionMapper.Map(request);

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            var subscriptionChecker = new SubscriptionChecker();
            var isEligible = subscriptionChecker.CheckEligibility(customer);

            if (!isEligible)
            {
                throw new NotEligibleException(request.CustomerId);
            }

            await _subscriptionRepository.AddAsync(subscription);

            return subscription.Id;
        }
    }
}

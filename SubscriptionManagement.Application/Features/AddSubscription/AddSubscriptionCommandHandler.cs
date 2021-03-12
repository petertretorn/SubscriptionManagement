using AutoMapper;
using MediatR;
using SubscriptionManagement.Application.Contracts;
using SubscriptionManagement.Application.Exceptions;
using SubscriptionManagement.Domain.Contracts;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubscriptionManagement.Application.Features.AddSubscription
{
    public class AddSubscriptionCommandHandler : IRequestHandler<AddSubscriptionCommand, Guid>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubscriptionChecker _subscriptionChecker;
        private readonly IMapper _mapper;

        public AddSubscriptionCommandHandler(
            ISubscriptionRepository subscriptionRepository, 
            IUserRepository userRepository,
            ISubscriptionChecker subscriptionChecker,
            IMapper mapper)
        {
            this._subscriptionRepository = subscriptionRepository;
            this._userRepository = userRepository;
            this._subscriptionChecker = subscriptionChecker;
            this._mapper = mapper;
        }

        public async Task<Guid> Handle(AddSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddSubscriptionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var subscription = _mapper.Map<Subscription>(request);

            var user = await _userRepository.GetByIdAsync(request.UserId);

            var isEligible = _subscriptionChecker.CheckEligibility(user);

            if (!isEligible)
            {
                throw new NotEligibleException(request.UserId);
            }

            await _subscriptionRepository.AddAsync(subscription);
            

            throw new NotImplementedException();
        }
    }
}

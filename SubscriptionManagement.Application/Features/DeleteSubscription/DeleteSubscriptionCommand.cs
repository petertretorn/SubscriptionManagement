using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.DeleteSubscription
{
    public class DeleteSubscriptionCommand : IRequest
    {
        public Guid SubscriptionId { get; set; }
    }
}

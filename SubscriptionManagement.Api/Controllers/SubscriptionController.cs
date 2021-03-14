using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionManagement.Application.Features.AddSubscription;
using SubscriptionManagement.Application.Features.DeleteSubscription;
using SubscriptionManagement.Application.Features.GetSubscriptionsForUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionManagement.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        
        [HttpPost(Name = "AddSubscription")]
        public async Task<ActionResult<Guid>> Create([FromBody] AddSubscriptionCommand command)
        {
            var id = await _mediator.Send(command);
            
            return Ok(id);
        }

        
        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetSubscriptionsForCustomer(Guid customerId)
        {
            var query = new GetSubscriptionsQuery
            {
                CustomerId = customerId
            };

            var result = await _mediator.Send(query);
            
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteSubscription")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteSubscriptionCommand() { SubscriptionId = id };
            
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}

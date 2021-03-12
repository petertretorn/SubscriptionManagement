using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionManagement.Application.Features.AddSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionManagement.Api.Controllers
{
    [Route("api/[controller]/{subscriptionId}")]
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
    }
}

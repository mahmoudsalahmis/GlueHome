using GlueHome.Application.Deliveries.Commands.CreateDelivery;
using GlueHome.Application.Deliveries.Commands.DeleteDelivery;
using GlueHome.Application.Deliveries.Commands.UpdateDelivery;
using GlueHome.Application.Deliveries.Queries.GetDeliveryById;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GlueHome.Web.Controllers
{
    public class DeliveryController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateDeliveryCommand command)
        {
            var response = await Mediator.Send(command);

            var deliveryId = response.DeliveryId;
            return new CreatedResult(new Uri($"{Request.Path}/{deliveryId}", UriKind.Relative), new { Id = deliveryId.ToString() });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDeliveryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Id in the payload does not match query string Id.");
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<GetDeliveryByIdResponse> Get(Guid id)
        {
            return await Mediator.Send(new GetDeliveryByIdQuery { Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        { 
            await Mediator.Send(new DeleteDeliveryCommand { Id = id });
            return NoContent();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Application.Service.Commands.CreateService;
using ExampleProject.Application.Service.Commands.DeleteService;
using ExampleProject.Application.Service.Commands.UpdateService;
using ExampleProject.Application.Service.Queries.GetAllService;
using ExampleProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebUI.Controllers.Services
{
    [Authorize]
    public class ServicesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllServices([FromQuery] GetAllServiceQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateServiceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateServiceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteServiceCommand() { Id = id });

            return NoContent();
        }
    }
}
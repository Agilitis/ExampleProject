using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Application.Rent.Commands.CreateRent;
using ExampleProject.Application.Rent.Commands.DeleteRent;
using ExampleProject.Application.Rent.Commands.UpdateRent;
using ExampleProject.Application.Rent.Queries.GetAllRent;
using ExampleProject.Application.ServicePartner.Commands.CreateServicePartner;
using ExampleProject.Application.ServicePartner.Commands.DeleteServicePartner;
using ExampleProject.Application.ServicePartner.Commands.UpdateServicePartner;
using ExampleProject.Application.ServicePartner.Queries.GetAllServiceParnter;
using ExampleProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebUI.Controllers.ServicePartners
{
    [Authorize]
    public class ServicePartnersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllServicePartners([FromQuery] GetAllServicePartnerQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateServicePartnerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateServicePartnerCommand command)
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
            await Mediator.Send(new DeleteServicePartnerCommand() { Id = id });

            return NoContent();
        }
    }
}
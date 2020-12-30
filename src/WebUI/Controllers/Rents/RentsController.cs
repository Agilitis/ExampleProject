using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Application.Car.Commands.CreateCar;
using ExampleProject.Application.Car.Commands.DeleteCar;
using ExampleProject.Application.Car.Commands.UpdateCar;
using ExampleProject.Application.Car.Queries.GetAllCarsQuery;
using ExampleProject.Application.Rent.Commands.CreateRent;
using ExampleProject.Application.Rent.Commands.DeleteRent;
using ExampleProject.Application.Rent.Commands.UpdateRent;
using ExampleProject.Application.Rent.Queries.GetAllRent;
using ExampleProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebUI.Controllers.Rents
{
    [Authorize]
    public class RentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllRents([FromQuery] GetAllRentQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRentCommand command)
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
            await Mediator.Send(new DeleteRentCommand() { Id = id });

            return NoContent();
        }
    }
}
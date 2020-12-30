using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Application.Car.Commands.CreateCar;
using ExampleProject.Application.Car.Commands.DeleteCar;
using ExampleProject.Application.Car.Commands.UpdateCar;
using ExampleProject.Application.Car.Queries.GetAllCarsQuery;
using ExampleProject.Application.CarPart.Commands.CreateCarPart;
using ExampleProject.Application.CarPart.Commands.DeleteCarPart;
using ExampleProject.Application.CarPart.Commands.UpdateCarPart;
using ExampleProject.Application.CarPart.Queries.GetAllCarPartsCommand;
using ExampleProject.Application.Rent.Queries.GetAllRent;
using ExampleProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebUI.Controllers.CarParts
{
    [Authorize]
    public class CarPartsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarPart>>> GetAllCarParts([FromQuery] GetAllCarPartQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCarPartCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCarPartCommand command)
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
            await Mediator.Send(new DeleteCarPartCommand() { Id = id });

            return NoContent();
        }
    }
}
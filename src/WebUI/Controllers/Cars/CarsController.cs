using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Application.Car.Commands.CreateCar;
using ExampleProject.Application.Car.Commands.DeleteCar;
using ExampleProject.Application.Car.Commands.UpdateCar;
using ExampleProject.Application.Car.Queries.GetAllCarsQuery;
using ExampleProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebUI.Controllers.Cars
{
    [Authorize]
    public class CarsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCarCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars([FromQuery] GetAllCarsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCarCommand command)
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
            await Mediator.Send(new DeleteCarCommand() { Id = id });

            return NoContent();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Application.Car.Queries.GetAllCarsQuery;
using ExampleProject.Application.Common.Security;
using ExampleProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebUI.Controllers.Cars
{
    [Authorize]
    public class CarsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get(GetAllCarsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
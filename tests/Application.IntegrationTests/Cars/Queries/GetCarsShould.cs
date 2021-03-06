using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Application.Car.Queries.GetAllCarsQuery;
using ExampleProject.Application.TodoLists.Queries.GetTodos;
using ExampleProject.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static Testing;

namespace ExampleProject.Application.IntegrationTests.Cars.Queries
{
    public class GetCarsShould : TestBase
    {
        [Test]
        public async Task ReturnCars()
        {
            var cars = new List<Domain.Entities.Car>
            {
                new Domain.Entities.Car()
                {
                    DailyRentPrice = 100
                },
                new Domain.Entities.Car()
                {
                    DailyRentPrice = 200
                },
                new()
                {
                    DailyRentPrice = 300,
                    Accessories = new List<Accessory>
                    {
                        new Accessory
                        {
                            MarketPrice = 10,
                            Name = "TestAccessory"
                        }
                    }
                },
            };

            foreach (var car in cars)
            {
                await AddAsync(car);
            }

            var query = new GetAllCarsQuery();

            var result = await SendAsync(query);

            result.Should().SatisfyRespectively(car1 => { car1.DailyRentPrice = 100; },
                car2 => { car2.DailyRentPrice = 200; },
                car3 => { car3.DailyRentPrice = 300; });
        }
    }
}
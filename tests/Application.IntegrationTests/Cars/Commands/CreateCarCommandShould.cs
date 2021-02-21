using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleProject.Domain.Entities;
using ExampleProject.Domain.Enums;
using FluentAssertions;
using NUnit.Framework;
using static Testing;

namespace ExampleProject.Application.IntegrationTests.Cars.Commands
{
    public class CreateCarCommandShould : TestBase
    {
        [Test]
        public async Task CreateCar()
        {
          var createCarCommand = new Car.Commands.CreateCar.CreateCarCommand
            {
                MarketPrice = 1600000,
                DailyRentPrice = 4500,
                Type = CarType.Audi,
            };

            var id = await SendAsync(createCarCommand);

            var car = await GetCarAsync(id);
            
            car.MarketPrice.Should().Be(1600000);
            car.DailyRentPrice.Should().Be(4500);
            car.Type.Should().Be(CarType.Audi);
        }
        
    }
}
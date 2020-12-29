using System.Threading.Tasks;
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
                CarColor = "Blue",
                MarketPrice = 100,
                DailyRentPrice = 200,
                Type = CarType.Audi
            };

            var id = await SendAsync(createCarCommand);

            var car = await FindAsync<Domain.Entities.Car>(id);

            car.CarColor.Should().Be("Blue");
            car.MarketPrice.Should().Be(100);
            car.DailyRentPrice.Should().Be(200);
            car.Type.Should().Be(CarType.Audi);
        }
    }
}
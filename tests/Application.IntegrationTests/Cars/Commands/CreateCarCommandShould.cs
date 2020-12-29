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
            var accessory = new Accessory
            {
                Name = "TestAccessory",
                MarketPrice = 100,
                RentPrice = 10
            };
            
            await AddAsync(accessory);
            
            var createCarCommand = new Car.Commands.CreateCar.CreateCarCommand
            {
                CarColor = "Blue",
                MarketPrice = 100,
                DailyRentPrice = 200,
                Type = CarType.Audi,
                Accessories = new List<Accessory>
                {
                    accessory
                }
            };

            var id = await SendAsync(createCarCommand);

            var car = await GetCarAsync(id);
            
            car.CarColor.Should().Be("Blue");
            car.MarketPrice.Should().Be(200);
            car.DailyRentPrice.Should().Be(210);
            car.Type.Should().Be(CarType.Audi);
            car.Accessories.Should().NotBeEmpty();
        }
    }
}
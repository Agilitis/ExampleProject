using System;
using System.Threading.Tasks;
using ExampleProject.Application.Rent.Commands.CreateRent;
using FluentAssertions;
using NUnit.Framework;
using static Testing;

namespace ExampleProject.Application.IntegrationTests.Rents.Commands
{
    public class CreateRendCommandShould : TestBase
    {
        [Test]
        public async Task CreateRent()
        {
            var userId = await RunAsDefaultUserAsync();
            
            var car = new Domain.Entities.Car
            {
                MarketPrice = 10,
                DailyRentPrice = 15
            };
            await AddAsync(car);
            
            var createRentCommand = new CreateRentCommand
            {
                UserId = userId,
                CarId = car.Id,
                RentLengthInDays = 10,
                StartDate = DateTime.Now
            };

            var rentId = await SendAsync(createRentCommand);

            var rent = await GetRentAsync(rentId);
            
            rent.Should().NotBeNull();
            rent.UserId.Should().Be(userId);
            rent.RentPrice.Should().Be(150);
        }
    }
}
using System.Collections.Generic;
using ExampleProject.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace ExampleProject.Domain.UnitTests.Entities
{
    public class CarShould
    {
        [Test]
        public void CalculateItsPriceBasedOnExtras()
        {
            var extra = new Extra
            {
                Name = "Test extra",
                Price = 3000
            };
            var car = new Car
            {
                Price = 1000,
                Extras = new List<Extra>
                {
                    extra
                }
            };

            var calculatedPrice = car.Price;

            calculatedPrice.Should().Be(4000);
        }
    }
}
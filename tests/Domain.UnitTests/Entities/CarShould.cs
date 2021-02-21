using System.Collections.Generic;
using ExampleProject.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace ExampleProject.Domain.UnitTests.Entities
{
    public class CarShould
    {
        [Test]
        public void CalculateItsPriceIncludingAccessories()
        {
            var accessory1 = new Accessory
            {
                Name = "Test accessory 1",
                MarketPrice = 3000
            };
            var accessory2 = new Accessory
            {
                Name = "Test accessory 2",
                MarketPrice = 2000
            };
            var car = new Car
            {
                MarketPrice = 1000,
                Accessories = new List<Accessory>
                {
                    accessory1,
                    accessory2
                }
            };

            var calculatedPrice = car.MarketPrice;

            calculatedPrice.Should().Be(6000);
        }
    }
    
}
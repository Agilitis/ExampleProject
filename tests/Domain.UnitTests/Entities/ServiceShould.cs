using ExampleProject.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Domain.UnitTests.Entities
{
    public class ServiceShould
    {
        [Test]
        public void CalculatePriceCorrectly()
        {
            var car = new Car();
            var servicePartner = new ServicePartner
            {
                ServiceFee = 500
            };
            var partsToReplace = new List<CarPart>()
            {
                new CarPart
                {
                    Name = "Clutch",
                    Price = 15000
                },
                new CarPart
                {
                    Name = "Windshield",
                    Price = 10000
                }
            };
            var service = new Service
            {
                Car = car,
                ServicePartner = servicePartner,
                CarPartsToReplace = partsToReplace
            };

            var priceToPay = service.TotalFee;

            priceToPay.Should().Be(25500);
            
        }
    }
}

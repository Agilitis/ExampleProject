using System;
using System.Collections.Generic;
using ExampleProject.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace ExampleProject.Domain.UnitTests.Entities
{
    public class RentShould
    {
        [Test]
        public void CalculateRentFromCar()
        {
            var car = new Car
            {
                DailyRentPrice = 2500,
                Accessories = new List<Accessory>
                {
                    new Accessory
                    {
                        RentPrice = 100
                    },
                    new Accessory
                    {
                        RentPrice = 200
                    },new Accessory
                    {
                        RentPrice = 200
                    },
                }
            };
            var rent = new Rent
            {
                Car = car,
                StartDate = DateTime.Now,
                RentLengthInDays = 10
            };

            var calculatedRentPrice = rent.RentPrice;

            calculatedRentPrice.Should().Be(30000);
        }
    }
}
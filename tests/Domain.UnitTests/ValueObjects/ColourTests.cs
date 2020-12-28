using ExampleProject.Domain.Exceptions;
using ExampleProject.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace ExampleProject.Domain.UnitTests.ValueObjects
{
    public class ColourTests
    {
        [Test]
        public void ShouldReturnCorrectColourCode()
        {
            var code = "#FFFFFF";

            var colour = CarColor.From(code);

            colour.Code.Should().Be(code);
        }

        [Test]
        public void ToStringReturnsCode()
        {
            var colour = CarColor.White;

            colour.ToString().Should().Be(colour.Code);
        }

        [Test]
        public void ShouldPerformImplicitConversionToColourCodeString()
        {
            string code = CarColor.White;

            code.Should().Be("#FFFFFF");
        }

        [Test]
        public void ShouldPerformExplicitConversionGivenSupportedColourCode()
        {
            var colour = (CarColor)"#FFFFFF";

            colour.Should().Be(CarColor.White);
        }

        [Test]
        public void ShouldThrowUnsupportedColourExceptionGivenNotSupportedColourCode()
        {
            FluentActions.Invoking(() => CarColor.From("##FF33CC"))
                .Should().Throw<UnsupportedColourException>();
        }
    }
}

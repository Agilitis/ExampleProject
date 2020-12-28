using ExampleProject.Domain.Common;
using ExampleProject.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ExampleProject.Domain.ValueObjects
{
    public class CarColor : ValueObject
    {
        static CarColor()
        {
        } 

        private CarColor()
        {
        }

        private CarColor(string code)
        {
            Code = code;
        }

        public static CarColor From(string code)
        {
            var colour = new CarColor { Code = code };

            if (!SupportedColours.Contains(colour))
            {
                throw new UnsupportedColourException(code);
            }

            return colour;
        }

        public static CarColor White => new CarColor("#FFFFFF");

        public static CarColor Red => new CarColor("#FF5733");

        public static CarColor Orange => new CarColor("#FFC300");

        public static CarColor Yellow => new CarColor("#FFFF66");

        public static CarColor Green => new CarColor("#CCFF99 ");

        public static CarColor Blue => new CarColor("#6666FF");

        public static CarColor Purple => new CarColor("#9966CC");

        public static CarColor Grey => new CarColor("#999999");

        public string Code { get; private set; }

        public static implicit operator string(CarColor colour)
        {
            return colour.ToString();
        }

        public static explicit operator CarColor(string code)
        {
            return From(code);
        }

        public override string ToString()
        {
            return Code;
        }

        protected static IEnumerable<CarColor> SupportedColours
        {
            get
            {
                yield return White;
                yield return Red;
                yield return Orange;
                yield return Yellow;
                yield return Green;
                yield return Blue;
                yield return Purple;
                yield return Grey;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}

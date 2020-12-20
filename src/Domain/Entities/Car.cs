using System.Collections.Generic;
using System.Linq;
using ExampleProject.Domain.Common;
using ExampleProject.Domain.Enums;

namespace ExampleProject.Domain.Entities
{
    public class Car : AuditableEntity
    {
        private readonly int _marketPrice;
        private readonly int _rentPrice;
        public int Id { get; set; }
        public IList<Accessory> Accessories { get; set; }
        public int MarketPrice
        {
            get
            {
                return _marketPrice + Accessories.Sum(extra => extra.MarketPrice);
            }
            init => _marketPrice = value;
        }
        public int RentPrice
        {
            get
            {
                return _rentPrice + Accessories.Sum(extra => extra.RentPrice);
            }
            init => _rentPrice = value;
        }
        public CarType Type { get; set; }
    }
}
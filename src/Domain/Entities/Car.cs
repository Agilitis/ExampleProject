using System.Collections.Generic;
using System.Linq;
using ExampleProject.Domain.Common;
using ExampleProject.Domain.Enums;
using ExampleProject.Domain.ValueObjects;

namespace ExampleProject.Domain.Entities
{
    public class Car : AuditableEntity
    {
        private readonly int _marketPrice;
        private readonly int _dailyRentPrice;
        public int Id { get; set; }
        public IList<Accessory> Accessories { get; set; } = new List<Accessory>();
        public int MarketPrice
        {
            get
            {
                if (Accessories.Any())
                {
                    return _marketPrice + Accessories.Sum(extra => extra.MarketPrice);
                }
                return _marketPrice;
            }
            init => _marketPrice = value;
        }
        public int DailyRentPrice
        {
            get
            {
                if (Accessories.Any())
                {
                    return _dailyRentPrice + Accessories.Sum(extra => extra.RentPrice);
                }
                return _dailyRentPrice;
            }
            init => _dailyRentPrice = value;
        }
        public bool IsAvailable { get; set; }
        public CarType Type { get; set; }

        public string CarColor { get; set; }
    }
}
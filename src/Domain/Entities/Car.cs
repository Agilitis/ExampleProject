using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ExampleProject.Domain.Common;
using ExampleProject.Domain.Enums;
using ExampleProject.Domain.ValueObjects;

namespace ExampleProject.Domain.Entities
{
    public class Car : AuditableEntity, IHasDomainEvent
    {
        private int _marketPrice;
        private int _dailyRentPrice;
        public int Id { get; set; }
        public IList<Accessory> Accessories { get; set; } = new List<Accessory>();
        
        [NotMapped]
        public string CarTypeName { get; set; }
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
            set => _marketPrice = value;
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
            set => _dailyRentPrice = value;
        }
        public bool IsAvailable { get; set; }
        public CarType Type { get; set; }

        public string CarColor { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
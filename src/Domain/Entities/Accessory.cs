using System.Collections;
using System.Collections.Generic;

namespace ExampleProject.Domain.Entities
{
    public class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarketPrice { get; set; }
        public int RentPrice { get; set; }
        public IList<Car> Cars { get; set; } = new List<Car>();
    }
}
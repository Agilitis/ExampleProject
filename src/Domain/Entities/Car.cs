using System.Collections.Generic;
using System.Linq;
using ExampleProject.Domain.Common;
using ExampleProject.Domain.Enums;

namespace ExampleProject.Domain.Entities
{
    public class Car : AuditableEntity
    {
        private readonly int _price;
        public int Id { get; set; }
        public IList<Extra> Extras { get; set; }
        public int Price
        {
            get
            {
                return _price + Extras.Sum(extra => extra.Price);
            }
            init => _price = value;
        }
        public CarType Type { get; set; }
    }
}
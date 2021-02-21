using ExampleProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Domain.Entities
{
    public class Service : AuditableEntity
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public IEnumerable<CarPart> CarPartsToReplace { get; set; }
        public ServicePartner ServicePartner { get; set; }
        public int ServicePartnerId { get; set; }
        public int TotalFee { 
            get
            {
                var sum = 0;
                foreach(var carPart in CarPartsToReplace)
                {
                    sum += carPart.Price;
                }
                sum += ServicePartner.ServiceFee;
                return sum;
            }
        }
    }
    
}

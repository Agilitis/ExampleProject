using ExampleProject.Domain.Common;

namespace ExampleProject.Domain.Entities
{
    public class ServicePartner : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceFee { get; set; }
        public string Address { get; set; }
    }
}
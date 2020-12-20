using ExampleProject.Domain.Common;

namespace ExampleProject.Domain.Entities
{
    public class Rent : AuditableEntity
    {
        public int Id { get; set; }
    }
}
using System;
using ExampleProject.Domain.Common;

namespace ExampleProject.Domain.Entities
{
    public class Rent : AuditableEntity
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public int RentLength { get; set; }
        public string UserId { get; set; }
        public int RentPrice => Car.DailyRentPrice * RentLength;
    }
}
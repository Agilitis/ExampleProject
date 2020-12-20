using System;
using ExampleProject.Domain.Common;

namespace ExampleProject.Domain.Entities
{
    public class Rent : AuditableEntity
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan RentLength { get; set; }
        public int RentPrice => Car.DailyRentPrice * RentLength.Days;
    }
}
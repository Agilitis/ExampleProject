using ExampleProject.Application.Common.Interfaces;
using System;

namespace ExampleProject.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

using ExampleProject.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleProject.Application.Car.Commands
{
    public class CreateCarCommand : IRequest<int>
    {
        public string Car { get; set; }
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateCarCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                
            }
        }
    }
}

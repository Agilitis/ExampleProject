using System;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.Rent.Commands.CreateRent
{
    public class CreateRentCommand : IRequest<int>
    {
        public int CarId { get; set; }
        public int RentLengthInDays { get; set; }
        public DateTime StartDate { get; set; }
    }
    
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            var car = await _context.Cars.FindAsync(request.CarId);
            var rent = new Domain.Entities.Rent
            {
                Car = car,
                RentLength = TimeSpan.FromDays(request.RentLengthInDays),
                StartDate = request.StartDate
            };

            _context.Rents.Add(rent);

            await _context.SaveChangesAsync(cancellationToken);

            return rent.Id;
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.Rent.Commands.UpdateRent
{
    public class UpdateRentCommand : IRequest<Unit>
    {
        public int RentId { get; set; }
        public int RentLengthInDays { get; set; }
        public DateTime StartDate { get; set; }
    }
    
    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public async Task<Unit> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rents.FindAsync(request.RentId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            entity.RentLengthInDays = request.RentLengthInDays;
            entity.StartDate = request.StartDate;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
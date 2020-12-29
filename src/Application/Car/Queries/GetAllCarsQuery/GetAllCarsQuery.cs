using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Application.Car.Queries.GetAllCarsQuery
{
    public class GetAllCarsQuery : IRequest<IEnumerable<Domain.Entities.Car>>
    {
        
    }

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Domain.Entities.Car>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCarsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cars
                .Include(x => x.Accessories)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
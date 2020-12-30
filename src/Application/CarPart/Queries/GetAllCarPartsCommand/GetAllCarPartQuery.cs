using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Application.CarPart.Queries.GetAllCarPartsCommand
{
    public class GetAllCarPartQuery : IRequest<IEnumerable<Domain.Entities.CarPart>>
    {
        
    }
    
    public class GetAllCarPartQueryHandler : IRequestHandler<GetAllCarPartQuery, IEnumerable<Domain.Entities.CarPart>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCarPartQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.CarPart>> Handle(GetAllCarPartQuery request, CancellationToken cancellationToken)
        {
            return _context.CarParts
                .AsNoTracking();
        }
    }
}
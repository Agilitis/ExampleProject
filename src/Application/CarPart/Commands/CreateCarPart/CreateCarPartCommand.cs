using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ExampleProject.Application.CarPart.Commands.CreateCarPart
{
    public class CreateCarPartCommand : IRequest<int>
    {
        
    }
    
    public class CreateCarPartCommandHandler : IRequestHandler<CreateCarPartCommand, int>
    {
        public Task<int> Handle(CreateCarPartCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
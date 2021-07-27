using MediatR;
using MicroservicesGrpcExample.Platform.Books.Contracts.Commands.CreateBook;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Commands
{
    public class CreateBookCommand : IRequest<CreateBookCommandResponse>
    {
        
    }
}
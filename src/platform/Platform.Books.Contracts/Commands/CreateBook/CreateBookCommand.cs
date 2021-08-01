using MediatR;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Commands
{
    public class CreateBookCommand : IRequest<CreateBookCommandResponse>
    {
    }
}
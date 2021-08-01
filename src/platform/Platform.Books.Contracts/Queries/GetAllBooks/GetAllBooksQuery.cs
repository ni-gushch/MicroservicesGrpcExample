using MediatR;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Queries
{
    public class GetAllBooksQuery : IRequest<GetAllBooksQueryResponse>
    {
    }
}
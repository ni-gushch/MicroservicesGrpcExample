using MediatR;
using MicroservicesGrpcExample.Platform.Books.Contracts.Models;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Queries
{
    public class GetBookByIdQuery : IntIdModel, IRequest<GetBookByIdQueryResponse>
    {
        
    }
}
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroservicesGrpcExample.Platform.Books.BusinessLogic.Base;
using MicroservicesGrpcExample.Platform.Books.Contracts.Queries;
using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;

namespace MicroservicesGrpcExample.Platform.Books.BusinessLogic.Handlers
{
    public class GetAllBooksQueryHandler : BaseHandler<GetAllBooksQuery, GetAllBooksQueryResponse, IBookRepository>
    {
        protected GetAllBooksQueryHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<GetAllBooksQueryResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetAllAsync(cancellationToken);
            return Mapper.Map<GetAllBooksQueryResponse>(result);
        }
    }
}
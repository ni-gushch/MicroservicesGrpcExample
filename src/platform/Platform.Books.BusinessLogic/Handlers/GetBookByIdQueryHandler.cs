using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroservicesGrpcExample.Platform.Books.BusinessLogic.Base;
using MicroservicesGrpcExample.Platform.Books.Contracts.Queries;
using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;

namespace MicroservicesGrpcExample.Platform.Books.BusinessLogic.Handlers
{
    public class GetBookByIdQueryHandler : BaseHandler<GetBookByIdQuery, GetBookByIdQueryResponse, IBookRepository>
    {
        protected GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<GetBookByIdQueryResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetByIdAsync(request.Id, cancellationToken);
            return Mapper.Map<GetBookByIdQueryResponse>(result);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroservicesGrpcExample.Platform.Books.BusinessLogic.Base;
using MicroservicesGrpcExample.Platform.Books.Contracts.Commands;
using MicroservicesGrpcExample.Platform.Books.Contracts.Commands.DeleteBook;
using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;

namespace MicroservicesGrpcExample.Platform.Books.BusinessLogic.Handlers
{
    public class DeleteBookCommandHandler : BaseHandler<DeleteBooksCommand, DeleteBooksCommandResponse, IBookRepository>
    {
        protected DeleteBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<DeleteBooksCommandResponse> Handle(DeleteBooksCommand request,
            CancellationToken cancellationToken)
        {
            var result = await Repository.DeleteAsync(request., cancellationToken);
            return Mapper.Map<DeleteBooksCommandResponse>(result);
        }
    }
}
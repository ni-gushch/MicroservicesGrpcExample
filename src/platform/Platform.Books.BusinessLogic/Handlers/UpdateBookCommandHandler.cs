using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroservicesGrpcExample.Platform.Books.BusinessLogic.Base;
using MicroservicesGrpcExample.Platform.Books.Contracts.Commands;
using MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities;
using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;

namespace MicroservicesGrpcExample.Platform.Books.BusinessLogic.Handlers
{
    public class UpdateBookCommandHandler : BaseHandler<UpdateBookCommand, UpdateBookCommandResponse, IBookRepository>
    {
        protected UpdateBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<UpdateBookCommandResponse> Handle(UpdateBookCommand request,
            CancellationToken cancellationToken)
        {
            var updateBookEntity = Mapper.Map<Book>(request);
            var result = await Repository.UpdateAsync(updateBookEntity, cancellationToken);
            return Mapper.Map<UpdateBookCommandResponse>(result);
        }
    }
}
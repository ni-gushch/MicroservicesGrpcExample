using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroservicesGrpcExample.Platform.Books.BusinessLogic.Base;
using MicroservicesGrpcExample.Platform.Books.Contracts.Commands;
using MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities;
using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;

namespace MicroservicesGrpcExample.Platform.Books.BusinessLogic.Handlers
{
    public class CreateBookCommandHandler : BaseHandler<CreateBookCommand, CreateBookCommandResponse, IBookRepository>
    {
        public CreateBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = Mapper.Map<Book>(request);
            var result = await Repository.CreateAsync(bookEntity, cancellationToken);
            return Mapper.Map<CreateBookCommandResponse>(result);
        }
    }
}
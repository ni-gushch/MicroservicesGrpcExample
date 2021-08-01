using MediatR;
using MicroservicesGrpcExample.Platform.Books.Contracts.Models;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Commands.DeleteBook
{
    public class DeleteBooksCommand : IIdModel<int>, IRequest<DeleteBooksCommandResponse>
    {
        /// <summary>
        ///     Book identifier fot delete
        /// </summary>
        public int Id { get; set; }
    }
}
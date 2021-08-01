using MediatR;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Commands.DeleteBook
{
    public class DeleteBooksCommand : IRequest<DeleteBooksCommandResponse>
    {
        /// <summary>
        ///     Book identifier fot delete
        /// </summary>
        public int Id { get; set; }
    }
}
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Repositories
{
    /// <summary>
    /// Book repository contracts
    /// </summary>
    public interface IBookRepository
    {
        Task<List<Book>> GetAll(CancellationToken cancellationToken = default);

        Task<Book> GetById(int bookId, CancellationToken cancellationToken = default);

        Task<List<Book>> GetByTitle(string title, CancellationToken cancellationToken = default);

        Task<int> Create(Book book, CancellationToken cancellationToken = default);

        Task<bool> Update(Book bookToUpdate, CancellationToken cancellationToken = default);

        Task<bool> Delete(Book bookToDelete, CancellationToken cancellationToken = default);

        Task<bool> Delete(int bookIdToDelete, CancellationToken cancellationToken = default);
    }
}
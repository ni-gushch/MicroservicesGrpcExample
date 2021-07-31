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
        Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Book> GetByIdAsync(int bookId, CancellationToken cancellationToken = default);

        Task<List<Book>> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

        Task<int> CreateAsync(Book book, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(Book bookToUpdate, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Book bookToDelete, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(int bookIdToDelete, CancellationToken cancellationToken = default);
    }
}
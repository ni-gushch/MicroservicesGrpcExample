using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities;
using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;
using MicroservicesGrpcExample.Platform.Books.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace MicroservicesGrpcExample.Platform.Books.DataAccess
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly IIncludableQueryable<Book, Author> _dbSetNoTrackingIncludeAuthors;
        private readonly IMapper _mapper;
        
        public BookRepository(BookLibraryDbContext dbContext,
            IMapper mapper) : base(dbContext)
        {
            _dbSetNoTrackingIncludeAuthors = DbSetNoTracking
                .Include(it => it.Author);
            _mapper = mapper;
        }

        public Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _dbSetNoTrackingIncludeAuthors
                .ToListAsync(cancellationToken);
        }

        public Task<Book> GetByIdAsync(int bookId, CancellationToken cancellationToken = default)
        {
            return _dbSetNoTrackingIncludeAuthors
                .FirstOrDefaultAsync(it => it.Id.Equals(bookId), cancellationToken);
        }

        public Task<List<Book>> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return _dbSetNoTrackingIncludeAuthors
                .Where(it => EF.Functions.Like(it.Title, $"%{title}%"))
                .ToListAsync(cancellationToken);
        }

        public async Task<int> CreateAsync(Book book, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.AddAsync(book, cancellationToken);
            var saveStatus = BookLibraryContext.SaveChangesAsync(cancellationToken);
            return entity.Entity.Id;
        }

        public async Task<bool> UpdateAsync(Book bookToUpdate, CancellationToken cancellationToken = default)
        {
            var entityInDb = await DbSet.FirstOrDefaultAsync(it => it.Id.Equals(bookToUpdate.Id),
                cancellationToken);
            if (entityInDb == null)
                throw new Exception($"Book with id {bookToUpdate.Id} not found in store");
            entityInDb = _mapper.Map(bookToUpdate, entityInDb);
            var saveStatus = await BookLibraryContext.SaveChangesAsync(cancellationToken);
            return saveStatus > 0;
        }
        
        public async Task<bool> DeleteAsync(Book bookToDelete, CancellationToken cancellationToken = default)
        {
            var entityInDb = await DbSet.FirstOrDefaultAsync(it => it.Id.Equals(bookToDelete.Id),
                cancellationToken);
            if (entityInDb == null)
                throw new Exception($"Book with id {bookToDelete.Id} not found in store");
            DbSet.Remove(entityInDb);
            var saveStatus = await BookLibraryContext.SaveChangesAsync(cancellationToken);
            return saveStatus > 0;
        }
        
        public async Task<bool> DeleteAsync(int bookIdToDelete, CancellationToken cancellationToken = default)
        {
            var entityInDb = await DbSet.FirstOrDefaultAsync(it => it.Id.Equals(bookIdToDelete),
                cancellationToken);
            if (entityInDb == null)
                throw new Exception($"Book with id {bookIdToDelete} not found in store");
            DbSet.Remove(entityInDb);
            var saveStatus = await BookLibraryContext.SaveChangesAsync(cancellationToken);
            return saveStatus > 0;
        }
    }
}
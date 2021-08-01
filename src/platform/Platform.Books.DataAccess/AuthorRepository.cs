using System;
using System.Collections.Generic;
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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly IIncludableQueryable<Author, List<Book>> _dbSetNoTrackingIncludeBooks;
        private readonly IMapper _mapper;

        public AuthorRepository(BookLibraryDbContext dbContext,
            IMapper mapper) : base(dbContext)
        {
            _dbSetNoTrackingIncludeBooks = DbSetNoTracking
                .Include(it => it.Books);
            _mapper = mapper;
        }

        public Task<List<Author>> GetAll(CancellationToken cancellationToken = default)
        {
            return _dbSetNoTrackingIncludeBooks
                .ToListAsync(cancellationToken);
        }

        public Task<Author> GetById(int authorId, CancellationToken cancellationToken = default)
        {
            return _dbSetNoTrackingIncludeBooks
                .FirstOrDefaultAsync(it => it.Id.Equals(authorId), cancellationToken);
        }

        public async Task<int> Create(Author author, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.AddAsync(author, cancellationToken);
            var saveStatus = BookLibraryContext.SaveChangesAsync(cancellationToken);
            return entity.Entity.Id;
        }

        public async Task<bool> Update(Author authorToUpdate, CancellationToken cancellationToken = default)
        {
            var entityInDb = await DbSet.FirstOrDefaultAsync(it => it.Id.Equals(authorToUpdate.Id),
                cancellationToken);
            if (entityInDb == null)
                throw new Exception($"Author with id {authorToUpdate.Id} not found in store");
            entityInDb = _mapper.Map(authorToUpdate, entityInDb);
            var saveStatus = await BookLibraryContext.SaveChangesAsync(cancellationToken);
            return saveStatus > 0;
        }

        public async Task<bool> Delete(Author authorToDelete, CancellationToken cancellationToken = default)
        {
            var entityInDb = await DbSet.FirstOrDefaultAsync(it => it.Id.Equals(authorToDelete.Id),
                cancellationToken);
            if (entityInDb == null)
                throw new Exception($"Author with id {authorToDelete.Id} not found in store");
            DbSet.Remove(entityInDb);
            var saveStatus = await BookLibraryContext.SaveChangesAsync(cancellationToken);
            return saveStatus > 0;
        }

        public async Task<bool> Delete(int authorIdToDelete, CancellationToken cancellationToken = default)
        {
            var entityInDb = await DbSet.FirstOrDefaultAsync(it => it.Id.Equals(authorIdToDelete),
                cancellationToken);
            if (entityInDb == null)
                throw new Exception($"Author with id {authorIdToDelete} not found in store");
            DbSet.Remove(entityInDb);
            var saveStatus = await BookLibraryContext.SaveChangesAsync(cancellationToken);
            return saveStatus > 0;
        }
    }
}
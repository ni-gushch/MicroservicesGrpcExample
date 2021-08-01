using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MicroservicesGrpcExample.Platform.Books.BusinessLogic.Base
{
    public class BaseHandler<TRequest, TResponse, TRepository> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
        where TRepository : class
    {
        protected readonly IMapper Mapper;
        protected readonly TRepository Repository;

        protected BaseHandler(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
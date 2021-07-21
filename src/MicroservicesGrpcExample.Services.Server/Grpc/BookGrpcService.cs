using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MicroservicesGrpcExample.Services.Server.Protos;

namespace MicroservicesGrpcExample.Server.Grpc
{
    public class BookGrpcService : BookStore.BookStoreBase
    {
        public override Task<Empty> GetAll(Empty request, ServerCallContext context)
        {
        }
    }
}
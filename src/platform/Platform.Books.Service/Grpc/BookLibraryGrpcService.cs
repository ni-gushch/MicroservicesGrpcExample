using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace MicroservicesGrpcExample.Server.Grpc
{
    public class BookLibraryGrpcService //: BookLibrary.BookLibraryBase
    {
        public /*override*/ Task<Empty> GetAll(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new Empty());
        }
    }
}
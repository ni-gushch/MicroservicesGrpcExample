using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace MicroservicesGrpcExample.Client.Controllers
{
    /// <summary>
    /// Controller for manage books
    /// </summary>
    [ApiController]
    [Route("/api/[controller]")]
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/> instance</param>
        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger ?? NullLogger<BooksController>.Instance;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public string GetAll()
        {
            return "Hello";
        }
    }
}
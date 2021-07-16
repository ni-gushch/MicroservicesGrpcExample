using Microsoft.AspNetCore.Mvc;

namespace MicroservicesGrpcExample.Client.Controllers
{
    [ApiController]
    public class BooksController : Controller
    {
        public BooksController()
        {
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
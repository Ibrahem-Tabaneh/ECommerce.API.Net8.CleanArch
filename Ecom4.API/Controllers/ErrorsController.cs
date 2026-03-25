using Ecom4.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpGet("{code}")]
        public IActionResult Error(int code)
        {
             return StatusCode(code, new ApiResponse
             {
                 statuscode = code,
                 message = "An error occurred.",
                 data = null
             });
        }
    }
}

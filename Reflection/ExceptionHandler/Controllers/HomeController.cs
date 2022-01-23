using ExceptionHandler.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("api/Home/Test")]
        public Task<bool> Test()
        {
            throw new NewException();
            return Task.FromResult(true);
        }
    }
}

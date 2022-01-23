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
            throw new Exception("this is test error");
            return Task.FromResult(true);
        }
    }
}

using CoreChannels.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace CoreChannels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("api/Home/Send")]
        public IActionResult Send()
        {
            Task.Run(() =>
            {
                Task.Delay(100).Wait();

                Task.Delay(200).Wait();
            });

            return Ok();
        }

        [HttpGet]
        [Route("api/Home/SendB")]
        public Task<bool> SendB([FromServices] Notifications notifications)
        {
            return notifications.Send();
        }

        [HttpGet]
        [Route("api/Home/SendA")]
        public bool SendA([FromServices] Notifications notifications)
        {
            return notifications.SendA();
        }

        [HttpGet]
        [Route("api/Home/SendC")]
        public async Task<bool> SendC([FromServices] Channel<string> channel)
        {
            await channel.Writer.WriteAsync("Hello");
            return true;
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        [HttpGet]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound Request Received");

            return Ok("Inbound Connection Request");
        }
    }
}
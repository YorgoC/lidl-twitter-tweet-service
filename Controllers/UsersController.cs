using System;
using Microsoft.AspNetCore.Mvc;

namespace lidl_twitter_tweet_service.Controllers
{
    [Route("api/t/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Tweet Service");
            return Ok("Inbound test from Tweet Service");
        }
        
    }
}
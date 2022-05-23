using System;
using AutoMapper;
using lidl_twitter_tweet_service.Data;
using Microsoft.AspNetCore.Mvc;

namespace lidl_twitter_tweet_service.Controllers
{
    [Route("api/t/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILidlTweetRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(ILidlTweetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Tweet Service");
            return Ok("Inbound test from Tweet Service");
        }
        
    }
}
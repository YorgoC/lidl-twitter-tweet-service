using System;
using System.Collections.Generic;
using AutoMapper;
using lidl_twitter_tweet_service.Data;
using lidl_twitter_tweet_service.DTOs;
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

        [HttpGet]
        public ActionResult<IEnumerable<ReadUser>> GetUsers()
        {
            Console.WriteLine("--> Getting Users from LidlTweetService");

            var userItems = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<ReadUser>>(userItems));
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Tweet Service");
            return Ok("Inbound test from Tweet Service");
        }
        
    }
}
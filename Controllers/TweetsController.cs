using System;
using System.Collections.Generic;
using AutoMapper;
using lidl_twitter_tweet_service.Data;
using lidl_twitter_tweet_service.DTOs;
using lidl_twitter_tweet_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace lidl_twitter_tweet_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILidlTweetRepo _repository;

        public TweetsController(ILidlTweetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("gettweets", Name = "GetLidlTweetsForUser")]
        public ActionResult<IEnumerable<ReadLidlTweet>> GetLidlTweetsForUser(string auth0Id)
        {
            Console.WriteLine($"--> Hit GetLidlTweetsForUser: {auth0Id}");

            if (!_repository.UserExists(auth0Id))
            {
                return NotFound();
            }

            var lidlTweets = _repository.GetLidlTweetsForUser(auth0Id);

            return Ok(_mapper.Map<IEnumerable<ReadLidlTweet>>(lidlTweets));
        }

        [HttpGet("{lidlTweetId}", Name = "GetLidlTweet")]
        public ActionResult<ReadLidlTweet> GetLidlTweet(int lidlTweetId)
        {
            
            Console.WriteLine($"--> Hit GetLidlTweetsForUser: {lidlTweetId}");
            
            var lidlTweet = _repository.GetLidlTweet(lidlTweetId);

            if (lidlTweet == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ReadLidlTweet>(lidlTweet));
        }

        [HttpPost("tweet", Name = "Tweet")]
        public ActionResult<ReadLidlTweet> CreateLidlTweet(CreateLidlTweet createLidlTweet)
        {
            Console.WriteLine($"--> CreateLidlTweet: {createLidlTweet.Auth0Id}");

            if (!_repository.UserExists(createLidlTweet.Auth0Id))
            {
                return NotFound();
            }

            var user = _repository.GetUserByAuth0Id(createLidlTweet.Auth0Id);
            
            var lidlTweet = _mapper.Map<LidlTweet>(createLidlTweet);
            
            _repository.CreateLidlTweet(user.Id, lidlTweet);
            _repository.SaveChanges();

            var readLidlTweet = _mapper.Map<ReadLidlTweet>(lidlTweet);
            
            return CreatedAtRoute(nameof(GetLidlTweet),
                new {userId = user.Id, id = readLidlTweet.Id}, readLidlTweet);
        }

    }
}
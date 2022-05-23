using System;
using System.Collections.Generic;
using AutoMapper;
using lidl_twitter_tweet_service.Data;
using lidl_twitter_tweet_service.DTOs;
using lidl_twitter_tweet_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace lidl_twitter_tweet_service.Controllers
{
    [Route("api/t/users/{userId}/[controller]")]
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

        [HttpGet]
        public ActionResult<IEnumerable<ReadLidlTweet>> GetLidlTweetsForUser(int userId)
        {
            Console.WriteLine($"--> Hit GetLidlTweetsForUser: {userId}");

            if (!_repository.UserExists(userId))
            {
                return NotFound();
            }

            var lidlTweets = _repository.GetLidlTweetsForUser(userId);

            return Ok(_mapper.Map<IEnumerable<ReadLidlTweet>>(lidlTweets));
        }

        [HttpGet("{lidlTweetId}", Name = "GetLidlTweet")]
        public ActionResult<ReadLidlTweet> GetLidlTweet(int userId, int lidlTweetId)
        {
            
            Console.WriteLine($"--> Hit GetLidlTweetsForUser: {userId} / {lidlTweetId}");
            
            if (!_repository.UserExists(userId))
            {
                return NotFound();
            }

            var lidlTweet = _repository.GetLidlTweet(userId, lidlTweetId);

            if (lidlTweet == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ReadLidlTweet>(lidlTweet));
        }

        [HttpPost]
        public ActionResult<ReadLidlTweet> CreateLidlTweet(int userId, CreateLidlTweet createLidlTweet)
        {
            Console.WriteLine($"--> CreateLidlTweet: {userId}");
            
            if (!_repository.UserExists(userId))
            {
                return NotFound();
            }

            var lidlTweet = _mapper.Map<LidlTweet>(createLidlTweet);
            
            _repository.CreateLidlTweet(userId, lidlTweet);
            _repository.SaveChanges();

            var readLidlTweet = _mapper.Map<ReadLidlTweet>(lidlTweet);
            
            return CreatedAtRoute(nameof(GetLidlTweet),
                new {userId = userId, id = readLidlTweet.Id}, readLidlTweet);
        }

    }
}
using AutoMapper;
using lidl_twitter_tweet_service.DTOs;
using lidl_twitter_tweet_service.Models;

namespace lidl_twitter_tweet_service.Profiles
{
    public class LidlTweetProfile : Profile
    {
        public LidlTweetProfile()
        {
            // Source -> Target
            CreateMap<User, ReadUser>();
            CreateMap<CreateLidlTweet, LidlTweet>();
            CreateMap<LidlTweet, ReadLidlTweet>();
        }
    }
}
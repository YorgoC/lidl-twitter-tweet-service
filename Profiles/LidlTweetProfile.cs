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
            CreateMap<LidlTweet, ReadLidlTweet>()
                .ForMember(dest => dest.MentionName,
                    opt => opt.MapFrom(src => src.User.MentionName))
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.ProfilePicture,
                    opt => opt.MapFrom(src => src.User.ProfilePicture));
            CreateMap<PublishedUser, User>()
                .ForMember(dest => dest.ExternalId,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
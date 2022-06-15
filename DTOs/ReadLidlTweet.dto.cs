using System;
using lidl_twitter_tweet_service.Models;

namespace lidl_twitter_tweet_service.DTOs
{
    public class ReadLidlTweet
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string MentionName { get; set; }
        
        public string ProfilePicture { get; set; }

        public string Text { get; set; }
        
        public int Likes { get; set; }
        
        public int Retweets { get; set; }
        
        public int Comments { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
using System;
using lidl_twitter_tweet_service.Models;

namespace lidl_twitter_tweet_service.DTOs
{
    public class ReadLidlTweet
    {

        //for retweeting purposes
        public User User { get; set; }
        
        public string Text { get; set; }
        
        public int Likes { get; set; }
        
        public int Retweets { get; set; }
        
        public int Comments { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
using System;

namespace lidl_twitter_tweet_service.DTOs
{
    public class CreateLidlTweet
    {           
        public int UserId { get; set; }
        
        //for retweet purposes
        public int AuthorId { get; set; }

        public string Text { get; set; }
        
        public int Likes { get; set; }
        
        public int Retweets { get; set; }
        
        public int Comments { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
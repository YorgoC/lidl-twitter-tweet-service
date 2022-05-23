using System;
using System.ComponentModel.DataAnnotations;

namespace lidl_twitter_tweet_service.DTOs
{
    public class CreateLidlTweet
    {
        [Required]
        public string Text { get; set; }
        
        [Required]
        public DateTime CreationTime { get; set; }
    }
}
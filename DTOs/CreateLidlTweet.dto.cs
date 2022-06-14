using System;
using System.ComponentModel.DataAnnotations;

namespace lidl_twitter_tweet_service.DTOs
{
    public class CreateLidlTweet
    {
        
        [Required]
        public int ExternalId { get; set; }
        
        [Required]
        public string Text { get; set; }
        
    }
}
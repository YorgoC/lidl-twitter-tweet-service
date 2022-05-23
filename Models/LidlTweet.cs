using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lidl_twitter_tweet_service.Models
{
    public class LidlTweet
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        [Required]
        public User User { get; set; }

        [Required]
        public string Text { get; set; }
        
        public int Likes { get; set; }
        
        public int Retweets { get; set; }
        
        public int Comments { get; set; }

        public DateTime CreationTime { get; set; }
        
      //  public ICollection<User> Retweeters { get; set; }


    }
}
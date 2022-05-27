using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lidl_twitter_tweet_service.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int ExternalId { get; set; }
        
        public string ProfilePicture { get; set; }

        [Required]
        public string UserName { get; set; }
        
        public string MentionName { get; set; }
        
        public ICollection<LidlTweet> Tweets { get; set; }
        
        //for retweet purposes
        // public int TweetID { get; set; }
    }
}
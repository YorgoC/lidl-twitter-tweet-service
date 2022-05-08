using System.ComponentModel.DataAnnotations;

namespace lidl_twitter_tweet_service.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
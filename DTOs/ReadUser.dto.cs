namespace lidl_twitter_tweet_service.DTOs
{
    public class ReadUser
    {
        public int Id { get; set; }
        
        public string Auth0Id { get; set; }

        public string ProfilePicture { get; set; }

        public string UserName { get; set; }
        
        public string MentionName { get; set; }
    }
}
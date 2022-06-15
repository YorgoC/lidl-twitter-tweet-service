using System.Collections.Generic;
using lidl_twitter_tweet_service.Models;

namespace lidl_twitter_tweet_service.Data
{
    public interface ILidlTweetRepo
    {
        bool SaveChanges();

        //Users
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        bool UserExists(string auth0Id);
        bool ExternalUserExists(int externalUserId);

        User GetUserByExternalId(int externalUserId);
        
        User GetUserByAuth0Id(string auth0Id);
        
        //Lidl Tweets
        IEnumerable<LidlTweet> GetLidlTweetsForUser(string auth0Id);
        LidlTweet GetLidlTweet(int lidlTweetId);
        void CreateLidlTweet(int userId, LidlTweet lidlTweet);
    }
}
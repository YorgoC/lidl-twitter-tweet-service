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
        bool UserExists(int userId);
        bool ExternalUserExists(int externalUserId);

        User GetUserByExternalId(int externalUserId);
        //Lidl Tweets
        IEnumerable<LidlTweet> GetLidlTweetsForUser(int userId);
        LidlTweet GetLidlTweet(int userId, int lidlTweetId);
        void CreateLidlTweet(int userId, LidlTweet lidlTweet);
    }
}
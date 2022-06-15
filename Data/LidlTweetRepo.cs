using System;
using System.Collections.Generic;
using System.Linq;
using lidl_twitter_tweet_service.Models;

namespace lidl_twitter_tweet_service.Data
{
    public class LidlTweetRepo : ILidlTweetRepo
    {
        private readonly AppDbContext _context;

        public LidlTweetRepo(AppDbContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public bool UserExists(string auth0Id)
        {
            return _context.Users.Any(p => p.Auth0Id == auth0Id);
        }

        public bool ExternalUserExists(int externalUserId)
        {
            return _context.Users.Any(p => p.ExternalId == externalUserId);
        }
        public User GetUserByExternalId(int externalUserId)
        {
            return _context.Users
                .FirstOrDefault(p => p.ExternalId == externalUserId);
        }

        public User GetUserByAuth0Id(string auth0Id)
        {
            return _context.Users
                .FirstOrDefault(p => p.Auth0Id == auth0Id);
        }

        public IEnumerable<LidlTweet> GetLidlTweetsForUser(string auth0Id)
        {
            return _context.Tweets
                .Where(c => c.UserId == GetUserByAuth0Id(auth0Id).Id)
                .OrderBy(c => c.CreationTime);
        }

        public LidlTweet GetLidlTweet(int lidlTweetId)
        {
            return _context.Tweets.FirstOrDefault(c => c.Id == lidlTweetId);
        }

        public void CreateLidlTweet(int userId, LidlTweet lidlTweet)
        {
            if (lidlTweet == null)
            {
                throw new ArgumentNullException(nameof(lidlTweet));
            }

            lidlTweet.UserId = userId;
            _context.Tweets.Add(lidlTweet);
        }
    }
}
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

        public bool UserExists(int userId)
        {
            return _context.Users.Any(p => p.Id == userId);
        }

        public bool ExternalUserExists(int externalUserId)
        {
            return _context.Users.Any(p => p.ExternalId == externalUserId);
        }

        public IEnumerable<LidlTweet> GetLidlTweetsForUser(int userId)
        {
            return _context.Tweets
                .Where(c => c.UserId == userId)
                .OrderBy(c => c.CreationTime);
        }

        public LidlTweet GetLidlTweet(int userId, int lidlTweetId)
        {
            return _context.Tweets
                .Where(c => c.UserId == userId && c.Id == lidlTweetId).FirstOrDefault();
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
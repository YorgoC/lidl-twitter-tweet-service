using System;
using System.Text.Json;
using AutoMapper;
using lidl_twitter_tweet_service.Data;
using lidl_twitter_tweet_service.DTOs;
using lidl_twitter_tweet_service.Models;
using Microsoft.Extensions.DependencyInjection;

namespace lidl_twitter_tweet_service.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory,
            IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.UserPublished:
                    //TODO
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");
            var eventType = JsonSerializer.Deserialize<GenericEvent>(notificationMessage);

            switch (eventType.Event)
            {
                case "User_Published":
                    Console.WriteLine("User Published Event Detected");
                    return EventType.UserPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addUser(string PublishedUserMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ILidlTweetRepo>();

                var publishedUser = JsonSerializer.Deserialize<PublishedUser>(PublishedUserMessage);

                try
                {
                    var user = _mapper.Map<User>(publishedUser);
                    if (!repo.ExternalUserExists(user.ExternalId))
                    {
                        repo.CreateUser(user);
                        repo.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("--> User already exists...");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"--> Could not add User to DB {e.Message}");
                }
            }
        }
    }
}
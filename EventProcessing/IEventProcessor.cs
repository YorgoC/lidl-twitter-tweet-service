namespace lidl_twitter_tweet_service.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
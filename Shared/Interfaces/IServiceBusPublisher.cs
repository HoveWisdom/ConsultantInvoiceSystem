namespace Shared.Interfaces;

public interface IServiceBusPublisher
{
    Task PublishAsync<T>(T message, string topicName) where T : class;
}
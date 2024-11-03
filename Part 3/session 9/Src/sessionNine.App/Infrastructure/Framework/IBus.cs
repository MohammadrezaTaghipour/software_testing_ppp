namespace sessionNine.App.Infrastructure.Framework;

public interface IBus
{
    void Send(string message);
}

public class RabbitmqBus //(RabbitMqClient client) 
    : IBus
{
    public void Send(string message)
    {
        //TODO: call rabbit-mq client to publish message
    }
}
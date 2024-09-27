using Contracts;
using MassTransit;

namespace Work;

public class MessageConsumer : IConsumer<ContactMessage>
{
    public readonly ILogger<MessageConsumer> _logger;

    public MessageConsumer(ILogger<MessageConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ContactMessage> context)
    {
        _logger.LogInformation("Received Text", context.Message);

        return Task.CompletedTask;
    }
}
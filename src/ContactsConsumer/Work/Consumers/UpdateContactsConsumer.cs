using Contracts;
using MassTransit;

namespace Work.Consumers
{
    public class UpdateContactsConsumer : IConsumer<ContactUpdateMessage>
    {
        public readonly ILogger<UpdateContactsConsumer> _logger;

        public UpdateContactsConsumer(ILogger<UpdateContactsConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ContactUpdateMessage> context)
        {
            _logger.LogInformation($"Received contact Update: {context.Message}");

            return Task.CompletedTask;
        }
    }
}
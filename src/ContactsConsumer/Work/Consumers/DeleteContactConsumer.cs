
using Contracts;
using MassTransit;

namespace Work.Consumers
{
    public class DeleteContactConsumer : IConsumer<DeleteContactMessage>
    {
        public readonly ILogger _logger;

        public DeleteContactConsumer(ILogger logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<DeleteContactMessage> context)
        {
            _logger.LogInformation($"Received contact delete: {context.Message}");

            return Task.CompletedTask;
        }
    }
}

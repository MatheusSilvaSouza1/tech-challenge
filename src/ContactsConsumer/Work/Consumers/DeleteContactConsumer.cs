
using Application.Services;
using Contracts;
using MassTransit;

namespace Work.Consumers
{
    public class DeleteContactConsumer : IConsumer<DeleteContactMessage>
    {
        public readonly IContactServices _contactService;
        public readonly ILogger<DeleteContactConsumer> _logger;

        public DeleteContactConsumer(ILogger<DeleteContactConsumer> logger, IContactServices contactServices)
        {
            _contactService = contactServices;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DeleteContactMessage> context)
        {
            _logger.LogInformation($"Received contact Update: {context.MessageId}");

            await _contactService.DeleteContact(context.Message.ContactId);

            _logger.LogInformation("Deleted Contact", context.MessageId);
        }
    }
}

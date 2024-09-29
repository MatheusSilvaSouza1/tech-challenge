using Application.Services;
using Contracts;
using Domain.DTOs;
using MassTransit;

namespace Work.Consumers
{
    public class UpdateContactsConsumer : IConsumer<ContactUpdateMessage>
    {
        public readonly IContactServices _contactService;
        public readonly ILogger<UpdateContactsConsumer> _logger;

        public UpdateContactsConsumer(ILogger<UpdateContactsConsumer> logger, IContactServices contactServices)
        {
            _contactService = contactServices;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ContactUpdateMessage> context)
        {
            _logger.LogInformation($"Received contact Update: {context.MessageId}");

            await _contactService.UpdateContact(new ContactUpdateDTO()
            {
                Id = context.Message.Id,
                Email = context.Message.Email,
                Name = context.Message.Name,
                Phone = context.Message.Phone
            });

            _logger.LogInformation("Updated Contact", context.MessageId);
        }
    }
}
using Application.Services;
using Contracts;
using MassTransit;
using Domain.DTOs;

namespace Work.Consumers;

public class MessageConsumer : IConsumer<ContactMessage>
{
    public readonly IContactServices _contactService;
    public readonly ILogger<MessageConsumer> _logger;

    public MessageConsumer(ILogger<MessageConsumer> logger, IContactServices contactServices)
    {
        _contactService = contactServices;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ContactMessage> context)
    {
        _logger.LogInformation("Received Text", context.Message);

        await _contactService.CreateContact(new ContactDTO()
        {
            Email = context.Message.Email,
            Name = context.Message.Name,
            Phone = context.Message.Phone
        });

        _logger.LogInformation("Saved Contact", context.Message);
    }
}
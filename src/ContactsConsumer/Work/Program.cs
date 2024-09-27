using Work;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);

var configuring = builder.Configuration;

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>();

    x.UsingRabbitMq((context, config) =>
    {
        var host = configuring.GetRequiredSection("MessageHost:Host").Value ?? throw new ArgumentException();
        config.Host(new Uri(host), e =>
        {
            e.Username(configuring.GetRequiredSection("MessageHost:User").Value!);
            e.Password(configuring.GetRequiredSection("MessageHost:Pass").Value!);
        });

        config.ConfigureEndpoints(context);
    });
});

var host = builder.Build();

host.Run();

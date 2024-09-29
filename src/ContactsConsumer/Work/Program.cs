using Application.Services;
using Domain.Repositories;
using Infra;
using Infra.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Work.Consumers;

var builder = Host.CreateApplicationBuilder(args);

var configuring = builder.Configuration;

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactServices, ContactServices>();
builder.Services.AddDbContext<Context>(options =>
 {
     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
     options.EnableSensitiveDataLogging();
 });


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>();
    x.AddConsumer<UpdateContactsConsumer>();
    x.AddConsumer<DeleteContactConsumer>();

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

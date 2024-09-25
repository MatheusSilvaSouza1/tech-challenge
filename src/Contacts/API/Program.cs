using Prometheus;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//!
// builder.Services.AddScoped<IContactServices, ContactServices>();
// builder.Services.AddScoped<IContactRepository, ContactRepository>();
// builder.Services.AddDbContext<Context>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
//     options.EnableSensitiveDataLogging();
// });
var configuring = builder.Configuration;

builder.Services.AddMassTransit(builder =>
{
    builder.SetKebabCaseEndpointNameFormatter();

    builder.UsingRabbitMq((context, config) =>
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

var app = builder.Build();

//!
// using var scope = app.Services?.GetService<IServiceScopeFactory>()?.CreateScope();
// var context = scope?.ServiceProvider.GetRequiredService<Context>();
// context?.Database.Migrate();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseHttpMetrics();
app.UseMetricServer();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapMetrics();
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }
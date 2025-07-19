using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Messages.Application.Extensions;
using InstaConnect.Messages.Infrastructure.Extensions;
using InstaConnect.Messages.Presentation.Extensions;
using InstaConnect.Messages.Presentation.Features.Messages.Helpers.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment)
    .AddPresentation(builder.Configuration);

builder.Host.AddSerilog();

builder.Logging.AddLogging(builder.Configuration, builder.Environment);

var app = builder.Build();

await app.SetUpDatabaseAsync(CancellationToken.None);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(AppPolicies.CorsPolicy);

app.UseRateLimiter();

app.MapHub<ChatHub>("/chat-hub");

app.MapControllers();

app.UseExceptionHandler(opt => { });

await app.RunAsync();


// Utils for testing
public partial class Program
{
    private Program()
    {
    }
}

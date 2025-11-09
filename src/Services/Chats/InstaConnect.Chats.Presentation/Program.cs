using InstaConnect.Chats.Application.Extensions;
using InstaConnect.Chats.Domain.Extensions;
using InstaConnect.Chats.Infrastructure.Extensions;
using InstaConnect.Chats.Presentation.Extensions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
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

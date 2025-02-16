using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Infrastructure.Extensions;
using InstaConnect.Posts.Presentation.Extensions;
using InstaConnect.Shared.Presentation.Extensions;
using InstaConnect.Shared.Presentation.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation(builder.Configuration);

builder.Host.AddSerilog();

var app = builder.Build();

await app.SetUpDatabaseAsync(CancellationToken.None);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AppPolicies.CorsPolicy);

app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

await app.RunAsync();


// Utils for testing
public partial class Program { }

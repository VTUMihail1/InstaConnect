using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Common.Presentation.Utilities;
using InstaConnect.Emails.Infrastructure.Extensions;
using InstaConnect.Emails.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration, builder.Environment)
    .AddPresentation(builder.Configuration);

builder.Host.AddSerilog();

builder.Logging.AddLogging(builder.Configuration, builder.Environment);

var app = builder.Build();

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

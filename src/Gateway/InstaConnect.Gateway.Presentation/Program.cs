using InstaConnect.Gateway.Infrastructure.Extensions;
using InstaConnect.Gateway.Presentation.Extensions;
using InstaConnect.Shared.Presentation.Extensions;
using InstaConnect.Shared.Presentation.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddPresentation(builder.Configuration);

builder.Host.AddSerilog();

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

app.MapReverseProxy();

app.Run();

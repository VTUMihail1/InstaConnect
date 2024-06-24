using InstaConnect.Gateway.Web.Extensions;
using InstaConnect.Shared.Web.Extensions;
using InstaConnect.Shared.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebLayer(builder.Configuration);

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

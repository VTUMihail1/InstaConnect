using InstaConnect.Emails.Business.Extensions;
using InstaConnect.Emails.Web.Extensions;
using InstaConnect.Shared.Web.Extensions;
using InstaConnect.Shared.Web.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddBusinessServices(builder.Configuration)
    .AddWebServices(builder.Configuration);

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

app.MapControllers();

app.UseExceptionHandler();

app.Run();

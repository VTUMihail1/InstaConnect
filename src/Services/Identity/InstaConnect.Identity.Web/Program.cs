using InstaConnect.Identity.Business.Extensions;
using InstaConnect.Identity.Data.Extensions;
using InstaConnect.Identity.Web.Extensions;
using InstaConnect.Shared.Web.Extensions;
using InstaConnect.Shared.Web.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDataServices(builder.Configuration)
    .AddBusinessServices(builder.Configuration)
    .AddWebServices(builder.Configuration);

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

app.Run();


// Utils for testing
public partial class Program { }

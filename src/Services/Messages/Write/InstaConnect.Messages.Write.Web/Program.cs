using InstaConnect.Messages.Write.Business.Extensions;
using InstaConnect.Messages.Write.Business.Helpers.Hubs;
using InstaConnect.Messages.Write.Data.Extensions;
using InstaConnect.Messages.Write.Web.Extensions;
using InstaConnect.Shared.Web.Extensions;
using InstaConnect.Shared.Web.Utilities;

var builder = WebApplication.CreateBuilder(args);
var cancellationTokenSource = new CancellationTokenSource();

builder.Services
    .AddDataLayer(builder.Configuration)
    .AddBusinessLayer(builder.Configuration)
    .AddWebLayer(builder.Configuration);

builder.Host.AddSerilog();

var app = builder.Build();

await app.SetUpDatabaseAsync(cancellationTokenSource.Token);

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

app.Run();


// Utils for testing
public partial class Program { }

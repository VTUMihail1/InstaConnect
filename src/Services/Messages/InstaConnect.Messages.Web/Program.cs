using InstaConnect.Messages.Business.Extensions;
using InstaConnect.Messages.Business.Helpers.Hubs;
using InstaConnect.Messages.Data.Extensions;
using InstaConnect.Messages.Web.Extensions;
using InstaConnect.Shared.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
var cancellationTokenSource = new CancellationTokenSource();

builder.Services
    .AddDataLayer(builder.Configuration)
    .AddBusinessLayer(builder.Configuration)
    .AddWebLayer(builder.Configuration);

var app = builder.Build();

await app.SetUpDatabaseAsync(cancellationTokenSource.Token);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthorization();

app.MapHub<ChatHub>("/chat-hub");

app.MapControllers();

app.Run();

using InstaConnect.Messages.Business.Extensions;
using InstaConnect.Messages.Business.Helpers.Hubs;
using InstaConnect.Messages.Data.Extensions;
using InstaConnect.Messages.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDataLayer(builder.Configuration)
    .AddBusinessLayer(builder.Configuration)
    .AddWebLayer();

var app = builder.Build();

await app.SetUpDatabaseAsync();

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

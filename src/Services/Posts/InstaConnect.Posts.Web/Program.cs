using InstaConnect.Posts.Business.Extensions;
using InstaConnect.Posts.Data.Extensions;
using InstaConnect.Posts.Web.Extensions;

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

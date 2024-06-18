using InstaConnect.Follows.Business.Extensions;
using InstaConnect.Follows.Data.Extensions;
using InstaConnect.Follows.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDataLayer(builder.Configuration)
    .AddBusinessLayer(builder.Configuration)
    .AddWebLayer(builder.Configuration);

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

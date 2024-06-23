using InstaConnect.Posts.Business.Extensions;
using InstaConnect.Posts.Data.Extensions;
using InstaConnect.Posts.Web.Extensions;
using InstaConnect.Shared.Web.Extensions;
using InstaConnect.Shared.Web.Utils;

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

app.UseCors(AppPolicies.CorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();

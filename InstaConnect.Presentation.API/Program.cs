using InstaConnect.Business.Extensions;
using InstaConnect.Business.Helpers.Hubs;
using InstaConnect.Data.Extensions;
using InstaConnect.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataLayer(builder.Configuration)
    .AddBusinessLayer(builder.Configuration)
    .AddWebLayer(builder.Configuration);

var app = builder.Build();

await app.SetUpDatabase();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowedOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chat-hub");

app.MapControllers();

app.Run();

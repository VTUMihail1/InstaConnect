using InstaConnect.Users.Business.Extensions;
using InstaConnect.Users.Data.Extensions;
using InstaConnect.Users.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDataLayer(builder.Configuration)
    .AddBusinessLayer(builder.Configuration)
    .AddWebLayer(builder.Configuration);

var app = builder.Build();

await app.SetUpDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

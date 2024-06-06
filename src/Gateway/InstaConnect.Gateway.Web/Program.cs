using InstaConnect.Gateway.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebLayer(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapReverseProxy();

app.Run();

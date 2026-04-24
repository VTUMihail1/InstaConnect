using InstaConnect.Common.Infrastructure.Features.Observability.Extensions;
using InstaConnect.Common.Presentation.Features.Observability.Extensions;
using InstaConnect.Posts.Application.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Extensions;
using InstaConnect.Posts.Presentation.Features.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment, PostsPresentationReference.Assembly)
    .AddPresentation(builder.Configuration);

builder.Host.AddSerilog();

builder.Logging.AddLogging(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UsePresentation();

await app.RunAsync();


// Utils for testing
public partial class Program
{
    private Program()
    {
    }
}

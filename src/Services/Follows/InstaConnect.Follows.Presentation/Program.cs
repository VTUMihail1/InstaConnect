using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Follows.Application.Features.Common.Extensions;
using InstaConnect.Follows.Domain.Features.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;
using InstaConnect.Follows.Presentation.Features.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment, FollowsPresentationReference.Assembly)
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

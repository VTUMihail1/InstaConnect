using InstaConnect.Common.Infrastructure.Features.Observability.Extensions;
using InstaConnect.Common.Presentation.Features.Observability.Extensions;
using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Common.Extensions;
using InstaConnect.Identity.Presentation.Features.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddDomain()
	.AddApplication()
	.AddInfrastructure(builder.Configuration, builder.Environment, IdentityPresentationReference.Assembly)
	.AddPresentation(builder.Configuration);

builder.Host.AddSerilog();

builder.Logging.AddLogging(builder.Configuration, builder.Environment);

var app = builder.Build();

await app.UsePresentationAsync();

await app.RunAsync();


// Utils for testing
public partial class Program
{
	private Program()
	{
	}
}

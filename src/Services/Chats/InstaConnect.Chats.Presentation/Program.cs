using InstaConnect.Chats.Application.Features.Common.Extensions;
using InstaConnect.Chats.Domain.Features.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;
using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.Observability.Extensions;
using InstaConnect.Common.Presentation.Features.Observability.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddDomain()
	.AddApplication()
	.AddInfrastructure(builder.Configuration, builder.Environment, ChatsPresentationReference.Assembly)
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

using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Extensions;
using InstaConnect.Posts.Infrastructure.Extensions;
using InstaConnect.Posts.Presentation.Extensions;
using InstaConnect.Posts.Presentation.Features.Users.EventHandlers;
using InstaConnect.Posts.Presentation.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment, PostsPresentationReference.Assembly, (configurator, context) => configurator.ReceiveEndpoint<UserAddedEventHandler>(context, PostsEventHandlerUtilities.UserAdded)
                                                                                                                                               .ReceiveEndpoint<UserUpdatedEventHandler>(context, PostsEventHandlerUtilities.UserUpdated)
                                                                                                                                               .ReceiveEndpoint<UserDeletedEventHandler>(context, PostsEventHandlerUtilities.UserDeleted))
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

using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Presentation.Extensions;
using InstaConnect.Follows.Application.Extensions;
using InstaConnect.Follows.Domain.Extensions;
using InstaConnect.Follows.Infrastructure.Extensions;
using InstaConnect.Follows.Presentation.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.EventHandlers;
using InstaConnect.Follows.Presentation.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment, FollowsPresentationReference.Assembly, (configurator, context) => configurator.ReceiveEndpoint<UserAddedEventHandler>(context, FollowsEventHandlerUtilities.UserAdded)
                                                                                                                                                 .ReceiveEndpoint<UserUpdatedEventHandler>(context, FollowsEventHandlerUtilities.UserUpdated)
                                                                                                                                                 .ReceiveEndpoint<UserDeletedEventHandler>(context, FollowsEventHandlerUtilities.UserDeleted))
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

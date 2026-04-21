using InstaConnect.Chats.Application.Extensions;
using InstaConnect.Chats.Domain.Extensions;
using InstaConnect.Chats.Infrastructure.Extensions;
using InstaConnect.Chats.Presentation.Extensions;
using InstaConnect.Chats.Presentation.Features.Users.EventHandlers;
using InstaConnect.Chats.Presentation.Utilities;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment, ChatsPresentationReference.Assembly, (configurator, context) => configurator.ReceiveEndpoint<UserAddedEventHandler>(context, ChatsEventHandlerUtilities.UserAdded)
                                                                                                                                               .ReceiveEndpoint<UserUpdatedEventHandler>(context, ChatsEventHandlerUtilities.UserUpdated)
                                                                                                                                               .ReceiveEndpoint<UserDeletedEventHandler>(context, ChatsEventHandlerUtilities.UserDeleted))
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

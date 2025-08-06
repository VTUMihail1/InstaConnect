using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Users.Application.Features.Users.Commands.Add;

namespace InstaConnect.Posts.Presentation.Features.Users.Consumers;

internal class UserCreatedEventHandler : IEventHandler<UserAddedEventRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public UserCreatedEventHandler(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    public async Task Consume(ConsumeContext<UserAddedEventRequest> context)
    {
        var request = _applicationMapper.Map<AddUserCommandRequest>(context.Message);
        await _applicationSender.SendAsync(request, context.CancellationToken);
    }
}

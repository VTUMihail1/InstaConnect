using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;

public record DeleteFollowCommand(string Id, string CurrentUserId) : ICommand;

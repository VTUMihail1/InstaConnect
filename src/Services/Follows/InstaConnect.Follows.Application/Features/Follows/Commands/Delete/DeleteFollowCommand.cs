using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Commands.DeleteFollow;

public record DeleteFollowCommand(string Id, string CurrentUserId) : ICommand;

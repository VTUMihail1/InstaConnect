using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;

public record DeleteFollowCommand(string Id, string CurrentUserId) : ICommand;

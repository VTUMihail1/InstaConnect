namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

public record AddFollowCommand(string CurrentUserId, string FollowingId) : ICommand<FollowCommandViewModel>;

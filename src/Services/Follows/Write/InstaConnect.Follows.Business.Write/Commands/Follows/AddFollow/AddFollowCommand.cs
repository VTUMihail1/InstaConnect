using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;

public class AddFollowCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;
}

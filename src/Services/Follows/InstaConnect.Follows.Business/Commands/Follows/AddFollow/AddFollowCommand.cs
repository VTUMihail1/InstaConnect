using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow;

public class AddFollowCommand : ICommand
{
    public string FollowingId { get; set; }
}

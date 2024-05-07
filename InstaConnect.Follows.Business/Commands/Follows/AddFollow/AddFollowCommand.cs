using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow;

public class AddFollowCommand : ICommand
{
    public string FollowingId { get; set; }
}

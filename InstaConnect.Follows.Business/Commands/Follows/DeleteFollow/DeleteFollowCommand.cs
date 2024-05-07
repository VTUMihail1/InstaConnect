using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommand : ICommand
{
    public string Id { get; set; }

    public string FollowerId { get; set; }
}

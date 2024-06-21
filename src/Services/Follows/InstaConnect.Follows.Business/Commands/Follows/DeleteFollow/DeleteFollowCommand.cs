using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommand : ICommand
{
    public string Id { get; set; }
}

using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;

public class DeleteFollowCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}

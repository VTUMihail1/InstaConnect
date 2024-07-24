using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;

public class AddFollowCommand : ICommand<FollowCommandViewModel>
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;
}

using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;

public record AddFollowCommand(string CurrentUserId, string FollowingId) : ICommand<FollowCommandViewModel>;

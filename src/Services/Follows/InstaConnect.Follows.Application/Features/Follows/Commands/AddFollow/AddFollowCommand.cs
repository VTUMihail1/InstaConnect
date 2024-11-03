using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;

public record AddFollowCommand(string CurrentUserId, string FollowingId) : ICommand<FollowCommandViewModel>;

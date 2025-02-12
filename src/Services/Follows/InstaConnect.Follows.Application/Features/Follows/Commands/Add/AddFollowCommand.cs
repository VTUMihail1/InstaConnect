using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

public record AddFollowCommand(string CurrentUserId, string FollowingId) : ICommand<FollowCommandViewModel>;

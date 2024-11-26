using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrentUser;

public record DeleteCurrentUserCommand(string CurrentUserId) : ICommand;

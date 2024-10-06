using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.DeleteCurrentUser;

public record DeleteCurrentUserCommand(string CurrentUserId) : ICommand;

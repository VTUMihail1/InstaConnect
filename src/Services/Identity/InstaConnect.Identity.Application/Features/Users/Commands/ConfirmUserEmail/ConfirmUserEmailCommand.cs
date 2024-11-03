using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;

public record ConfirmUserEmailCommand(string UserId, string Token) : ICommand;
